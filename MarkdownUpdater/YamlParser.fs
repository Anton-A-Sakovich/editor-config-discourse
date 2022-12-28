namespace MarkdownUpdater

module YamlParser =
    open EditorconfigDiscourse.StyleTree.YamlRepresentation
    open EditorconfigDiscourse.Yaml.Parsing
    open YamlDotNet.RepresentationModel

    let tryParseRules (node:YamlNode) =
        node
        |> tryParseAs<YamlSequenceNode>
        |> ParseResult.bind (tryParseSequence tryParseStyleRule)
