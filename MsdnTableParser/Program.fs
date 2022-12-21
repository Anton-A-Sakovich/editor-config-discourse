open MsdnTableParser.HtmlFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.SectionParser
open System
open System.Net.Http
open System.Text.RegularExpressions
open Utilities.Program
open YamlDotNet.Serialization

[<Literal>]
let githubUrlPrefix = "https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals"

[<Literal>]
let msdnUrlPrefix = "https://learn.microsoft.com/en-us/dotnet/fundamentals"

[<EntryPoint>]
let main args =
    program {
        let! providedUrl =
            program {
                if args.Length > 0 then
                    return args[0]
                else
                    return! Failed ("No URL provided.", 1)
            }

        do! program {
            if providedUrl.StartsWith(msdnUrlPrefix) then
                return ()
            else
                return! Failed ("The URL provided is not a valid MSDN URL of a style rule.", 2)
        }

        let urlToFetchFrom = providedUrl.Replace(msdnUrlPrefix, githubUrlPrefix) + ".md"
        let urlToPrepend = providedUrl

        let! text =
            async {
                use httpClient = new HttpClient()
                let! text = fetchPageAsync httpClient "text/plain" urlToFetchFrom |> Async.AwaitTask
                return text
            }
            |> Async.RunSynchronously
            |> (function
                | Some value -> Completed value
                | None -> Failed ("Error fetching the markdown from GitHub.", 3))

        let optionsMetadata =
            parseMarkdown urlToPrepend text
            |> Seq.map parseSection
            |> Seq.choose id

        let serializer =
            SerializerBuilder()
             .DisableAliases()
             .WithIndentedSequences()
             .WithQuotingNecessaryStrings()
             .Build()

        let yaml = serializer.Serialize(optionsMetadata)

        let mutable spacesToPrepend = 0
        do (args.Length > 1 && Int32.TryParse(args[1], &spacesToPrepend)) |> ignore

        let yamlWithSpaces =
            if spacesToPrepend = 0 then
                yaml
            else
                Regex.Replace(yaml, @"^", String(' ', spacesToPrepend), RegexOptions.Multiline)

        printfn "%s" yamlWithSpaces

        return ()
    }
    |> run
