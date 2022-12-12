namespace MsdnTableParser

module HtmlParser =
    open SectionParser
    open HtmlAgilityPack
    
    let private abortOnException = AbortOnExceptionBuilder()

    let parseHtml text =
        abortOnException {
            let document = HtmlDocument()
            do! abortOnException { return document.LoadHtml(text) }

            let html = document.DocumentNode
            let body = html.Element("body")
            let sectionHeaders = body.SelectNodes("//h3[@class='heading-anchor']")

            let sections =
                seq {
                    for header in sectionHeaders do
                        let hasTable =
                            not (header.NextSibling = null)
                            |> (&&) (header.NextSibling.Name = "div")
                            |> (&&) (not (header.NextSibling.FirstChild = null))
                            |> (&&) (header.NextSibling.FirstChild.Name = "table")
                        
                        if hasTable then
                            let htmlRows = header.NextSibling.FirstChild.LastChild.ChildNodes
                            let table =
                                seq {
                                    for htmlRow in htmlRows do
                                        yield htmlRow.ChildNodes
                                        |> Seq.map (fun node -> node.InnerText)
                                        |> List.ofSeq
                                        |> TableRow.Values
                                }
                                |> List.ofSeq
                                |> Table.Rows
                            
                            yield {
                                Header =
                                    {
                                        Title = header.InnerText;
                                        Link = header.FirstChild.GetAttributeValue("href", "");
                                    };
                                Table = table;
                            }
                }

            return sections
        }
