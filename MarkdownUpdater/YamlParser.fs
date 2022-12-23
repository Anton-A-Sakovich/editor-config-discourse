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
        require {
            let! mappingNode = node |> tryCast<YamlMappingNode>

            let hasName =
                mappingNode.Children
                |> Seq.exists (fun pair -> pair.Key |> (tryParseAs tryParseScalar) |> Option.map (fun name -> name = "Name") |> Option.defaultValue false)

            if hasName then
                let! rule = mappingNode |> tryParseRuleMapping
                return MarkdownNode.Rule(rule)
            else
                let! firstPair = mappingNode.Children |> Seq.tryHead
                let! name = firstPair.Key |> tryParseAs tryParseScalar
                let! children = firstPair.Value |> tryParseAs (tryParseSequence tryParseDocumentMapping)
                return MarkdownNode.Section(name, children)
        }
