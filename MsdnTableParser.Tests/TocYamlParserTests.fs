namespace MsdnTableParser.Tests

open MsdnTableParser
open MsdnTableParser.TocYamlParser
open NUnit.Framework
open YamlDotNet.RepresentationModel

[<TestFixture>]
type TocYamlParserTests() =
    let assertParseResult (result:ParseResult<StyleTree<TocPage>>) (node:YamlNode) =
        Assert.That(tryParse node, Is.EqualTo result)

    [<Test>]
    member _.ParsesPageMappingNode() =
        YamlMappingNode("name", "page_name", "href", "page_path")
        |> assertParseResult (Success(Page({ Name = "page_name"; Href = "page_path"})))

    [<Test>]
    member _.FailsForEmptyMappingNode() =
        YamlMappingNode() |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithoutNameOnly() =
       YamlMappingNode("name", "page_name") |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectName() =
        YamlMappingNode("name", YamlSequenceNode()) |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithHrefOnly() =
        YamlMappingNode("href", "page_path") |> assertParseResult Failure

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectHref() =
        YamlMappingNode("name", "page_name", "href", YamlMappingNode())
        |> assertParseResult Failure

    [<Test>]
    member _.ParsesSectionMappingNodeWithExplicitName() =
        YamlMappingNode(
            "name", "section_name",
            "items", YamlSequenceNode(seq {
                yield YamlMappingNode("name", "page_name_1", "href", "page_path_1") :> YamlNode
                yield YamlMappingNode("name", "page_name_2", "href", "page_path_2")
            }))
        |> assertParseResult (Success(
                Section("section_name", [
                    Page({Name = "page_name_1"; Href = "page_path_1"});
                    Page({Name = "page_name_2"; Href = "page_path_2"})])))

    [<Test>]
    member _.ParsesSectionMappingNodeWithoutName() =
        YamlMappingNode(
            "items", YamlSequenceNode(seq {
                yield YamlMappingNode("name", "page_name_1", "href", "page_path_1") :> YamlNode
                yield YamlMappingNode("name", "page_name_2", "href", "page_path_2")
            }))
        |> assertParseResult (Success(
                Section("Root", [
                    Page({Name = "page_name_1"; Href = "page_path_1"});
                    Page({Name = "page_name_2"; Href = "page_path_2"})])))

    [<Test>]
    member _.FailsForMappingNodeWithIncorrectItems() =
        YamlMappingNode("items", YamlMappingNode()) |> assertParseResult Failure
