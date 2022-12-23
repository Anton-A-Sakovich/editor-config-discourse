open MsdnTableParser
open MsdnTableParser.HtmlFetcher
open MsdnTableParser.LocalFileFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.TocYamlParser
open MsdnTableParser.RulesYamlBuilder
open System
open System.IO
open System.Net.Http
open System.Text
open System.Text.RegularExpressions
open Utilities.Program
open YamlDotNet.Serialization
open YamlDotNet.RepresentationModel

[<Literal>]
let githubUrlPrefix = "https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals/"

[<Literal>]
let msdnUrlPrefix = "https://learn.microsoft.com/en-us/dotnet/fundamentals/"

[<Literal>]
let tocYamlPath = "toc.yml"

[<EntryPoint>]
let main args =
    program {
        let! outputFilePath =
            program {
                if args.Length > 0 then
                    return args[0]
                else
                    return! Failed ("No output file specified", 1)
            }

        let sourceRootPath =
            if args.Length > 1 then args[1] else githubUrlPrefix

        use httpClient = new HttpClient()
        let fetchFileAsync =
            if sourceRootPath.StartsWith("http") then
                fun path -> fetchPageAsync httpClient "text/plain" (Uri(sourceRootPath + path).ToString())
            else
                let encoding = UTF8Encoding(false)
                fun path -> fetchFileAsync encoding (Path.Combine(sourceRootPath, path))

        let! tocYamlString =
            fetchFileAsync tocYamlPath
            |> Async.AwaitTask
            |> Async.RunSynchronously
            |> (function
                | Some value -> Completed value
                | None -> Failed ("Error fetching table of contents YAML", 1))

        let tocYamlStream = YamlStream()
        use tocYamlReader = new StringReader(tocYamlString)
        tocYamlStream.Load(tocYamlReader)
        let! tocRoot =
            tocYamlStream.Documents
            |> (fun list ->
                if list.Count > 0 then
                    Completed(list[0].RootNode)
                else
                    Failed("Failed to parse TOC YAML", 2))

        let! treeOfTocPages =
            tocRoot
            |> tryParse
            |> (function | Success value -> Completed value | Failure -> Failed("Failed to build TOC from YAML", 3))

        let! treeOfTocPages =
            treeOfTocPages
            |> StyleTree.tryFind ["Root"; "Tools and diagnostics"; "Code analysis"; "Rule reference"; "Code style rules"]
            |> (function | Some value -> Completed value | None -> Failed("Failed to find code style entry", 4))

        let fetchAndParseMarkdown href =
            let urlToLinkTo = Uri(msdnUrlPrefix + href).ToString()
            fetchFileAsync href
            |> Async.AwaitTask
            |> Async.RunSynchronously
            |> Option.bind (parseMarkdown urlToLinkTo)

        let treeOfMaybeStylePages = treeOfTocPages |> StyleTree.map fetchAndParseMarkdown

        let rec transposeOption (collected:list<_>) (remaining:list<option<_>>) =
            match remaining with
            | [] -> Some (List.rev collected)
            | head::tail ->
                match head with
                | Some value -> transposeOption (value::collected) tail
                | None -> None

        let onPage (name, value':option<_>) =
            match value' with
            | Some value -> Some(Page(name, value))
            | None -> None

        let onSection (name, children:list<option<_>>) =
            let transposedChildren = transposeOption [] children
            match transposedChildren with
            | Some list -> Some (Section(name, list))
            | None -> None

        let! treeOfStylePages =
            treeOfMaybeStylePages
            |> StyleTree.cat onPage onSection
            |> (function | Some tree -> Completed tree | None -> Failed ("Failed to build some Style Pages", 5))

        let yamlTree = treeToYaml treeOfStylePages
        let yamlString =
            SerializerBuilder()
             .DisableAliases()
             .WithIndentedSequences()
             .WithQuotingNecessaryStrings()
             .Build()
             .Serialize(yamlTree)

        let mutable spacesToPrepend = 0
        do (args.Length > 1 && Int32.TryParse(args[1], &spacesToPrepend)) |> ignore

        let yamlWithSpaces =
            if spacesToPrepend = 0 then
                yamlString
            else
                Regex.Replace(yamlString, @"^", String(' ', spacesToPrepend), RegexOptions.Multiline)

        do File.WriteAllText(outputFilePath, yamlWithSpaces, UTF8Encoding(false))

        return ()
    }
    |> run
