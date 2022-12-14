namespace MarkdownUpdater
open MarkdownGenerator

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
        let document =
            DocumentNode.Section ("Section 1", [
                DocumentNode.Rule rule;
                DocumentNode.Section ("Section 2", [
                    DocumentNode.Rule rule;
                    DocumentNode.Rule rule1])
                ])
        
        document |> printNode id |> printfn "%s"

        0