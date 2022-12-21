open MsdnTableParser
open MsdnTableParser.HtmlFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.TocYamlParser
open MsdnTableParser.RulesYamlBuilder
open System
open System.IO
open System.Net.Http
open System.Text.RegularExpressions
open Utilities.Program
open YamlDotNet.Serialization
open YamlDotNet.RepresentationModel

[<Literal>]
let githubUrlPrefix = "https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals/"

[<Literal>]
let msdnUrlPrefix = "https://learn.microsoft.com/en-us/dotnet/fundamentals/"

[<Literal>]
let tocYamlUrl = githubUrlPrefix + "toc.yaml"

[<EntryPoint>]
let main args =
    program {
        use httpClient = new HttpClient()

        let! tocYamlString =
            fetchPageAsync httpClient "text/plain" tocYamlUrl
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
            |> tryFind "Code style rules"
            |> (function | Some value -> Completed value | None -> Failed("Failed to find code style entry", 4))

        let fetchAndParseMarkdown { TocPage.Href = href} =
            let urlToFetchFrom = Uri(githubUrlPrefix + href).ToString()
            let urlToLinkTo = Uri(msdnUrlPrefix + href).ToString()
            fetchPageAsync httpClient "text/plain" urlToFetchFrom
            |> Async.AwaitTask
            |> Async.RunSynchronously
            |> Option.bind (parseMarkdown urlToLinkTo)

        let treeOfMaybeStylePages = treeOfTocPages |> StyleTree.map fetchAndParseMarkdown

        let rec transposeOption (collected:list<_>) (remaining:list<option<_>>) =
            match remaining with
            | [] -> Some collected
            | head::tail ->
                match head with
                | Some value -> transposeOption (value::collected) tail
                | None -> None

        let onPage (page':option<_>) =
            match page' with
            | Some page -> Some(Page page)
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
             .Build()
             .Serialize(yamlTree)

        let mutable spacesToPrepend = 0
        do (args.Length > 1 && Int32.TryParse(args[1], &spacesToPrepend)) |> ignore

        let yamlWithSpaces =
            if spacesToPrepend = 0 then
                yamlString
            else
                Regex.Replace(yamlString, @"^", String(' ', spacesToPrepend), RegexOptions.Multiline)

        printfn "%s" yamlWithSpaces

        return ()
    }
    |> run
