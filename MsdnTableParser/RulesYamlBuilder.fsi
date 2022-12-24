namespace MsdnTableParser

module RulesYamlBuilder =
    open YamlDotNet.RepresentationModel

    val pageToYaml : page:StylePage -> YamlMappingNode
