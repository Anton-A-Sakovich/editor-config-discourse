namespace EditorconfigDiscourse.MarkdownUpdater

module EditorconfigParser =
    open System.Text.RegularExpressions

    let parseEditorconfig (contents:string) =
        Regex.Matches(contents, @"^\s*(\w+)\s*=\s*([\w:]+)\s*(?:#(.+))?$", RegexOptions.Multiline)
        |> Seq.fold (fun map regexMatch ->
            let ruleName = regexMatch.Groups[1].Value
            let ruleValue = regexMatch.Groups[2].Value

            let comment' =
                if regexMatch.Groups[3].Success then
                    Some regexMatch.Groups[3].Value
                else
                    None

            let issueId =
                match comment' with
                | Some comment ->
                    let referenceMatch = Regex.Match(comment, @"^\(([^\)]+)\)")
                    if referenceMatch.Success then
                        Some referenceMatch.Groups[1].Value
                    else
                        None
                | None -> None

            let rule =
                {
                    Name = ruleName;
                    Value = ruleValue;
                    IssueId = issueId;
                }

            Map.add ruleName rule map) Map.empty<string, EditorconfigRule>
