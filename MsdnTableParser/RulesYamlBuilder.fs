namespace MsdnTableParser

module RulesYamlBuilder =
    open YamlDotNet.RepresentationModel

    let ruleToYaml (url:string) (rule:StyleRule) =
        YamlMappingNode(
            YamlScalarNode("Name"),
            YamlScalarNode(rule.Name),

            YamlScalarNode("Values"),
            YamlSequenceNode(rule.Values |> Seq.map YamlScalarNode |> Seq.cast<YamlNode>),

            YamlScalarNode("DefaultValue"),
            YamlScalarNode(rule.DefaultValue |> Option.defaultValue ""),

            YamlScalarNode("MsdnLink"),
            YamlScalarNode(url + "#" + rule.Name))

    let pageToYaml (page:StylePage) =
        YamlMappingNode(
            YamlScalarNode(page.Title),
            YamlSequenceNode(page.Rules |> Seq.map (ruleToYaml page.Url) |> Seq.cast<YamlNode>))

    let rec treeToYaml (tree:StyleTree<StylePage>) =
        match tree with
        | Page page -> pageToYaml page
        | Section (name, children) ->
            YamlMappingNode(
                YamlScalarNode(name),
                YamlSequenceNode(children |> Seq.map treeToYaml |> Seq.cast<YamlNode>))
