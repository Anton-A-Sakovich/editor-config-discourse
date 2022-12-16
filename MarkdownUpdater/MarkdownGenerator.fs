namespace MarkdownUpdater

module MarkdownGenerator =
    open System
    open System.Text

    let private headingToMarkdown (level:int) (title:string) =
        (String('#', level), title) ||> sprintf "%s %s"

    let private linkToMarkdown (name':Option<_>) url =
        match name' with
        | Some name -> $"[{name}]({url})"
        | None -> url

    let private appendRule issueIdToLink (level:int) (rule:StyleRule) (builder:StringBuilder) =
        let inline append (str:string) = builder.Append(str) |> ignore
        let inline appendLine (str:string) = builder.AppendLine(str) |> ignore

        (rule.Name, rule.MsdnLink |> linkToMarkdown (Some "MSDN link")) ||> sprintf "`%s` %s" |> appendLine
        "" |> appendLine

        "Selected value:" |> append
        match rule.SelectedValue with
        | Some value -> value |> sprintf " %s" |> append
        | None -> ()
        "\\" |> appendLine
        
        "Issue:" |> append
        match rule.IssueId with
        | Some issueId -> issueId |> issueIdToLink |> linkToMarkdown (Some issueId) |> append
        | None -> ()
        "" |> appendLine
        "" |> appendLine

        "Possible values:" |> appendLine
        for value in rule.Values do
            value |> sprintf "* %s" |> appendLine

        "---" |> appendLine
        "" |> appendLine

    let ruleToMarkdown issueIdToLink level rule =
        let builder = StringBuilder()
        appendRule issueIdToLink level rule builder
        builder.ToString()

    let rec private appendNode appendRule (level:int) (node:DocumentNode) (builder:StringBuilder) =
        match node with
        | Rule rule -> appendRule level rule builder
        | Section (title, childNodes) ->
            title |> headingToMarkdown level |> builder.AppendLine |> ignore
            builder.AppendLine() |> ignore
            for childNode in childNodes do
                appendNode appendRule (level + 1) childNode builder

    let nodeToMarkdown issueIdToLink node =
        let builder = StringBuilder()
        appendNode (appendRule issueIdToLink) 1 node builder
        builder.ToString()
