open MsdnTableParser.HtmlFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.SectionParser
open System
open System.Text.RegularExpressions
open YamlDotNet.Serialization

let run (result:Result<_, _>) =
    match result with
    | Ok returnCode -> returnCode
    | Error (returnCode, message) ->
        printfn "%s" message
        returnCode

type ProgramBuilder() =
    member _.Bind(result:Result<_,_>, cont) =
        match result with
        | Ok value -> cont value
        | Error error -> Error error

    member _.Return(value) = Ok value
    member _.ReturnFrom(result) = result

let program = ProgramBuilder()

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
                    return! Error (1, "No URL provided.")
            }

        do! program {
            if providedUrl.StartsWith(msdnUrlPrefix) then
                return ()
            else
                return! Error (2, "The URL provided is not a valid MSDN URL of a style rule.")
        }

        let urlToFetchFrom = providedUrl.Replace(msdnUrlPrefix, githubUrlPrefix) + ".md"
        let urlToPrepend = providedUrl

        let! text =
            async {
                use httpClient = new System.Net.Http.HttpClient()
                let! text = fetchPageAsync httpClient "text/plain" urlToFetchFrom |> Async.AwaitTask
                return text
            }
            |> Async.RunSynchronously
            |> (function
                | Some value -> Ok value
                | None -> Error (3, "Error fetching the markdown from GitHub."))

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

        return 0
    }
    |> run