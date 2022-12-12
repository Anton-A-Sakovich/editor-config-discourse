namespace MsdnTableParser

type AbortOnExceptionBuilder() =
        member _.Bind(x, f) =
            match x with
            | Result.Ok value ->
                try
                    f value
                with
                    | e -> Result.Error e
            | Result.Error e -> Result.Error e

        member _.Return(x) =
            Result.Ok x

        member _.Delay(f) =
            f

        member _.Run(f) =
            try
                f ()
            with
                | e -> Result.Error e