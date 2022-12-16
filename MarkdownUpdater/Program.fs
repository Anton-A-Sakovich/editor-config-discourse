namespace MarkdownUpdater
open MarkdownGenerator
open System
open System.IO
open System.Text
open YamlParser
open YamlDotNet.RepresentationModel

module Program =
    type Program<'T> =
        | Completed of 'T
        | Failed of string * int

    type ProgramBuilder() =
        member _.Bind(program:Program<_>, cont) =
            match program with
            | Completed value -> cont value
            | Failed (message, errorCode) -> Failed (message, errorCode)

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

    [<EntryPoint>]
    let main args =
        program {
            let! rulesFilePath =
                program {
                    if args.Length = 0 then
                        return! Failed ("No file path provided.", 1)
                    else
                        return args[0]
                }

            do! program {
                if rulesFilePath |> File.Exists |> not then
                    return! Failed ("The specified file does not exist.", 2)
            }

            let yamlString = File.ReadAllText(rulesFilePath, Encoding.UTF8)
            use yamlReader = new StringReader(yamlString)
            let yamlStream = YamlStream()
            yamlStream.Load(yamlReader)

            let! rootNode =
                program {
                    if yamlStream.Documents.Count = 0 then
                        return! Failed("Cannot parse the YAML file.", 3)
                    else
                        return yamlStream.Documents[0].RootNode
                }

            let documentNodes = tryParseDocumentMapping rootNode
            let! documentNode = 
                program {
                    if documentNodes |> List.length |> (=) 0 then
                        return! Failed("No YAML documents found in the file.", 4)
                    else
                        return documentNodes |> List.head
                }

            let issueIdToLink =
                if args.Length > 1 then
                    let baseIssuePath = args[1]
                    (fun issueId -> baseIssuePath + issueId)
                else
                    id

            let markdown = nodeToMarkdown issueIdToLink documentNode
            printfn "%s" markdown
            return ()
        }
        |> run