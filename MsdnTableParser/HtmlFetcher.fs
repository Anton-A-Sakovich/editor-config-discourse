namespace MsdnTableParser

module HtmlFetcher =
    open System.Net
    open System.Net.Http

    let fetchPageAsync (httpClient:HttpClient) (expectedContentType:string) (url:string) =
        task {
            let! response = httpClient.GetAsync(url)

            if response.StatusCode = HttpStatusCode.OK then
                let responseContentType = response.Content.Headers.ContentType.MediaType

                if responseContentType = expectedContentType then
                    let! text = response.Content.ReadAsStringAsync()
                    return Some text
                else
                    return None
            else
                return None
        }
