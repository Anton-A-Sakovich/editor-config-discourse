namespace MsdnTableParser

module StyleTreePostProcessor =
    open EditorconfigDiscourse.StyleTree

    type MsdnPageResult =
        | FailedToParse
        | NoRules
        | Ok of StyleTree<MsdnPage>

    let rec refineList name (collected:list<StyleTree<MsdnPage>>) (remaining:list<MsdnPageResult>) =
        match remaining with
        | [] ->
            match collected with
            | [] -> NoRules
            | _ -> Ok(Section(name, collected |> List.rev))
        | head'::tail ->
            match head' with
            | FailedToParse -> FailedToParse
            | NoRules -> refineList name collected tail
            | Ok head -> refineList name (head::collected) tail

    let rec refineTree (tree:StyleTree<option<MsdnPage>>) =
        match tree with
        | Page (name, page') ->
            match page' with
            | None -> FailedToParse
            | Some {Rules = []} -> NoRules
            | Some page -> Ok(Page(name, page))
        | Section (name, children') ->
            let children = children' |> List.map refineTree
            refineList name [] children

    let refine tree =
        match refineTree tree with
        | Ok tree -> Some tree
        | _ -> None
