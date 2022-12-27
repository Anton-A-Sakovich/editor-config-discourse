namespace EditorconfigDiscourse.StyleTree

module YamlRepresentation =
    open EditorconfigDiscourse.Yaml.Parsing
    open YamlDotNet.RepresentationModel

    let serializeStyleRule (rule:StyleRule) =
        YamlMappingNode(
            YamlScalarNode("Name"), YamlScalarNode(rule.Name),
            YamlScalarNode("Values"), YamlSequenceNode(
                rule.Values |> Seq.map (fun value -> YamlScalarNode(value) :> YamlNode)
            ),
            YamlScalarNode("DefaultValue"), YamlScalarNode(rule.DefaultValue |> Option.defaultValue ""),
            YamlScalarNode("MsdnLink"), YamlScalarNode(rule.MsdnLink)
        )

    let tryParseStyleRule (node:YamlNode) =
        parse {
            let! mapping = node |> tryParseAs<YamlMappingNode>

            let! name =
                mapping |> tryGetItem "Name"
                |> ParseResult.bind tryParseAs<YamlScalarNode>
                |> ParseResult.map getValue

            let! values =
                mapping |> tryGetItem "Values"
                |> ParseResult.bind tryParseAs<YamlSequenceNode>
                |> ParseResult.bind (tryParseSequence tryParseAs<YamlScalarNode>)
                |> ParseResult.map (List.map getValue)

            let! defaultValue =
                mapping |> tryGetItem "DefaultValue"
                |> ParseResult.bind tryParseAs<YamlScalarNode>
                |> ParseResult.map getValue
                |> ParseResult.map (function "" -> None | s -> Some s)

            let! msdnLink =
                mapping |> tryGetItem "MsdnLink"
                |> ParseResult.bind tryParseAs<YamlScalarNode>
                |> ParseResult.map getValue

            let styleRule:StyleRule =
                { Name = name;
                  Values = values;
                  DefaultValue = defaultValue;
                  MsdnLink = msdnLink; }

            return styleRule
        }
