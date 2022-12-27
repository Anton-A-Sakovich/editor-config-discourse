namespace MsdnTableParser

module TocYamlParser =
    open EditorconfigDiscourse.StyleTree
    open YamlDotNet.RepresentationModel

    type ParseResult<'T> =
        | Success of 'T
        | Failure

    val inline bind : ('T -> ParseResult<'U>) -> ParseResult<'T> -> ParseResult<'U>

    val inline defaultValue : 'T -> ParseResult<'T> -> 'T

    type ParseBuilder =
        class
            member inline Bind : ParseResult<'T> * ('T -> ParseResult<'U>) -> ParseResult<'U>
            member inline Return : 'T -> ParseResult<'T>
            member inline ReturnFrom : 'T -> 'T
        end

    val parse : ParseBuilder

    val tryParse : YamlNode -> ParseResult<StyleTree<string>>
