namespace EditorconfigDiscourse.Utilities.Tests
open EditorconfigDiscourse.Utilities
open NUnit.Framework
open System
open System.Runtime.CompilerServices

[<TestFixture>]
module LinesEnumeratorTests =
    type private LinesEnumeratorAction<'T> = delegate of byref<LinesEnumerator> -> 'T

    [<Struct; IsByRefLike; NoComparison; NoEquality>]
    type private TestRunner =
        val mutable private enumerator : LinesEnumerator

        new(text:string) = { enumerator = LinesEnumerator(text.AsSpan()) }

        member this.Assert(action:LinesEnumeratorAction<_>, constr) =
            let actual =
                try
                    Ok (action.Invoke &this.enumerator)
                with
                    | exc -> Error (exc.GetType())

            Assert.That(actual, constr)

        member this.AssertCurrent(value:Result<string, Type>) =
            let action = new LinesEnumeratorAction<_>(fun enumerator -> String enumerator.Current)
            this.Assert(action, Is.EqualTo value)

        member this.AssertMoveNext(value:bool) =
            let action = new LinesEnumeratorAction<_>(fun enumerator -> enumerator.MoveNext())
            let expected:Result<_, Type> = Ok value
            this.Assert(action, Is.EqualTo expected)

    [<TestFixture>]
    type LineBreakAgnosticFixture() =
        [<Test>]
        member _.ThrowsWhenBeforeStart() =
            let mutable runner = TestRunner("Hello")
            runner.AssertCurrent(Error typeof<InvalidOperationException>)

        [<Test>]
        member _.ReturnsSingleLine() =
            let text = "Hello"
            let mutable runner = TestRunner(text)
            runner.AssertMoveNext(true)
            runner.AssertCurrent(Ok text)

        [<Test>]
        member _.ThrowsWhenAfterEnd() =
            let mutable runner = TestRunner("Hello")
            runner.AssertMoveNext(true)
            runner.AssertMoveNext(false)
            runner.AssertCurrent(Error typeof<InvalidOperationException>)

        [<Test>]
        member _.IsEmptyForEmptyString() =
            let mutable runner = TestRunner("")
            runner.AssertMoveNext(false)

    [<TestFixture("\n")>]
    [<TestFixture("\r")>]
    [<TestFixture("\r\n")>]
    type LineBreakDependentFixture(lineBreakString:string) =
        [<Test>]
        member _.IsEmptyForAllLineBreaks() =
            let inputStrings =
                Seq.init 4 (fun i -> i + 1)
                |> Seq.map (fun count -> String.replicate count lineBreakString)

            let assertNoLines inputString =
                let mutable runner = TestRunner(inputString)
                runner.AssertMoveNext(false)

            Assert.Multiple(fun () -> inputStrings |> Seq.iter assertNoLines)

        [<Test>]
        member _.ReturnsSingleLineWhenSurroundedWithLineBreaks() =
            let line = "Hello"

            let inputStrings =
                [| lineBreakString + line;
                   line + lineBreakString;
                   lineBreakString + line + lineBreakString |]

            let assertSingleLine inputString =
                let mutable runner = TestRunner(inputString)
                runner.AssertMoveNext(true)
                runner.AssertCurrent(Ok line)

            Assert.Multiple(fun () -> inputStrings |> Seq.iter assertSingleLine)
