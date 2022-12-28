namespace EditorconfigDiscourse.MarkdownUpdater
open EditorconfigDiscourse.StyleTree
open EditorconfigDiscourse.Utilities.Program
open EditorconfigDiscourse.Yaml
open EditorconfigDiscourse.Yaml.Parsing
open System.IO
open System.Text
open YamlDotNet.RepresentationModel

module Program =
    [<EntryPoint>]
    let main args =
        let inline requireArg failure index =
            program {
                if args.Length > index then
                    return args[index]
                else
                    return! failure
            }

        let inline requireFile message path =
            program {
                if File.Exists(path) then
                    return ()
                else
                    return! Program.Failed (message, 2)
            }

        program {
            let! rulesYamlFilePath = requireArg (Program.Failed ("No YAML file path provided.", 1)) 0
            let! editorconfigFilePath = requireArg (Program.Failed ("No .editorconfig file path provided", 1)) 1
            let! rulesMarkdownFilePath = requireArg (Program.Failed ("No Markdown file path provided.", 1)) 2

            let issueIdToLink =
                if args.Length > 3 then
                    let baseIssuePath = args[3]
                    (fun issueId -> baseIssuePath + issueId)
                else
                    id

            do! requireFile "The YAML file does not exist." rulesYamlFilePath
            do! requireFile "The .editorconfig file does not exist." editorconfigFilePath

            let encoding = UTF8Encoding(false)
            let yamlString = File.ReadAllText(rulesYamlFilePath, encoding)
            use yamlReader = new StringReader(yamlString)
            let yamlStream = YamlStream()
            yamlStream.Load(yamlReader)

            let! rootNode =
                program {
                    if yamlStream.Documents.Count = 0 then
                        return! Program.Failed("Cannot parse the YAML file.", 3)
                    else
                        return yamlStream.Documents[0].RootNode
                }

            let! documentNode =
                rootNode
                |> tryParseAs<YamlMappingNode>
                |> ParseResult.bind (YamlRepresentation.fromYaml YamlParser.tryParseRules)
                |> (function | ParseResult.Parsed value -> Program.Completed value | ParseResult.Failed -> Program.Failed ("Failed to build sections tree from the YAML", 4))

            let editorconfigString = File.ReadAllText(editorconfigFilePath, encoding)
            let editorconfigRules = EditorconfigParser.parseEditorconfig editorconfigString
            let mergedDocumentNode = Merger.createResolutions editorconfigRules documentNode

            let markdown = MarkdownGenerator.nodeToMarkdown issueIdToLink mergedDocumentNode
            File.WriteAllText(rulesMarkdownFilePath, markdown, encoding)

            return ()
        }
        |> run
