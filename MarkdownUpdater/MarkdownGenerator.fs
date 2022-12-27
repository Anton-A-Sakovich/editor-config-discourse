namespace MarkdownUpdater

module MarkdownGenerator =
    open EditorconfigDiscourse.StyleTree
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

    let private appendResolution issueIdToUrl (resolution:StyleRuleResolution) (anchor':option<Anchor>) (builder:StringBuilder) =
        let inline append (str:string) = builder.Append(str) |> ignore
        let inline appendLine (str:string) = builder.AppendLine(str) |> ignore

        let {
            Rule = {
                Name = name;
                Values = values;
                DefaultValue = defaultValue';
                MsdnLink = msdnLink };
            SelectedValue = selectedValue';
            IssueId = issueId'; } = resolution

        let anchorMarkdown =
            match anchor' with
            | Some anchor -> (anchorToMarkdown anchor) + " "
            | None -> ""

        let linkMarkdown = Link (Some "MSDN Link", msdnLink) |> linkToMarkdown
        sprintf "%s`%s` %s" anchorMarkdown name linkMarkdown |> appendLine
        "" |> appendLine

        "Selected value:" |> append
        match selectedValue' with
        | Some selectedValue -> selectedValue |> sprintf " `%s`" |> append
        | None -> ()
        "\\" |> appendLine

        "Issue:" |> append
        match issueId' with
        | Some issueId -> Link (Some issueId, issueIdToUrl issueId) |> linkToMarkdown |> sprintf " %s" |> append
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

        "" |> appendLine
        "---" |> appendLine
        "" |> appendLine

    let ruleToMarkdown issueIdToLink rule =
        let builder = StringBuilder()
        appendResolution issueIdToLink rule None builder
        builder.ToString()

    type TableOfContentsReference = { Id: string; Title: string; }

    type TableOfContentsTree =
        | Resolution of reference:TableOfContentsReference * resolved:bool
        | Section of reference:TableOfContentsReference * resolved:int * total:int * children:list<TableOfContentsTree>

    let sumTree (tree:TableOfContentsTree) =
        match tree with
        | Resolution (_, resolved) -> if resolved then (1, 1) else (0, 1)
        | Section(_, resolved, total, _) -> (resolved, total)

    let rec appendTree issueIdToUrl (level:int) (builder:StringBuilder) (tree:StyleTree<list<StyleRuleResolution>>) =
        match tree with
        | Page (name, resolutions) ->
            let childReferences =
                resolutions
                |> List.map (fun resolution ->
                    let reference:TableOfContentsReference =
                        { Id = resolution.Rule.Name; Title = resolution.Rule.Name; }
                    let resolved =
                        resolution.SelectedValue |> Option.isSome
                    reference , resolved)

            let childTrees:list<TableOfContentsTree> =
                childReferences
                |> List.map Resolution

            let resolved =
                resolutions
                |> List.map (fun resolution -> resolution.SelectedValue)
                |> List.map (function | Some _ -> 1 | None -> 0)
                |> List.sum

            let total = resolutions |> List.length

            let thisReference:TableOfContentsReference =
                { Id = name.Replace(" ", "-").ToLower(); Title = name; }

            Heading(level, Some(Anchor(thisReference.Id)), thisReference.Title)
            |> headingToMarkdown
            |> builder.AppendLine
            |> ignore

            for (resolution, (reference, _)) in Seq.zip resolutions childReferences do
                appendResolution issueIdToUrl resolution (Some(Anchor(reference.Id))) builder

            Section(thisReference, resolved, total, childTrees)

        | StyleTree.Section (name, children) ->
            let childTrees = children |> List.map (appendTree issueIdToUrl (level + 1) builder)

            let (resolved, total) =
                childTrees
                |> List.map sumTree
                |> List.fold (fun (r, t) (r', t') -> (r + r', t + t')) (0, 0)

            let thisReference:TableOfContentsReference =
                { Id = name.Replace(" ", "-").ToLower(); Title = name; }

            Heading(level, Some(Anchor(thisReference.Id)), thisReference.Title)
            |> headingToMarkdown
            |> builder.AppendLine
            |> ignore

            Section(thisReference, resolved, total, childTrees)

    let rec private tocTreeToMarkdown (level:int) (builder:StringBuilder) (tree:TableOfContentsTree) =
        let inline appendTitle (reference:TableOfContentsReference) resolutionStats =
            let margin = String.replicate (4 * (level - 1)) "&nbsp;"
            sprintf "%s[%s](#%s) %s\\" margin reference.Title reference.Id resolutionStats |> builder.AppendLine |> ignore

        match tree with
        | Resolution (reference, resolved) ->
            let resolvedString = if resolved then " resolved" else " unresolved"
            appendTitle reference resolvedString
        | Section (reference, resolved, total, children) ->
            let resolvedString =
                if total = 1 then
                    ""
                else
                    sprintf " resolved %i from %i" resolved total

            appendTitle reference resolvedString

            for child in children do
                tocTreeToMarkdown (level + 1) builder child

    let nodeToMarkdown issueIdToLink node =
        let builder = StringBuilder()
        let tocRoot = appendTree issueIdToLink 1 builder node

        let tocBuilder = StringBuilder()
        Heading(1, None, "Table of Contents") |> headingToMarkdown |> tocBuilder.AppendLine |> ignore
        tocBuilder.AppendLine() |> ignore

        tocTreeToMarkdown 1 tocBuilder tocRoot

        tocBuilder.Remove(tocBuilder.Length - 3, 1) |> ignore
        tocBuilder.AppendLine() |> ignore

        builder.Insert(0, tocBuilder.ToString()) |> ignore
        builder.ToString()
