namespace MsdnTableParser

module TocYamlParser =
    open EditorconfigDiscourse.StyleTree
    open EditorconfigDiscourse.Yaml
    open EditorconfigDiscourse.Yaml.Parsing
    open YamlDotNet.RepresentationModel

    let rec tryParse (node:YamlNode) =
        parse {
            let! node = node |> tryParseAs<YamlMappingNode>
            let nameResult = node |> tryGetItem "name" |> ParseResult.bind tryParseAs<YamlScalarNode> |> ParseResult.map getValue
            let hrefResult = node |> tryGetItem "href" |> ParseResult.bind tryParseAs<YamlScalarNode> |> ParseResult.map getValue
            let itemsResult = node |> tryGetItem "items" |> ParseResult.bind tryParseAs<YamlSequenceNode>

            match (nameResult, hrefResult, itemsResult) with
            | (Parsed name, Parsed href, _) ->
                return Page(name, href)
            | (_, _, Parsed items) ->
                let name = nameResult |> ParseResult.defaultValue "Root"

                let children =
                    items.Children
                    |> Seq.map (tryParseAs<YamlMappingNode> >> (ParseResult.bind tryParse))
                    |> Seq.choose (function | Parsed value -> Some value | Failed -> None)
                    |> List.ofSeq

                return Section(name, children)
            | _ ->
                return! Failed
        }
