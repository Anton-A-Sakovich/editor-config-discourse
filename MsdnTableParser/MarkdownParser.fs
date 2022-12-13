namespace MsdnTableParser

module MarkdownParser =
    open SectionParser
    open System
    open System.Collections.Generic
    open System.Text.RegularExpressions

    type private ParserState =
        | Empty
        | SectionName
        | SectionTable
    
    type private Parser(baseUrl:string) =
        member val private State = ParserState.Empty with get, set
        member val private SectionName = "" with get, set
        member val private TableRows = List<List<string>>()
        member val private Sections = List<Section>()

        member this.GetSections() =
            this.Sections

        member this.ParseLine(line:string) =
            match this.State with
            | Empty ->
                let regexMatch = Regex.Match(line, @"^###\s*(\w+_\w+)\s*")
                if regexMatch.Success then
                    this.State <- SectionName
                    this.SectionName <- regexMatch.Groups[1].Value
                    this.TableRows.Clear()
                else
                    ()
            | SectionName ->
                if line.Contains("-") then
                    this.State <- SectionTable
                    this.TableRows.Clear()
                else
                    ()
            | SectionTable ->
                if line.Contains("|") then
                    let values =
                        line.Split([|char "|"|], StringSplitOptions.RemoveEmptyEntries)
                        |> Array.map (fun s -> s.Trim().Replace("*", "").Replace("`", ""))
                    
                    let row = List<string>()
                    for value in values do
                        row.Add(value)
                    
                    this.TableRows.Add(row)
                else
                    let table =
                        this.TableRows
                        |> Seq.map List.ofSeq
                        |> Seq.map TableRow.Values
                        |> List.ofSeq
                        |> Table.Rows
                    
                    let section:Section =
                        {
                            Header =
                                {
                                    Title = this.SectionName;
                                    Link = baseUrl + "#" + this.SectionName;
                                };
                            Table = table;
                        }

                    this.Sections.Add(section)
                    this.State <- Empty
                    this.SectionName <- ""
                    this.TableRows.Clear()

    let parseMarkdown baseUrl (text:string) =
        let parser = Parser(baseUrl)
        for line in text.Split("\n") do
            parser.ParseLine(line)
        parser.GetSections() |> List.ofSeq