namespace MarkdownUpdater

module YamlParser =
    open System.IO
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

    let inline tryCast< ^b when ^b :> YamlNode> (value:YamlNode) =
        match value with
        | :? ^b as casted -> Some casted
        | _ -> None

    let inline tryGetValue (key:string) (node:YamlMappingNode) =
        try
            Some(node[key])
        with
            | _ -> None

    let private tryParseScalar (node:YamlNode) =
        require {
            let! node' = node |> tryCast<YamlScalarNode>
            return node'.Value
        }

    let private tryParseOptionalScalar (node:YamlNode) =
        switch {
            return! require {
                let! scalarNode = node |> tryCast<YamlScalarNode>
                match scalarNode.Value with
                | null | "" -> return None
                | value -> return Some value
            }

            return! require {
                let! mappingNode = node |> tryCast<YamlMappingNode>
                let! valueNode = mappingNode |> tryGetValue "Value"
                let! valueNode' = valueNode |> tryCast<YamlScalarNode>
                return Some valueNode'.Value
            }
        }

    let rec private checkChild checkedChildren childrenToCheck =
        match childrenToCheck with
        | [] -> Some checkedChildren
        | childToCheck::rest ->
            match childToCheck with
            | Some child -> checkChild (child::checkedChildren) rest
            | None -> None

    let private tryParseSequence parseChild (node:YamlNode) = 
        require {
            let! sequenceNode = node |> tryCast<YamlSequenceNode>
            return!
                seq {
                    for child in sequenceNode.Children do
                        yield parseChild child
                }
                |> List.ofSeq
                |> List.rev
                |> checkChild []
        }

    let tryParseRuleNode (node:YamlMappingNode) =
        require {
            let! name = node |> tryGetValue "Name" |> Option.bind tryParseScalar
            let! values = node |> tryGetValue "Values" |> Option.bind (tryParseSequence tryParseScalar)
            let! defaultValue = node |> tryGetValue "DefaultValue" |> Option.bind tryParseOptionalScalar
            let! msdnLink = node |> tryGetValue "MsdnLink" |> Option.bind tryParseScalar

            let rule:StyleRule =
                {
                    Name = name;
                    Values = values;
                    DefaultValue = defaultValue;
                    MsdnLink = msdnLink;
                    SelectedValue = None;
                    IssueId = None;
                }

            return rule
        }

    let rec tryParseRootNode (node:YamlNode) =
        switch {
            return! require {
                let! mappingNode = node |> tryCast<YamlMappingNode>
                return mappingNode.Children
                    |> Seq.map (fun pair ->
                        let heading = (pair.Key :?> YamlScalarNode).Value
                        DocumentNode.Section(heading, tryParseRootNode pair.Value))
                    |> List.ofSeq
            }

            return! require {
                let! rules = node |> tryParseSequence (tryCast<YamlMappingNode> >> (Option.bind tryParseRuleNode))
                return rules |> List.map DocumentNode.Rule
            }
        }
        |> (function | Some list -> list | None -> [])