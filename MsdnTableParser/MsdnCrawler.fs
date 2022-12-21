namespace MsdnTableParser

module MsdnCrawler =
    open YamlDotNet.RepresentationModel

    type ParseResult<'T> =
        | Success of 'T
        | Failure

    let inline bind cont (result:ParseResult<_>) =
        match result with
        | Success value -> cont value
        | Failure -> Failure

    type ParseBuilder() =
        member inline _.Bind(result, cont) = bind cont result
        member inline _.Return(value) = Success value
        member inline _.ReturnFrom(result) = result

    let parse = ParseBuilder()

    type TocEntry =
        | Page of name:string * href:string
        | Section of name:string * items:list<TocEntry>

    let inline tryParseAs< ^T when ^T :> YamlNode> (node:YamlNode) =
        match node with | :? ^T as casted -> Success casted | _ -> Failure

    let inline tryGetItem (key:string) (node:YamlMappingNode) =
        try Success node[key] with | _ -> Failure

    let inline tryGetValue (node:YamlScalarNode) =
        Success node.Value

    let rec tryParseMappingNode (node:YamlMappingNode) =
        parse {
            let! name = node |> tryGetItem "name" |> bind tryParseAs<YamlScalarNode> |> bind tryGetValue
            let hrefResult = node |> tryGetItem "href" |> bind tryParseAs<YamlScalarNode> |> bind tryGetValue
            let itemsResult = node |> tryGetItem "items" |> bind tryParseAs<YamlSequenceNode>

            match (hrefResult, itemsResult) with
            | (Success href, _) ->
                return Page(name, href)
            | (_, Success items) ->
                let children =
                    items.Children
                    |> Seq.map (tryParseAs<YamlMappingNode> >> (bind tryParseMappingNode))
                    |> Seq.choose (function | Success value -> Some value | Failure -> None)
                    |> List.ofSeq

                return Section(name, children)
            | _ ->
                return! Failure
        }
