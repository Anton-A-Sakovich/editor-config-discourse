namespace EditorconfigDiscourse.StyleTree

module YamlRepresentation =
    open EditorconfigDiscourse.Yaml
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

    let rec private addToYaml converter (tree:StyleTree<_>) (parent:YamlMappingNode) =
        match tree with
        | Page (name, leaf) ->
            let leafNode:#YamlNode = converter leaf
            parent.Add(name, leafNode)
        | Section (name, children) ->
            let childrenNode = YamlMappingNode()

            for child in children do
                addToYaml converter child childrenNode

            parent.Add(name, childrenNode)

    let toYaml converter tree =
        let rootNode = YamlMappingNode()
        addToYaml converter tree rootNode
        rootNode

    let private transposeParseResults (list:list<ParseResult<_>>) =
        let rec loop remaining collected =
            match remaining with
            | [] -> Parsed (List.rev collected)
            | head::tail ->
                match head with
                | Parsed value -> loop tail (value::collected)
                | Failed -> Failed

        loop list []

    let rec private fromYamlLoop leafParser (node:YamlNode) =
        match leafParser node with
        | Parsed leaf -> fun name -> Parsed(Page(name, leaf))
        | Failed ->
            match node with
            | :? YamlMappingNode as mappingNode ->
                fun name ->
                    mappingNode.Children
                    |> Seq.map (fun pair ->
                        pair.Key
                        |> tryParseAs<YamlScalarNode>
                        |> ParseResult.map getValue
                        |> ParseResult.bind (fromYamlLoop leafParser pair.Value))
                    |> List.ofSeq
                    |> transposeParseResults
                    |> (function
                        | Parsed trees -> Parsed(Section(name, trees))
                        | Failed -> Failed)
            | _ -> fun _ -> Failed

    let fromYaml converter (root:YamlMappingNode) =
        let singleChild = Seq.tryExactlyOne root.Children
        match singleChild with
        | Some pair ->
            pair.Key
            |> tryParseAs<YamlScalarNode>
            |> ParseResult.map getValue
            |> ParseResult.bind (fromYamlLoop converter pair.Value)
        | None -> fromYamlLoop converter root "Root"
