namespace EditorconfigDiscourse.Utilities

module Program =
    open System

    type Program<'T> =
        | Completed of 'T
        | Failed of string * int

    module Program =
        let inline bind cont (program:Program<_>) =
            match program with
            | Completed value -> cont value
            | Failed (message, errorCode) -> Failed (message, errorCode)

    type ProgramBuilder() =
        member _.Bind(program:Program<_>, cont) =
            Program.bind cont program

        member _.Using(resource:#IDisposable, cont) =
            try
                cont resource
            finally
                resource.Dispose()

        member _.Return(result) = Completed result
        member _.ReturnFrom(program) = program
        member _.Zero() = Completed ()

        member _.Delay(f) = f
        member _.Run(f) =
            try f () with | exc -> Failed (exc.Message |> sprintf "%s", 16)

    let program = ProgramBuilder()

    let run (program:Program<_>) =
        match program with
        | Completed () -> 0
        | Failed (message, errorCode) ->
            printfn "%s" message
            errorCode
