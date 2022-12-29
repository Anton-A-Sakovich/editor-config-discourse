namespace EditorconfigDiscourse.MsdnTableParser

module MarkdownParser =
    open System
    open System.Collections.Generic

    type private TableRow =
        { Property: string;
          Value: string;
          Description: string; }

    type private PropertyType =
        | OptionName
        | OptionValue
        | DefaultOptionValue
        | Other

    let private parseLine (line:string) =
        line.Split('|', StringSplitOptions.RemoveEmptyEntries)
        |> (function
            | [|property; value; description|] ->
                { Property = property.Trim().Replace("*", "");
                  Value = value.Trim();
                  Description = description.Trim(); }
                |> Some
            | _ -> None)

    let private collectRows (rows:seq<TableRow>) : option<MsdnRule> =
        let mutable propertyType = Other
        let mutable name = ""
        let mutable values = List<string>()
        let mutable defaultValue = option<string>.None

        for { Property = property; Value = value } in rows do
            if property = "Option name" then
                propertyType <- OptionName
                name <- value
            elif property = "Option values" then
                propertyType <- OptionValue
                values.Add(value)
            elif property = "" && propertyType = OptionValue then
                values.Add(value)
            elif property = "Default option value" then
                propertyType <- DefaultOptionValue
                defaultValue <- Some(value)
            else
                propertyType <- Other

        if name.Length > 0 && values.Count > 0 then
            { Name = name;
              Values = values |> List.ofSeq;
              DefaultValue = defaultValue; }
            |> Some
        else
            None

    type private LineType =
        | Subsubsection
        | Table
        | Other

    let parseMarkdown (url:string) (markdown:string) : option<MsdnPage> =
        let mutable title = ""
        let mutable lineType = Other
        let tableLines = List<string>()
        let rules = List<MsdnRule>()

        let inline collectTableLines (tableLines:List<string>) (rules:List<MsdnRule>) =
            match tableLines |> Seq.map parseLine |> Seq.choose id |> collectRows with
            | Some rule -> rules.Add(rule)
            | None -> ()

        let lines = markdown.Replace("\r", "").Split("\n", StringSplitOptions.RemoveEmptyEntries)

        for line in lines do
            if line.StartsWith("# ") then
                title <- line.Substring(2)
            elif line.StartsWith("### ") then
                lineType <- Subsubsection
            elif line.StartsWith("|") && lineType = Subsubsection then
                lineType <- Table
                tableLines.Clear()
                tableLines.Add(line)
            elif line.StartsWith("|") && lineType = Table then
                tableLines.Add(line)
            elif lineType = Table then
                collectTableLines tableLines rules
                tableLines.Clear()
                lineType <- Other
            else
                lineType <- Other

        if lineType = Table then
            collectTableLines tableLines rules

        if title = "" then
            None
        else
            Some({
                Title = title;
                Url = url;
                Rules = rules |> List.ofSeq;})
