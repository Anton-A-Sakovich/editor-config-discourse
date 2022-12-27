namespace EditorconfigDiscourse.Yaml

module Parsing =
    open System.Collections.Generic
    open YamlDotNet.RepresentationModel

    type ParseResult<'T> =
        | Parsed of 'T
        | Failed

    module ParseResult =
        let inline bind cont (result:ParseResult<_>) =
            match result with
            | Parsed value -> cont value
            | Failed -> Failed

        let inline map f (result:ParseResult<_>) =
            match result with
            | Parsed value -> Parsed (f value)
            | Failed -> Failed

        let inline defaultValue defaultValue (result:ParseResult<_>) =
            match result with
            | Parsed value -> value
            | Failed -> defaultValue

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
