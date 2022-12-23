namespace Utilities

module Program =
    open System

    type Program<'T> =
        | Completed of 'T
        | Failed of string * int

    val inline bind : ('T -> Program<'U>) -> Program<'T> -> Program<'U>

    type ProgramBuilder =
        class
            member Bind : Program<'T> * ('T -> Program<'U>) -> Program<'U>
            member Using<'T, 'U when 'T :> IDisposable> : 'T * ('T -> 'U) -> 'U
            member Return : 'T -> Program<'T>
            member ReturnFrom : 'T -> 'T
            member Zero : unit -> Program<unit>
            member Delay : 'T -> 'T
            member Run : (unit -> Program<'T>) -> Program<'T>
        end

    val program : ProgramBuilder

    val run : Program<unit> -> int
