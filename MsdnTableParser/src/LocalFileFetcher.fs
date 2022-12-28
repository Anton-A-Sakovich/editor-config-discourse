namespace MsdnTableParser

module LocalFileFetcher =
    open System.IO
    open System.Text

    let fetchFileAsync (encoding:Encoding) (path:string) =
        task {
            if File.Exists(path) then
                let! text = File.ReadAllTextAsync(path, encoding)
                return Some text
            else
                return None
        }
