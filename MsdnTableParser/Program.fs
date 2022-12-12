open MsdnTableParser.HtmlFetcher
open MsdnTableParser.MarkdownParser
open MsdnTableParser.SectionParser

let path = "/code-analysis/style-rules/csharp-formatting-options"
let urlToFetchFrom = "https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals" + path + ".md"
let urlToPrepend = "https://learn.microsoft.com/en-us/dotnet/fundamentals" + path

let text =
    async {
        use httpClient = new System.Net.Http.HttpClient()
        let! text = fetchPageAsync httpClient "text/plain" urlToFetchFrom |> Async.AwaitTask
        return text
    } |> Async.RunSynchronously

let sections =
    match text with
    | Some value -> Some (parseMarkdown urlToPrepend value)
    | None -> None

let metadata =
    match sections with
    | Some values ->
        values
        |> Seq.map parseSection
        |> Seq.choose id
        |> Some
    | None -> None

printfn "%A" sections
printfn "%A" metadata
printfn "%s" "Hello World!"