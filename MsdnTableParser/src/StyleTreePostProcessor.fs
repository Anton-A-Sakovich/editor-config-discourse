namespace MsdnTableParser

module StyleTreePostProcessor =
    open System
    open EditorconfigDiscourse.StyleTree

    type private MsdnPageResult =
        | FailedToParse
        | NoRules
        | Ok of StyleTree<MsdnPage>

    let rec private removeDuplicateAndVBRulesLoop (set:Set<string>) (collected:list<MsdnRule>) (remaining:list<MsdnRule>) =
        match remaining with
        | [] -> (collected |> List.rev, set)
        | head::tail ->
            if (set |> Set.contains head.Name) || (head.Name.StartsWith("visual_basic", StringComparison.InvariantCultureIgnoreCase)) then
                removeDuplicateAndVBRulesLoop set collected tail
            else
                removeDuplicateAndVBRulesLoop (set |> Set.add head.Name) (head::collected) tail

    let private removeDuplicateAndVBRules (rules, set) =
       removeDuplicateAndVBRulesLoop set [] rules

    let rec private refineListLoop name (collected:list<StyleTree<MsdnPage>>) (remaining:list<MsdnPageResult>) =
        match remaining with
        | [] ->
            match collected with
            | [] -> NoRules
            | _ -> Ok(Section(name, collected |> List.rev))
        | head'::tail ->
            match head' with
            | FailedToParse -> FailedToParse
            | NoRules -> refineListLoop name collected tail
            | Ok head -> refineListLoop name (head::collected) tail

    let private refineList name results =
        refineListLoop name [] results

    let rec private refineTree set (tree:StyleTree<option<MsdnPage>>) =
        match tree with
        | Page (name, maybePage) ->
            match maybePage with
            | None -> (FailedToParse, set)
            | Some page ->
                let (newRules, newSet) = removeDuplicateAndVBRules (page.Rules, set)
                match newRules with
                | [] -> (NoRules, newSet)
                | _ -> (Ok (Page (name, { page with Rules = newRules; })), newSet)
        | Section (name, children) ->
            let (results, newSet) = children |> List.mapFold refineTree set
            (refineList name results, newSet)

    let refine tree =
        match refineTree Set.empty tree with
        | (Ok tree, _) -> Some tree
        | _ -> None
