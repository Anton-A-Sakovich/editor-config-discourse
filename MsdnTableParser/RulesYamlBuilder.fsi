namespace MsdnTableParser

module RulesYamlBuilder =
    open YamlDotNet.RepresentationModel

    val treeToYaml : StyleTree<StylePage> -> YamlMappingNode
