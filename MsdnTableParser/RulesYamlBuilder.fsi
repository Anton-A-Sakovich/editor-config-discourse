namespace MsdnTableParser

module RulesYamlBuilder =
    open StyleTree
    open YamlDotNet.RepresentationModel

    val treeToYaml : StyleTree<StylePage> -> YamlMappingNode
