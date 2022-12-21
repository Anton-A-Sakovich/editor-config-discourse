namespace MsdnTableParser

module MsdnCrawler =
    open YamlDotNet.RepresentationModel

    type ParseResult<'T> =
        | Success of 'T
        | Failure

    val inline bind : ('T -> ParseResult<'U>) -> ParseResult<'T> -> ParseResult<'U>

    type ParseBuilder =
        class
            member inline Bind : ParseResult<'T> * ('T -> ParseResult<'U>) -> ParseResult<'U>
            member inline Return : 'T -> ParseResult<'T>
            member inline ReturnFrom : 'T -> 'T
        end

    val parse : ParseBuilder

    type TocEntry =
        | Page of name:string * href:string
        | Section of name:string * items:list<TocEntry>

    val tryParseMappingNode : YamlMappingNode -> ParseResult<TocEntry>
