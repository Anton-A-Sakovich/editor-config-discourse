namespace MarkdownUpdater

module YamlParser =
    open System.IO
    open YamlDotNet.RepresentationModel

    type private RequiredBuilder() =
        member _.Bind(value':option<_>, cont) =
            match value' with
            | Some value -> cont value
            | None -> None

        member _.Return(value) = Some value
        member _.ReturnFrom(value') = value'

    let private require = RequiredBuilder()

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

    let rec private foldWhile folder checker state list =
        match list with
        | [] -> state
        | head::newList ->
            match checker state head with
            | Some value ->
                let newState = folder state value
                foldWhile folder checker newState newList
            | None -> state

    let private tryParseScalar (node:YamlNode) =
        match node with
        | :? YamlScalarNode as node' -> node'.Value |> Some
        | _ -> None

    let private tryParseOptionalScalar (node:YamlNode) =
        match node with
        | :? YamlScalarNode as scalarNode ->
            match scalarNode.Value with
            | null | "" -> Some(None)
            | value -> Some(Some value)
        | :? YamlMappingNode as mappingNode ->
            mappingNode["Value"]
            |> tryParseScalar
            |> Option.bind (fun value -> Some(Some value))
        | _ -> None

    let private tryParseSequence parseChild (node:YamlNode) = 
        match node with
        | :? YamlSequenceNode as sequence ->
            seq {
                for child in sequence do
                    yield parseChild child
            }
            |> Some
        | _ -> None

    let rec tryParseRuleNode (node:YamlMappingNode) =
        require {
            let! name = node["Name"] |> tryParseScalar

            let! values = node["Values"] |> tryParseSequence tryParseScalar
            let! values =
                values
                |> List.ofSeq
                |> foldWhile (fun list value -> list @ [value]) (fun _ value' -> value') []
                |> function | [] -> None | list -> Some list
            
            let! defaultValueNode = node["DefaultValue"] |> tryParseOptionalScalar
            let! msdnLink = node["MsdnLink"] |> tryParseScalar

            let rule:StyleRule =
                {
                    Name = name;
                    Values = values;
                    DefaultValue = defaultValueNode;
                    MsdnLink = msdnLink;
                    SelectedValue = None;
                    IssueId = None;
                }

            return rule
        }