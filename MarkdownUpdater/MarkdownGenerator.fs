namespace MarkdownUpdater

module MarkdownGenerator =
    open System
    open System.Text

    let private printLink (nameMaybe:Option<_>) value =
        match nameMaybe with
        | Some name -> $"[{name}]({value})"
        | None -> value

    let printRule buildIssueLink (level:int) (rule:StyleRule) =
        let builder = StringBuilder()

        builder.AppendLine($"{String('#', level)} {rule.Name}") |> ignore

        builder.AppendLine() |> ignore

        match rule.SelectedValue with
        | Some value -> builder.AppendLine($"Selected value: {value}") |> ignore
        | None -> ()

        builder.AppendLine() |> ignore

        match rule.IssueId with
        | Some value -> builder.AppendLine($"Issue: {value |> buildIssueLink |> printLink None}") |> ignore
        | None -> ()

        builder.AppendLine() |> ignore

        builder.AppendLine("Values:") |> ignore
        for value in rule.Values do
            builder.AppendLine($"* {value}") |> ignore

        builder.AppendLine() |> ignore

        builder.AppendLine(printLink (Some "MSDN Link") rule.MsdnLink) |> ignore

        builder.AppendLine() |> ignore

        builder.ToString()

    let rec private printNode' printRule (builder:StringBuilder) (level:int) (node:DocumentNode) =
        match node with
        | Rule rule ->
            let printedRule:string = printRule level rule
            builder.AppendLine(printedRule)
        | Section (name, innerNodes) ->
            builder.AppendLine($"{String('#', level)} {name}") |> ignore

            for innderNode in innerNodes do
                printNode' printRule builder (level + 1) innderNode |> ignore

            builder

    let printNode buildIssueLink node =
        let builder = StringBuilder()
        let printRule' = printRule buildIssueLink
        printNode' printRule' builder 1 node |> ignore
        builder.ToString()
