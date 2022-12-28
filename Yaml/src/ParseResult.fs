namespace EditorconfigDiscourse.Yaml

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
