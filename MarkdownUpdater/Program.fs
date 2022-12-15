namespace MarkdownUpdater
open MarkdownGenerator
open System.IO
open YamlParser
open YamlDotNet.RepresentationModel

module Program =
    let rule =
        {
            Name = "Test rule";
            Values = ["true"; "false"];
            DefaultValue = Some "test value";
            MsdnLink = "https://test.io";
            SelectedValue = Some "test selected";
            IssueId = Some "#123";
        }
    
    let rule1 =
        {
            Name = "Test rule 1";
            Values = ["true"; "false"];
            DefaultValue = Some "test value 1";
            MsdnLink = "https://test.io";
            SelectedValue = None;
            IssueId = None;
        }

    [<EntryPoint>]
    let main args =
        use reader = new StringReader(File.ReadAllText(@"C:\Users\Anton.Sakovich\Playground\EditorConfig\rules.yaml"))
        
        let yamlStream = YamlStream()
        yamlStream.Load(reader)

        let rootNode = yamlStream.Documents[0].RootNode
        let documentNode = tryParseDocumentMapping rootNode
        documentNode[0] |> nodeToMarkdown (sprintf "https://%s") |> printfn "%s"

        0