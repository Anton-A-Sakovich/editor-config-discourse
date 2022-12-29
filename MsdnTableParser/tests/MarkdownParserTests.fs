namespace EditorconfigDiscourse.MsdnTableParser.Tests
open EditorconfigDiscourse.MsdnTableParser
open NUnit.Framework

module MarkdownParserTests =
    let private titleSectionLine title = sprintf "# %s" title
    let private  ruleSubsubsectionLine rule = sprintf "### %s" rule

    let private  tableHeader =
        seq {
            yield "|     Property     |     Value     |     Description     |"
            yield "|     --------     |     -----     |     -----------     |"
        }

    let private  tableProperty property value =
        let propertyString =
            match property with
            | Some propertyValue -> sprintf "**%s**" propertyValue
            | None -> ""

        sprintf "|  %s  |   %s   |         |" propertyString value

    let private  tableOptionName = tableProperty (Some "Option name")
    let private  tableOptionValues values =
        seq {
            match values with
            | head::tail ->
                    yield tableProperty (Some "Option values") head
                    for value in tail do
                        yield tableProperty None value
            | [] -> yield! Seq.empty
        }

    let private  tableDefaultValue value = tableProperty (Some "Default option value") value

    type RuleTestDefinition =
        { AddRandomProperties: bool;
          AddTextAfterTable: bool;
          Rule: MsdnRule; }

    type PageTestDefinition =
        { Title: string;
          Rules: list<RuleTestDefinition>; }

    let private serializeRule (ruleDefinition:RuleTestDefinition) =
        let { Name = ruleName; Values = ruleValues; DefaultValue = ruleDefaultValue; } = ruleDefinition.Rule
        seq {
            yield ruleSubsubsectionLine ruleName
            yield ""

            yield! tableHeader
            if ruleDefinition.AddRandomProperties then yield tableProperty (Some "Random property 1") "Random value 1"
            yield tableOptionName ruleName
            if ruleDefinition.AddRandomProperties then yield tableProperty (Some "Random property 2") "Random value 2"
            yield! tableOptionValues ruleValues
            if ruleDefinition.AddRandomProperties then yield tableProperty (Some "Random property 3") "Random value 3"
            yield! ruleDefaultValue |> (function
                | Some value -> value |> tableDefaultValue |> Seq.singleton
                | None -> Seq.empty)
            if ruleDefinition.AddRandomProperties then yield tableProperty (Some "Random property 4") "Random value 4"
            yield ""

            if ruleDefinition.AddTextAfterTable then yield "Some text after table."
        }

    let private insertBetween (separator) (sequence:seq<seq<_>>) =
        seq {
            let enumerator = sequence.GetEnumerator()
            if enumerator.MoveNext() then yield! enumerator.Current
            while enumerator.MoveNext() do
                yield separator
                yield! enumerator.Current
        }

    let serializePage (page:PageTestDefinition) =
        seq {
            yield titleSectionLine page.Title
            yield ""

            yield "Some introductory text."
            yield ""

            yield! page.Rules |> List.map serializeRule |> insertBetween ""
        }
        |> String.concat "\r\n"

    type TestDefinition =
        { PageDefinition: PageTestDefinition;
          ExpectedResult: option<MsdnPageContent>; }

[<TestFixture>]
type MarkdownParserTests() =
    let assertDefinition (testDefinition:MarkdownParserTests.TestDefinition) =
        let actual = testDefinition.PageDefinition |> MarkdownParserTests.serializePage |> MarkdownParser.parseMarkdown
        Assert.That(actual, Is.EqualTo testDefinition.ExpectedResult)

    let assertOneRulePageParses addRandomProperties addTextAfterTable hasDefaultValue =
        let title = "Page title"

        let rule =
            { Name = "dotnet_test_rule";
              Values = ["yes"; "no"; "maybe"];
              DefaultValue = if hasDefaultValue then Some "no" else None; }

        let testDefinition:MarkdownParserTests.TestDefinition = {
            PageDefinition = {
                Title = title;
                Rules = [
                    {
                        AddRandomProperties = addRandomProperties;
                        AddTextAfterTable = addTextAfterTable;
                        Rule = rule;
                    }
                ]
            };
            ExpectedResult = Some(
                {
                    Title = title;
                    Rules = [rule];
                }
            )}

        assertDefinition testDefinition

    let assertTwoRulesPageParses
        addRandomPropertiesToRule1 addTextAfterRule1Table rule1HasDefaultValue
        addRandomPropertiesToRule2 addTextAfterRule2Table rule2HasDefaultValue =
        let title = "Page title"

        let rule1 =
            { Name = "dotnet_test_rule";
              Values = ["yes"; "no"; "maybe"];
              DefaultValue = if rule1HasDefaultValue then Some "no" else None; }

        let rule2 =
            { Name = "csharp_test_rule";
              Values = ["foo"; "bar"];
              DefaultValue = if rule2HasDefaultValue then Some "foo" else None; }

        let testDefinition:MarkdownParserTests.TestDefinition = {
            PageDefinition = {
                Title = title;
                Rules = [
                    {
                        AddRandomProperties = addRandomPropertiesToRule1;
                        AddTextAfterTable = addTextAfterRule1Table;
                        Rule = rule1;
                    };
                    {
                        AddRandomProperties = addRandomPropertiesToRule2;
                        AddTextAfterTable = addTextAfterRule2Table;
                        Rule = rule2;
                    }
                ]
            };
            ExpectedResult = Some(
                {
                    Title = title;
                    Rules = [rule1; rule2];
                }
            )}

        assertDefinition testDefinition

    [<Test>]
    member _.OneRule_Parses_NoRandomProperties_NoTextAfterTable_NoDefaultValue() =
        assertOneRulePageParses false false false

    [<Test>]
    member _.OneRule_Parses_NoRandomProperties_NoTextAfterTable_DefaultValue() =
        assertOneRulePageParses false false true

    [<Test>]
    member _.OneRule_Parses_NoRandomProperties_TextAfterTable_NoDefaultValue() =
        assertOneRulePageParses false true false

    [<Test>]
    member _.OneRule_Parses_NoRandomProperties_TextAfterTable_DefaultValue() =
        assertOneRulePageParses false true true

    [<Test>]
    member _.OneRule_Parses_RandomProperties_NoTextAfterTable_NoDefaultValue() =
        assertOneRulePageParses true false false

    [<Test>]
    member _.OneRule_Parses_RandomProperties_NoTextAfterTable_DefaultValue() =
        assertOneRulePageParses true false true

    [<Test>]
    member _.OneRule_Parses_RandomProperties_TextAfterTable_NoDefaultValue() =
        assertOneRulePageParses true true false

    [<Test>]
    member _.OneRule_Parses_RandomProperties_TextAfterTable_DefaultValue() =
        assertOneRulePageParses true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses false false false false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses false false false false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses false false false false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses false false false false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses false false false true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses false false false true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses false false false true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_NoDV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses false false false true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses false false true false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses false false true false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses false false true false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses false false true false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses false false true true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses false false true true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses false false true true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_NoTAT_DV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses false false true true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses false true false false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses false true false false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses false true false false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses false true false false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses false true false true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses false true false true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses false true false true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_NoDV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses false true false true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses false true true false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses false true true false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses false true true false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses false true true false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses false true true true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses false true true true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses false true true true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_NoRP_TAT_DV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses false true true true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses true false false false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses true false false false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses true false false false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses true false false false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses true false false true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses true false false true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses true false false true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_NoDV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses true false false true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses true false true false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses true false true false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses true false true false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses true false true false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses true false true true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses true false true true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses true false true true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_NoTAT_DV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses true false true true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses true true false false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses true true false false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses true true false false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses true true false false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses true true false true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses true true false true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses true true false true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_NoDV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses true true false true true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_NoRP_NoTAT_NoDV() =
        assertTwoRulesPageParses true true true false false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_NoRP_NoTAT_DV() =
        assertTwoRulesPageParses true true true false false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_NoRP_TAT_NoDV() =
        assertTwoRulesPageParses true true true false true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_NoRP_TAT_DV() =
        assertTwoRulesPageParses true true true false true true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_RP_NoTAT_NoDV() =
        assertTwoRulesPageParses true true true true false false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_RP_NoTAT_DV() =
        assertTwoRulesPageParses true true true true false true

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_RP_TAT_NoDV() =
        assertTwoRulesPageParses true true true true true false

    [<Test>]
    member _.TwoRules_Parses_Rule1_RP_TAT_DV_Rule2_RP_TAT_DV() =
        assertTwoRulesPageParses true true true true true true
