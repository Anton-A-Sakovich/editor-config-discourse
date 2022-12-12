namespace MsdnTableParser

module MarkdownParser =
    open SectionParser
    open System
    open System.Text.RegularExpressions

    type private ParserState =
        | Empty
        | SectionName of sectionName:string
        | SectionNameAndTable of sectionName:string * rows:list<list<string>>

    let private foldLines baseUrl (acc:(ParserState * list<Section>)) (line:string) =
        let (state, sections) = acc

        match state with
        | Empty ->
            let state'' =
                match Regex.Match(line, @"^###\s*(\w+_\w+)\s*") with
                | regexMatch when regexMatch.Success -> SectionName (regexMatch.Groups[1].Value)
                | _ -> Empty
            (state'', sections)

        | SectionName name ->
            let state'' =
                if line.Contains("-") then
                    SectionNameAndTable (name, [])
                else
                    state
            (state'', sections)

        | SectionNameAndTable (name, rows) ->
            if line.Contains("|") then
                let row =
                    line.Split([|char "|"|], StringSplitOptions.RemoveEmptyEntries)
                    |> Array.map (fun s -> s.Trim().Replace("*", "").Replace("`", ""))
                    |> List.ofArray
                
                (SectionNameAndTable (name, row::rows), sections)
            else
                let table = rows |> List.rev |> List.map TableRow.Values |> Table.Rows
                let section:Section =
                    {
                        Header =
                            {
                                Title = name;
                                Link = baseUrl + "#" + name;
                            };
                        Table = table;
                    }
                (Empty, section::sections)

    let parseMarkdown baseUrl (text:string) =
        text.Split("\n")
        |> Array.fold (foldLines baseUrl) (Empty, [])
        |> (fun (_, list) -> List.rev list)