namespace EditorconfigDiscourse.StyleTree

type StyleTree<'T> =
    | Page of string * 'T
    | Section of string * list<StyleTree<'T>>

module StyleTree =
    let rec map f (tree:StyleTree<_>) =
        match tree with
        | Page (name, value) -> Page (name, f value)
        | Section (name, children) -> Section(name, children |> List.map (map f))

    let rec cat onPage onSection (tree:StyleTree<_>) =
        match tree with
        | Page (name, value) -> onPage (name, value)
        | Section (name, children) ->
            let children' = children |> List.map (cat onPage onSection)
            onSection (name, children')

    let rec tryFind (path:list<string>) (tree:StyleTree<_>) =
        match (path, tree) with
        | ([], _) -> Some tree

        | ([segment], _) ->
            let name =
                match tree with
                | Page (name, _) -> name
                | Section (name, _) -> name

            if segment = name then
                Some tree
            else
                None

        | (segment::rest, Section(name, children)) ->
            if segment = name then
                Seq.tryPick (tryFind rest) children
            else
                None

        | (_, _) -> None
