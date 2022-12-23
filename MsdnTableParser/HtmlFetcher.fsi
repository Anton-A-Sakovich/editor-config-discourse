namespace MsdnTableParser

module HtmlFetcher =
    open System.Net.Http
    open System.Threading.Tasks

    val fetchPageAsync : httpClient:HttpClient -> expectedContentType:string -> url:string -> Task<option<string>>
