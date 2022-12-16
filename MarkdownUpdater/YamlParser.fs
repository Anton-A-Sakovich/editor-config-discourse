namespace MarkdownUpdater

module YamlParser =
    open YamlDotNet.RepresentationModel

    type private RequireBuilder() =
        member _.Bind(value':option<_>, cont) =
            match value' with
            | Some value -> cont value
            | None -> None

        member _.Return(value) = Some value
        member _.ReturnFrom(value') = value'

    let private require = RequireBuilder()

    type private SwitchBuilder() =
        member _.Return(value) = Some value
        member _.ReturnFrom(value') = value'

        member _.Delay(f) = f
        member _.Run(f) = f ()

        member _.Combine(value':option<_>, cont) =
            match value' with
            | Some _ -> value'
            | None -> cont ()

    let private switch = SwitchBuilder()

    let inline private tryCast< ^b when ^b :> YamlNode> (node:YamlNode) =
        match node with
        | :? ^b as casted -> Some casted
        | _ -> None

    let inline private tryParseAs< ^a, ^b when ^a :> YamlNode> (parse:^a -> option< ^b>) (node:YamlNode) =
        node |> tryCast< ^a> |> Option.bind parse

    let inline private tryGetMappingValue (key:string) (node:YamlMappingNode) =
        try
            Some(node[key])
        with
            | _ -> None

    let inline private tryParseScalar (node:YamlScalarNode) = Some node.Value

    let private tryParseAsOption (node:YamlNode) =
        switch {
            return! node
                |> tryParseAs tryParseScalar
                |> Option.bind ((function | null | "" -> None | value -> Some value) >> Some)

            return! node
                |> tryParseAs (tryGetMappingValue "Value")
                |> Option.bind (tryParseAs tryParseScalar)
                |> Option.bind (Some >> Some)
        }

    let rec private checkChild checkedChildren childrenToCheck =
        match childrenToCheck with
        | [] -> Some checkedChildren
        | childToCheck::rest ->
            match childToCheck with
            | Some child -> checkChild (child::checkedChildren) rest
            | None -> None

    let private tryParseSequence parseChild (node:YamlSequenceNode) = 
        seq {
            for child in node.Children do
                yield parseChild child
        }
        |> List.ofSeq
        |> List.rev
        |> checkChild []

    let tryParseRuleMapping (node:YamlMappingNode) =
        require {
            let inline tryParseAsScalar node = tryParseAs tryParseScalar node
            let inline tryParseAsSequence node =
                tryParseAs (tryParseSequence tryParseAsScalar) node

            let! name = node |> tryGetMappingValue "Name" |> Option.bind tryParseAsScalar
            let! values = node |> tryGetMappingValue "Values" |> Option.bind tryParseAsSequence
            let! defaultValue = node |> tryGetMappingValue "DefaultValue" |> Option.bind tryParseAsOption
            let! msdnLink = node |> tryGetMappingValue "MsdnLink" |> Option.bind tryParseAsScalar

            let rule:StyleRuleMetadata =
                {
                    Name = name;
                    Values = values;
                    DefaultValue = defaultValue;
                    MsdnLink = msdnLink;
                }

            return rule
        }

    let rec tryParseDocumentMapping (node:YamlNode) =
        switch {
            return! require {
                let! mappingNode = node |> tryCast<YamlMappingNode>
                return mappingNode.Children
                    |> Seq.map (fun pair ->
                        let heading = (pair.Key :?> YamlScalarNode).Value
                        MarkdownNode.Section(heading, tryParseDocumentMapping pair.Value))
                    |> List.ofSeq
            }

            return! require {
                let! rules = node |> tryParseAs (tryParseSequence (tryParseAs tryParseRuleMapping))
                return rules |> List.map MarkdownNode.Rule
            }
        }
        |> Option.defaultValue []