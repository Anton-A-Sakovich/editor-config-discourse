namespace MsdnTableParser

module HtmlFetcher =
    open System.Net.Http

    let fetchPageAsync (httpClient:HttpClient) (contentType:string) (url:string) =
        task {
            let! response = httpClient.GetAsync(url)
            if response.Content.Headers.ContentType.MediaType = contentType then
                let! text = response.Content.ReadAsStringAsync()
                return Some text
            else
                return None
        }