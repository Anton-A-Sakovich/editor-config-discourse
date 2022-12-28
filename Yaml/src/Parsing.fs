namespace EditorconfigDiscourse.Yaml

module Parsing =
    open System.Collections.Generic
    open YamlDotNet.RepresentationModel

    type ParseBuilder() =
        member inline _.Bind(result, cont) = ParseResult.bind cont result
        member inline _.Return(value) = Parsed value
        member inline _.ReturnFrom(result) = result

    let parse = ParseBuilder()

    let inline tryParseAs< ^TNode when ^TNode :> YamlNode> (node:YamlNode) =
        match node with
        | :? ^TNode as casted -> Parsed casted
        | _ -> Failed

    let inline tryGetItem (key:string) (mapping:YamlMappingNode) =
        match mapping.Children.TryGetValue(key) with
        | (true, node) -> Parsed node
        | (false, _) -> Failed

    let inline getValue (scalar:YamlScalarNode) =
        scalar.Value

    let tryParseSequence parser (sequence:seq<YamlNode>) =
        let rec loop (parsedValues:List<_>) (enumerator:IEnumerator<YamlNode>) =
            if enumerator.MoveNext() then
                let parseResult:ParseResult<_> = parser enumerator.Current
                match parseResult with
                | Parsed value ->
                    parsedValues.Add(value)
                    loop parsedValues enumerator
                | Failed -> Failed
            else
                Parsed (parsedValues |> List.ofSeq)
        loop (List<_>()) (sequence.GetEnumerator())
