namespace MsdnTableParser

module HtmlFetcher =
    open System.Net.Http

    let fetchPageAsync (httpClient:HttpClient) (url:string) =
        task {
            let! response = httpClient.GetAsync(url)
            if response.Content.Headers.ContentType.MediaType = "text/html" then
                let! text = response.Content.ReadAsStringAsync()
                return Some text
            else
                return None
        }