namespace EditorconfigDiscourse.Utilities
open System
open System.Runtime.CompilerServices

[<Struct; IsByRefLike; NoComparison; NoEquality>]
type LinesEnumerator =
    val private chars : ReadOnlySpan<char>
    val mutable private lineStart : int
    val mutable private index : int

    new(chars) = { chars = chars; lineStart = 0; index = -1 }

    member this.Current with get() =
        if this.index = -1 || this.index = this.chars.Length + 1 then
            raise (invalidOp "The enumerator has not been started or has been completed.")

        this.chars.Slice(this.lineStart, this.index - this.lineStart)

    member this.MoveNext() =
        if this.index >= this.chars.Length then
            if this.index = this.chars.Length then
                this.index <- this.index + 1
            false
        else
            if this.index = -1 then
                this.index <- this.index + 1

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
