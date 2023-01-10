namespace EditorconfigDiscourse.MarkdownUpdater.Tests
open EditorconfigDiscourse.MarkdownUpdater
open NUnit.Framework

[<TestFixture>]
type EditorconfigParserTests() =
    [<Test>]
    member _.ParsesEmptyStringToEmptySet() =
        Assert.That(EditorconfigParser.parseEditorconfig "", Is.EqualTo Map.empty)

    [<Test>]
    member _.ParsesKeyValuePair() =
        let inputStrings =
            [| "ident_size=4"; "ident_size =4"; "ident_size= 4"; "ident_size = 4"; |]

        let expectedRule:EditorconfigRule =
            { Name = "ident_size"; Value = "4"; IssueId = None; }

        let assertInputString inputString =
            let rulesMap = EditorconfigParser.parseEditorconfig inputString
            Assert.That(Map.values rulesMap, Is.EquivalentTo [| expectedRule; |])

        Array.iter assertInputString inputStrings

    [<Test>]
    member _.ParsesKeyValuePairWithComent() =
        let inputStrings =
            [|"#\r\nident_size = 4";
              "# Comment\r\nident_size = 4";
              "#(1) Comment\r\nident_size = 4";
              "#(1 Comment\r\nident_size = 4"; |]

        let baseRule:EditorconfigRule =
            { Name = "ident_size"; Value = "4"; IssueId = None; }

        let expectedRules =
            [| baseRule;
               baseRule;
               { baseRule with IssueId = Some "1"; };
               baseRule; |]

        let assertInputString inputString expectedRule =
            let rulesMap = EditorconfigParser.parseEditorconfig inputString
            Assert.That(Map.values rulesMap, Is.EquivalentTo [| expectedRule; |])

        Array.iter2 assertInputString inputStrings expectedRules
