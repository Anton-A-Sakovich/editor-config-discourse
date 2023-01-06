namespace EditorconfigDiscourse.Utilities
open System
open System.Runtime.CompilerServices

[<Struct; IsByRefLike; NoComparison; NoEquality>]
type LinesEnumerator =
    val private chars : ReadOnlySpan<char>
    val mutable private lineStart : int
    val mutable private index : int

    new(chars) = { chars = chars; lineStart = 0; index = 0 }

    member this.Current with get() =
        this.chars.Slice(this.lineStart, this.index - this.lineStart)

    member this.MoveNext() =
        while this.index < this.chars.Length && (this.chars[this.index] = '\r' || this.chars[this.index] = '\n') do
            this.index <- this.index + 1

        if this.index = this.chars.Length then
            false
        else
            this.lineStart <- this.index
            while this.index < this.chars.Length && (this.chars[this.index] <> '\r' && this.chars[this.index] <> '\n') do
                this.index <- this.index + 1
            true

[<NoComparison; NoEquality>]
type EnumeratedLines(text:string) =
    member _.GetEnumerator() = LinesEnumerator(text.AsSpan())
