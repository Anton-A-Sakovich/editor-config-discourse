namespace MsdnTableParser.Tests

open MsdnTableParser.MsdnCrawler
open NUnit.Framework
open YamlDotNet.RepresentationModel

[<TestFixture>]
type MsdnCrawlerTests() =
    let assertParseResult (result:ParseResult<TocEntry>) (node:YamlMappingNode) =
        Assert.That(tryParseMappingNode node, Is.EqualTo result)

    [<Test>]
    member _.ParsesPageMappingNode() =
        YamlMappingNode("name", "foo", "href", "bar")
        |> assertParseResult (Success(Page("foo", "bar")))

    [<Test>]
    member _.FailsForEmptyMappingNode() =
        YamlMappingNode() |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithoutHrefOrItems() =
       YamlMappingNode("name", "foo") |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectName() =
        YamlMappingNode("name", YamlSequenceNode()) |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectHref() =
        YamlMappingNode("name", "foo", "href", YamlMappingNode())
        |> assertParseResult Failure

    [<Test>]
    member _.ParsesSectionMappingNode() =
        YamlMappingNode(
            "name", "foo",
            "items", YamlSequenceNode(seq {
                yield YamlMappingNode("name", "foo1", "href", "bar1") :> YamlNode
                yield YamlMappingNode("name", "foo2", "href", "bar2")
            }))
        |> assertParseResult (Success(Section("foo", [Page("foo1", "bar1"); Page("foo2", "bar2")])))
