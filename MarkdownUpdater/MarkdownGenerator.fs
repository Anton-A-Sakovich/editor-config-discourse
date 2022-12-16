namespace MarkdownUpdater

module MarkdownGenerator =
    open System.Text

    [<Struct>]
    type private Anchor = Anchor of name:string
    [<Struct>]
    type private Heading = Heading of level:int * anchor:option<Anchor> * title:string
    [<Struct>]
    type private Link = Link of name:option<string> * url:string

    let inline private mapCoerce f x =
        x |> Option.map f |> Option.defaultValue ""

    let private anchorToMarkdown (Anchor name) =
        sprintf "<a name=\"%s\"></a>" name

    let private headingToMarkdown (Heading (level, anchor', title)) =
        let hashes = String.replicate level "#"
        let anchorMarkdown = anchor' |> mapCoerce anchorToMarkdown
        sprintf "%s %s %s" hashes anchorMarkdown title

    let private linkToMarkdown (Link (name', url)) =
        match name' with
        | Some name -> $"[{name}]({url})"
        | None -> url

    let private appendRule issueIdToUrl (rule:StyleRule) (anchor':option<Anchor>) (builder:StringBuilder) =
        let inline append (str:string) = builder.Append(str) |> ignore
        let inline appendLine (str:string) = builder.AppendLine(str) |> ignore

        let anchorMarkdown =
            match anchor' with
            | Some anchor -> (anchorToMarkdown anchor) + " "
            | None -> ""

        let linkMarkdown = Link (Some "MSDN Link", rule.MsdnLink) |> linkToMarkdown
        sprintf "%s`%s` %s" anchorMarkdown rule.Name linkMarkdown |> appendLine
        "" |> appendLine

        "Selected value:" |> append
        match rule.SelectedValue with
        | Some value -> value |> sprintf " %s" |> append
        | None -> ()
        "\\" |> appendLine
        
        "Issue:" |> append
        match rule.IssueId with
        | Some issueId -> Link (Some issueId, issueIdToUrl issueId) |> linkToMarkdown |> append
        | None -> ()
        "" |> appendLine
        "" |> appendLine

        "Possible values:" |> appendLine
        for value in rule.Values do
            value |> sprintf "* %s" |> appendLine

        "---" |> appendLine
        "" |> appendLine

    let ruleToMarkdown issueIdToLink rule =
        let builder = StringBuilder()
        appendRule issueIdToLink rule None builder
        builder.ToString()

    type private TableOfContentsEntry = {
        Level: int;
        Id: string;
        Title: string; }

    let rec private appendNode appendRule (level:int) (node:DocumentNode) (builder:StringBuilder) =
        match node with
        | Rule rule ->
            let tocEntry = {
                Id = rule.Name;
                Level = level;
                Title = rule.Name; }

            appendRule rule (Some(Anchor(tocEntry.Id))) builder
            [tocEntry]
        | Section (title, childNodes) ->
            let tocEntry = {
                Id = title.Replace(" ", "-").ToLower();
                Level = level;
                Title = title; }

            let heading = Heading(level, Some(Anchor(tocEntry.Id)), title)
            heading |> headingToMarkdown |> builder.AppendLine |> ignore
            builder.AppendLine() |> ignore

            let childTocEntries =
                childNodes
                |> List.collect (fun childNode -> appendNode appendRule (level + 1) childNode builder)
            
            tocEntry::childTocEntries

    let nodeToMarkdown issueIdToLink node =
        let builder = StringBuilder()
        let tocEntries = appendNode (appendRule issueIdToLink) 1 node builder

        let tocBuilder = StringBuilder()
        Heading(1, None, "Table of Contents") |> headingToMarkdown |> tocBuilder.AppendLine |> ignore
        tocBuilder.AppendLine() |> ignore
        for tocEntry in tocEntries do
            let margin = String.replicate (4 * (tocEntry.Level - 1)) "&nbsp;"
            let markdown = sprintf "%s[%s](#%s)\\" margin tocEntry.Title tocEntry.Id
            tocBuilder.AppendLine(markdown) |> ignore

        tocBuilder.Remove(tocBuilder.Length - 3, 1) |> ignore
        tocBuilder.AppendLine() |> ignore

        builder.Insert(0, tocBuilder.ToString()) |> ignore
        builder.ToString()
