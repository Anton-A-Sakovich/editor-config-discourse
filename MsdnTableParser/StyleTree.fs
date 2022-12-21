namespace MsdnTableParser

type StyleRule =
    { Name: string;
      Values: list<string>;
      DefaultValue: option<string>; }

type StylePage =
    { Title: string;
      Url: string;
      Rules: list<StyleRule>; }

type StyleTree<'T> =
    | Page of 'T
    | Section of string * list<StyleTree<'T>>

module StyleTree =
    let rec map f (tree:StyleTree<_>) =
        match tree with
        | Page value -> Page (f value)
        | Section (name, children) -> Section(name, children |> List.map (map f))

    let rec cat onPage onSection (tree:StyleTree<_>) =
        match tree with
        | Page page -> onPage page
        | Section (name, children) ->
            let convertedChildren = children |> List.map (cat onPage onSection)
            onSection (name, convertedChildren)
