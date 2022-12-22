namespace MsdnTableParser

module TocYamlParser =
    open YamlDotNet.RepresentationModel

    type ParseResult<'T> =
        | Success of 'T
        | Failure

    let inline bind cont (result:ParseResult<_>) =
        match result with
        | Success value -> cont value
        | Failure -> Failure

    let inline defaultValue defValue (result:ParseResult<_>) =
        match result with
        | Success value -> value
        | Failure _ -> defValue

    type ParseBuilder() =
        member inline _.Bind(result, cont) = bind cont result
        member inline _.Return(value) = Success value
        member inline _.ReturnFrom(result) = result

    let parse = ParseBuilder()

    let inline tryParseAs< ^T when ^T :> YamlNode> (node:YamlNode) =
        match node with | :? ^T as casted -> Success casted | _ -> Failure

    let inline tryGetItem (key:string) (node:YamlMappingNode) =
        try Success node[key] with | _ -> Failure

    let inline tryGetValue (node:YamlScalarNode) =
        Success node.Value

    type TocPage =
        { Name: string;
          Href: string; }

    let rec tryParse (node:YamlNode) =
        parse {
            let! node = node |> tryParseAs<YamlMappingNode>
            let nameResult = node |> tryGetItem "name" |> bind tryParseAs<YamlScalarNode> |> bind tryGetValue
            let hrefResult = node |> tryGetItem "href" |> bind tryParseAs<YamlScalarNode> |> bind tryGetValue
            let itemsResult = node |> tryGetItem "items" |> bind tryParseAs<YamlSequenceNode>

            match (nameResult, hrefResult, itemsResult) with
            | (Success name, Success href, _) ->
                return Page({ Name = name; Href = href; })
            | (_, _, Success items) ->
                let name = nameResult |> defaultValue "Root"

                let children =
                    items.Children
                    |> Seq.map (tryParseAs<YamlMappingNode> >> (bind tryParse))
                    |> Seq.choose (function | Success value -> Some value | Failure -> None)
                    |> List.ofSeq

                return Section(name, children)
            | _ ->
                return! Failure
        }

    let rec tryFind (path:list<string>) (tree:StyleTree<TocPage>) =
        match (path, tree) with
        | ([], _) -> Some tree

        | ([segment], _) ->
            let name =
                match tree with
                | Page page -> page.Name
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
