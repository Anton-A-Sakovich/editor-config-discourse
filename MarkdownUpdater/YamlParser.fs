namespace MarkdownUpdater

module YamlParser =
    open System.Collections.Generic
    open YamlDotNet.RepresentationModel

    let inline tryCast< ^T when ^T :> YamlNode> (node:YamlNode) =
        match node with
        | :? ^T as casted -> Some casted
        | _ -> None

    let tryGet (key:string) (node:YamlMappingNode) =
        node.Children
        |> Seq.tryFind (fun pair ->
            pair.Key
            |> tryCast<YamlScalarNode>
            |> Option.map (fun node -> node.Value = key)
            |> Option.defaultValue false)
        |> Option.map (fun pair -> pair.Value)

    let rec tryParseChildren (parsed:List<StyleRule>) (enumarator:IEnumerator<YamlNode>) =
        if enumarator.MoveNext() then
            match enumarator.Current with
            | :? YamlMappingNode as mappingNode ->
                mappingNode
                |> tryGet "Name"
                |> Option.bind (fun name)

    let tryParseNode (node:YamlNode) =
        match node with
        | :? YamlSequenceNode as sequence ->
            Some sequence.Children
        | _ -> None
