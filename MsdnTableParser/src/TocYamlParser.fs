namespace MsdnTableParser

module TocYamlParser =
    open EditorconfigDiscourse.StyleTree
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

    let inline tryGetValue (node:YamlScalarNode) =
        Success node.Value

    let tryGetItem (key:string) (node:YamlMappingNode) =
        node.Children
        |> Seq.tryPick (fun pair ->
            let pairKeyResult = pair.Key |> tryParseAs<YamlScalarNode> |> bind tryGetValue
            match pairKeyResult with
            | Success pairKey when (pairKey = key) -> Some pair.Value
            | _ -> None)
        |> (function | Some node -> Success node | None -> Failure)

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
                return Page(name, href)
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
