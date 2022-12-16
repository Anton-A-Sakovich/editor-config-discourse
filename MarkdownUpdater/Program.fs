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
        let inline requireArg failure index =
            program {
                if args.Length > index then
                    return args[index]
                else
                    return! failure
            }

        program {
            let! rulesYamlFilePath = requireArg (Failed ("No YAML file path provided.", 1)) 0
            let! rulesMarkdownFilePath = requireArg (Failed ("No Markdown file path provided.", 1)) 1

            let issueIdToLink =
                if args.Length > 2 then
                    let baseIssuePath = args[2]
                    (fun issueId -> baseIssuePath + issueId)
                else
                    id

            do! program {
                if rulesYamlFilePath |> File.Exists |> not then
                    return! Failed ("The specified file does not exist.", 2)
            }

            let encoding = UTF8Encoding(false)
            let yamlString = File.ReadAllText(rulesYamlFilePath, encoding)
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

            let editorconfigRules = Map.empty<string, EditorconfigRule>
            let mergedDocumentNode = Merger.mergeConfigIntoMarkdownNode editorconfigRules documentNode

            let markdown = nodeToMarkdown issueIdToLink mergedDocumentNode
            File.WriteAllText(rulesMarkdownFilePath, markdown, encoding)

            return ()
        }
        |> run