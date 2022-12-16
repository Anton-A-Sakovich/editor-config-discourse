namespace MarkdownUpdater

module EditorconfigParser =
    open System.Text.RegularExpressions

    let parseEditorconfig (contents:string) = 
        Regex.Matches(contents, @"^\s*(\w+)\s*=\s*([\w:]+)\s*(?:#(.+))?$", RegexOptions.Multiline)
        |> Seq.fold (fun map regexMatch ->
            let ruleName = regexMatch.Groups[1].Value
            let ruleValue = regexMatch.Groups[2].Value 
            let issueId =
                if regexMatch.Groups[3].Success then
                    Some regexMatch.Groups[3].Value
                else
                    None

            let rule =
                {
                    Name = ruleName;
                    Value = ruleValue;
                    IssueId = issueId;
                }
            
            Map.add ruleName rule map) Map.empty<string, EditorconfigRule>