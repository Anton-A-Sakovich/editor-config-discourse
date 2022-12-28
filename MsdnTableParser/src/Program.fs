open EditorconfigDiscourse.MsdnTableParser
open EditorconfigDiscourse.Utilities.Program
open EditorconfigDiscourse.Yaml
open EditorconfigDiscourse.StyleTree
open System
open System.IO
open System.Net.Http
open System.Text
open System.Text.RegularExpressions
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
                    return! Program.Failed ("No output file specified", 1)
            }

        let sourceRootPath =
            if args.Length > 1 then args[1] else githubUrlPrefix

        use httpClient = new HttpClient()
        let fetchFileAsync =
            if sourceRootPath.StartsWith("http") then
                fun path -> HtmlFetcher.fetchPageAsync httpClient "text/plain" (Uri(sourceRootPath + path).ToString())
            else
                let encoding = UTF8Encoding(false)
                fun path -> LocalFileFetcher.fetchFileAsync encoding (Path.Combine(sourceRootPath, path))

        let! tocYamlString =
            fetchFileAsync tocYamlPath
            |> Async.AwaitTask
            |> Async.RunSynchronously
            |> (function
                | Some value -> Program.Completed value
                | None -> Program.Failed ("Error fetching table of contents YAML", 1))

        let tocYamlStream = YamlStream()
        use tocYamlReader = new StringReader(tocYamlString)
        tocYamlStream.Load(tocYamlReader)
        let! tocRoot =
            tocYamlStream.Documents
            |> (fun list ->
                if list.Count > 0 then
                    Program.Completed(list[0].RootNode)
                else
                    Program.Failed("Failed to parse TOC YAML", 2))

        let! treeOfTocPages =
            tocRoot
            |> TocYamlParser.tryParse
            |> (function | ParseResult.Parsed value -> Program.Completed value | ParseResult.Failed -> Program.Failed("Failed to build TOC from YAML", 3))

        let! treeOfTocPages =
            treeOfTocPages
            |> StyleTree.tryFind ["Root"; "Tools and diagnostics"; "Code analysis"; "Rule reference"; "Code style rules"]
            |> (function | Some value -> Program.Completed value | None -> Program.Failed("Failed to find code style entry", 4))

        let fetchAndParseMarkdown href =
            (href:string).LastIndexOf(".md") |> (function | -1 -> None | x -> Some x)
            |> Option.map (fun index -> href.Substring(0, index))
            |> Option.map (fun hrefWithoutExtension -> Uri(msdnUrlPrefix + hrefWithoutExtension).ToString())
            |> Option.bind (fun urlToLinkTo ->
                fetchFileAsync href
                |> Async.AwaitTask
                |> Async.RunSynchronously
                |> Option.bind (MarkdownParser.parseMarkdown urlToLinkTo))

        let treeOfMaybeStylePages = treeOfTocPages |> StyleTree.map fetchAndParseMarkdown

        let! treeOfStylePages =
            treeOfMaybeStylePages
            |> StyleTreePostProcessor.refine
            |> (function | Some tree -> Program.Completed tree | None -> Program.Failed ("Failed to build some Style Pages", 5))

        let yamlTree = YamlRepresentation.toYaml RulesYamlBuilder.pageToYaml treeOfStylePages
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
