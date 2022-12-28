namespace EditorconfigDiscourse.MsdnTableParser.Tests
open EditorconfigDiscourse.MsdnTableParser
open EditorconfigDiscourse.StyleTree
open EditorconfigDiscourse.Yaml
open NUnit.Framework
open YamlDotNet.RepresentationModel

[<TestFixture>]
type TocYamlParserTests() =
    let assertParseResult (result:ParseResult<StyleTree<string>>) (node:YamlNode) =
        Assert.That(TocYamlParser.tryParse node, Is.EqualTo result)

    [<Test>]
    member _.ParsesPageMappingNode() =
        YamlMappingNode("name", "page_name", "href", "page_path")
        |> assertParseResult (Parsed(Page("page_name", "page_path")))

    [<Test>]
    member _.FailsForEmptyMappingNode() =
        YamlMappingNode() |> assertParseResult Failed

    [<Test>]
    member _.FailsForMappingNodeWithoutNameOnly() =
       YamlMappingNode("name", "page_name") |> assertParseResult Failed

    [<Test>]
    member _.FailsForMappingNodeWithHrefOnly() =
        YamlMappingNode("href", "page_path") |> assertParseResult Failed

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectName() =
        YamlMappingNode("name", YamlSequenceNode(), "href", "page_path") |> assertParseResult Failed

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectHref() =
        YamlMappingNode("name", "page_name", "href", YamlMappingNode())
        |> assertParseResult Failed

    [<Test>]
    member _.ParsesSectionMappingNodeWithExplicitName() =
        YamlMappingNode(
            "name", "section_name",
            "items", YamlSequenceNode(seq {
                yield YamlMappingNode("name", "page_name_1", "href", "page_path_1") :> YamlNode
                yield YamlMappingNode("name", "page_name_2", "href", "page_path_2")
            }))
        |> assertParseResult (Parsed(
                Section("section_name", [
                    Page("page_name_1", "page_path_1");
                    Page("page_name_2", "page_path_2")])))

    [<Test>]
    member _.ParsesSectionMappingNodeWithoutName() =
        YamlMappingNode(
            "items", YamlSequenceNode(seq {
                yield YamlMappingNode("name", "page_name_1", "href", "page_path_1") :> YamlNode
                yield YamlMappingNode("name", "page_name_2", "href", "page_path_2")
            }))
        |> assertParseResult (Parsed(
                Section("Root", [
                    Page("page_name_1", "page_path_1");
                    Page("page_name_2", "page_path_2")])))

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectItems() =
        YamlMappingNode("items", YamlMappingNode()) |> assertParseResult Failed
