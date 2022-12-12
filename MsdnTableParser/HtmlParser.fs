namespace MsdnTableParser

module HtmlParser =
    open SectionParser
    open HtmlAgilityPack
    
    let private abortOnException = AbortOnExceptionBuilder()

    let parseHtml text =
        abortOnException {
            let document = HtmlDocument()
            do! abortOnException { return document.LoadHtml(text) }

            let body = document.DocumentNode.Element("html").Element("body")
            let sectionHeaders =
                body.SelectNodes("//h3")
                |> (function | null -> Seq.empty | nodes -> nodes)
                |> Seq.filter (fun node ->
                    node.InnerText |> (fun innerText ->
                        innerText <> null && innerText.Contains("_")))

            let sections =
                seq {
                    for header in sectionHeaders do
                        let hasTable =
                            header.NextSibling <> null
                            && header.NextSibling.Name = "div"
                            && header.NextSibling.FirstChild <> null
                            && header.NextSibling.FirstChild.Name = "table"
                        
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
