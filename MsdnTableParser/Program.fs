open MsdnTableParser.HtmlFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.SectionParser
open YamlDotNet.Serialization

type ProgramBlock<'TValue, 'TError> =
    | Ok of 'TValue
    | Error of 'TError
    | Pending

let ok value = Ok value
let error value = Error value

let run (result:ProgramBlock<_,_>) =
    match result with
    | Ok value -> value
    | Error (message, value) ->
        printfn "%s" message
        value
    | Pending -> -1

type ProgramBuilder() =
    member _.Bind(result:ProgramBlock<_,_>, cont) =
        match result with
        | Ok value -> cont value
        | Error error -> Error error
        | Pending -> Pending

    member _.ReturnFrom(value) = value
    member _.Zero() = Pending

    member _.Delay(f) = f
    member _.Run(f) = f ()

    member _.Combine(result:ProgramBlock<_,_>, cont) =
        match result with
        | Pending -> cont ()
        | _ -> result

let program = ProgramBuilder()

let githubUrlPrefix = "https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals"
let msdnUrlPrefix = "https://learn.microsoft.com/en-us/dotnet/fundamentals"

[<EntryPoint>]
let main args =
    program {
        if args.Length = 0 then
            return! error ("No URL provided", 1)

        let url = args[0]
        if not (url.StartsWith(githubUrlPrefix)) then
            return! error ("Incorrect URL", 2)

        let urlToPrepend = url.Replace(githubUrlPrefix, msdnUrlPrefix)

        let! text =
            async {
                use httpClient = new System.Net.Http.HttpClient()
                let! text = fetchPageAsync httpClient "text/plain" url |> Async.AwaitTask
                return text
            }
            |> Async.RunSynchronously
            |> (function
                | Some value -> ok value
                | None -> error ("Error Error fetching the markdown from GitHub.", 3))

        let optionsMetadata =
            parseMarkdown urlToPrepend text
            |> Seq.map parseSection
            |> Seq.choose id

        let serializer =
            SerializerBuilder()
             .DisableAliases()
             .WithQuotingNecessaryStrings()
             .Build()

        serializer.Serialize(optionsMetadata) |> printfn "%s"

        return! ok 0
    }
    |> run