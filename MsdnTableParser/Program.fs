open MsdnTableParser.HtmlFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.SectionParser
open YamlDotNet.Serialization

let githubUrlPrefix = "https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals"
let msdnUrlPrefix = "https://learn.microsoft.com/en-us/dotnet/fundamentals"

[<EntryPoint>]
let main args =
    if args.Length = 0 then
        printfn "No URL provided."
        1
    else
        let url = args[0]
        if not (url.StartsWith(githubUrlPrefix)) then
            printfn "URL is incorrect."
            2
        else
            let urlToPrepend = url.Replace(githubUrlPrefix, msdnUrlPrefix)

            let text =
                async {
                    use httpClient = new System.Net.Http.HttpClient()
                    let! text = fetchPageAsync httpClient "text/plain" url |> Async.AwaitTask
                    return text
                } |> Async.RunSynchronously

            match text with
            | None ->
                printfn "Error fetching the markdown from GitHub."
                3
            | Some value ->
                let optionsMetadata =
                    parseMarkdown urlToPrepend value
                    |> Seq.map parseSection
                    |> Seq.choose id

                let serializer =
                    SerializerBuilder()
                     .DisableAliases()
                     .WithQuotingNecessaryStrings()
                     .Build()

                serializer.Serialize(optionsMetadata) |> printfn "%s"

                0