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

        let {
            Metadata = {
                Name = name;
                Values = values;
                DefaultValue = defaultValue';
                MsdnLink = msdnLink };
            SelectedValue = selectedValue';
            IssueId = issueId'; } = rule

        let anchorMarkdown =
            match anchor' with
            | Some anchor -> (anchorToMarkdown anchor) + " "
            | None -> ""

        let linkMarkdown = Link (Some "MSDN Link", msdnLink) |> linkToMarkdown
        sprintf "%s`%s` %s" anchorMarkdown name linkMarkdown |> appendLine
        "" |> appendLine

        "Selected value:" |> append
        match selectedValue' with
        | Some selectedValue -> selectedValue |> sprintf " %s" |> append
        | None -> ()
        "\\" |> appendLine
        
        "Issue:" |> append
        match issueId' with
        | Some issueId -> Link (Some issueId, issueIdToUrl issueId) |> linkToMarkdown |> append
        | None -> ()
        "" |> appendLine
        "" |> appendLine

        "Possible values:" |> appendLine
        for value in values do
            value |> sprintf "* %s" |> appendLine
        
        match defaultValue' with
        | Some defaultValue ->
            "" |> appendLine
            sprintf "Default value: %s" defaultValue |> appendLine
        | None -> ()

        "---" |> appendLine
        "" |> appendLine

    let ruleToMarkdown issueIdToLink rule =
        let builder = StringBuilder()
        appendRule issueIdToLink rule None builder
        builder.ToString()

    type private TableOfContentsEntry =
        | Rule of id:string * title:string * resolved:bool
        | Section of id:string * title:string * children:list<TableOfContentsEntry> * resolved:int * unresolved:int

    let rec private appendNode appendRule (level:int) (node:MarkdownNode<StyleRule>) (builder:StringBuilder) =
        match node with
        | MarkdownNode.Rule rule ->
            let tocId = rule.Metadata.Name
            appendRule rule (Some(Anchor(tocId))) builder

            Rule(id = tocId, title = rule.Metadata.Name, resolved = (rule.SelectedValue |> Option.isSome))
        | MarkdownNode.Section (title, childNodes) ->
            let tocId = title.Replace(" ", "-").ToLower()
            let heading = Heading(level, Some(Anchor(tocId)), title)
            heading |> headingToMarkdown |> builder.AppendLine |> ignore
            builder.AppendLine() |> ignore

            let childTocEntries =
                childNodes
                |> List.map (fun childNode -> appendNode appendRule (level + 1) childNode builder)

            let (resolved, unresolved) =
                childTocEntries
                |> List.map (function
                    | Rule (_, _, resolved) -> if resolved then (1, 0) else (0, 1)
                    | Section (_, _, _, resolved, unresolved) -> (resolved, unresolved))
                |> List.fold (fun (totalResolved, totalUnresolved) (resolved, unresolved) ->
                    (totalResolved + resolved, totalUnresolved + unresolved)) (0, 0)

            Section(id = tocId, title = title, children = childTocEntries, resolved = resolved, unresolved = unresolved)

    let rec private tocEntryToMarkdown (level:int) (tocEntry:TableOfContentsEntry) (builder:StringBuilder) =
        let inline appendTitle id title resolutionStats =
            let margin = String.replicate (4 * (level - 1)) "&nbsp;"
            sprintf "%s[%s](#%s) %s\\" margin title id resolutionStats |> builder.AppendLine |> ignore

        match tocEntry with
        | Rule(id, title, resolved) ->
            let resolvedString = if resolved then " resolved" else " unresolved"
            appendTitle id title resolvedString
        | Section(id, title, children, resolved, unresolved) ->
            let resolvedString =
                if (resolved + unresolved) = 1 then
                    ""
                else
                    sprintf " resolved %i from %i" resolved (resolved + unresolved)

            appendTitle id title resolvedString
            
            for child in children do
                tocEntryToMarkdown (level + 1) child builder

    let nodeToMarkdown issueIdToLink node =
        let builder = StringBuilder()
        let rootTocEntry = appendNode (appendRule issueIdToLink) 1 node builder

        let tocBuilder = StringBuilder()

        Heading(1, None, "Table of Contents") |> headingToMarkdown |> tocBuilder.AppendLine |> ignore
        tocBuilder.AppendLine() |> ignore

        tocEntryToMarkdown 1 rootTocEntry tocBuilder

        tocBuilder.Remove(tocBuilder.Length - 3, 1) |> ignore
        tocBuilder.AppendLine() |> ignore

        builder.Insert(0, tocBuilder.ToString()) |> ignore
        builder.ToString()
