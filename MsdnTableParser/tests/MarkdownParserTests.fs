namespace EditorconfigDiscourse.MsdnTableParser.Tests
open EditorconfigDiscourse.MsdnTableParser
open NUnit.Framework

[<TestFixture>]
type MarkdownParserTests() =
    [<Test>]
    member _.ParsesValidPageWithOneRuleWithDefaultValue() =
        let pageUrl = "page_url"

        let pageText = """
# Page title

Some introductory text.

### dotnet_test_rule

|     Property     |     Value     |     Description     |
|     --------     |     -----     |     -----------     |
|  **Random property 1**  |   random value 1   |         |
|     **Option name**     |  dotnet_test_rule  |         |
|  **Random property 2**  |   random value 2   |         |
|    **Option values**    |        yes         |         |
|                         |        no          |         |
|                         |       maybe        |         |
|  **Random property 3**  |   random value 3   |         |
| **Default option value**|        yes         |         |
|  **Random property 4**  |   random value 4   |         |
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

    [<Test>]
    member _.ParsesValidPageWithOneRuleWithoutDefaultValue() =
        let pageUrl = "page_url"

        let pageText = """
# Page title

Some introductory text.

### dotnet_test_rule

|     Property     |     Value     |     Description     |
|     --------     |     -----     |     -----------     |
|  **Random property 1**  |   random value 1   |         |
|     **Option name**     |  dotnet_test_rule  |         |
|  **Random property 2**  |   random value 2   |         |
|    **Option values**    |        yes         |         |
|                         |        no          |         |
|                         |       maybe        |         |
|  **Random property 3**  |   random value 3   |         |
|  **Random property 4**  |   random value 4   |         |
"""

        let actual = MarkdownParser.parseMarkdown pageUrl pageText
        let expected:option<MsdnPage> =
            { Title = "Page title";
              Url = "page_url";
              Rules = [
                { Name = "dotnet_test_rule";
                  Values = ["yes"; "no"; "maybe"];
                  DefaultValue = None; }
              ]; }
            |> Some

        Assert.That(actual, Is.EqualTo expected)

    [<Test>]
    member _.ParsesValidPageWithTwoRules() =
        let pageUrl = "page_url"

        let pageText = """
# Page title

Some introductory text.

### dotnet_test_rule

|     Property     |     Value     |     Description     |
|     --------     |     -----     |     -----------     |
|  **Random property 1**  |   random value 1   |         |
|     **Option name**     |  dotnet_test_rule  |         |
|  **Random property 2**  |   random value 2   |         |
|    **Option values**    |        yes         |         |
|                         |        no          |         |
|                         |       maybe        |         |
|  **Random property 3**  |   random value 3   |         |
| **Default option value**|        yes         |         |
|  **Random property 4**  |   random value 4   |         |

### csharp_test_rule

|     Property     |     Value     |     Description     |
|     --------     |     -----     |     -----------     |
|  **Random property 1**  |   random value 1   |         |
|     **Option name**     |  csharp_test_rule  |         |
|  **Random property 2**  |   random value 2   |         |
|    **Option values**    |        foo         |         |
|                         |        bar         |         |
|                         |        baz         |         |
|  **Random property 3**  |   random value 3   |         |
|  **Random property 4**  |   random value 4   |         |
"""

        let actual = MarkdownParser.parseMarkdown pageUrl pageText
        let expected:option<MsdnPage> =
            { Title = "Page title";
              Url = "page_url";
              Rules = [
                { Name = "dotnet_test_rule";
                  Values = ["yes"; "no"; "maybe"];
                  DefaultValue = Some "yes"; };
                { Name = "csharp_test_rule";
                  Values = ["foo"; "bar"; "baz"];
                  DefaultValue = None; }
              ]; }
            |> Some

        Assert.That(actual, Is.EqualTo expected)
