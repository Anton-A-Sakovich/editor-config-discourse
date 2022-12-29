namespace EditorconfigDiscourse.MsdnTableParser.Tests
open EditorconfigDiscourse.MsdnTableParser
open NUnit.Framework

[<TestFixture>]
type MarkdownParserTests() =
    [<Test>]
    member _.ParsesValidPage() =
        let pageUrl = "page_url"

        let pageText = """
# Page title

Some introductory text.

### dotnet_test_rule

|     Property     |     Value     |     Description     |
|     --------     |     -----     |     -----------     |
|     **Option name**     |  dotnet_test_rule  |         |
|  **Random property 1**  |   random value 1   |         |
|     **Option name**     |  dotnet_test_rule  |         |
|    **Option values**    |        yes         |         |
|                         |        no          |         |
|                         |       maybe        |         |
|  **Random property 1**  |   random value 2   |         |
| **Default option value**|        yes         |         |
"""

        let actual = MarkdownParser.parseMarkdown pageUrl pageText
        let expected:option<MsdnPage> =
            { Title = "Page title";
              Url = "page_url";
              Rules = [
                { Name = "dotnet_test_rule";
                  Values = ["yes"; "no"; "maybe"];
                  DefaultValue = Some "yes"; }
              ]; }
            |> Some

        Assert.That(actual, Is.EqualTo expected)
