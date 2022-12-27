namespace MsdnTableParser

module MarkdownParser =
    open System
    open System.Collections.Generic

    type TableRow =
        { Property: string;
          Value: string;
          Description: string; }

    type PropertyType =
        | OptionName
        | OptionValue
        | DefaultOptionValue
        | Other

    let parseLine (line:string) =
        line.Split('|', StringSplitOptions.RemoveEmptyEntries)
        |> (function
            | [|property; value; description|] ->
                { Property = property.Trim().Replace("*", "");
                  Value = value.Trim();
                  Description = description.Trim(); }
                |> Some
            | _ -> None)

    let collectRows (rows:seq<TableRow>) : option<MsdnRule> =
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

    type LineType =
        | Subsubsection
        | Table
        | Other

    let parseMarkdown (url:string) (markdown:string) : option<MsdnPage> =
        let mutable title = ""
        let mutable lineType = Other
        let mutable tableLines = List<string>()
        let mutable rules = List<MsdnRule>()

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
                let rule' =
                    tableLines
                    |> Seq.map parseLine
                    |> Seq.choose id
                    |> collectRows

                if rule' |> Option.isSome then
                    rules.Add(rule'.Value)

                tableLines.Clear()
                lineType <- Other
            else
                lineType <- Other

        if title = "" then
            None
        else
            Some({
                Title = title;
                Url = url;
                Rules = rules |> List.ofSeq;})
