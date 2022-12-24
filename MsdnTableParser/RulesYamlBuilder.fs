namespace MsdnTableParser

module RulesYamlBuilder =
    open StyleTree
    open YamlDotNet.RepresentationModel

    let ruleToYaml (url:string) (rule:StyleRule) =
        let url =
            match url.LastIndexOf(".md") with
            | index when (index > -1) -> url.Substring(0, index)
            | _ -> url

        YamlMappingNode(
            YamlScalarNode("Name"),
            YamlScalarNode(rule.Name),

            YamlScalarNode("Values"),
            YamlSequenceNode(rule.Values |> Seq.map YamlScalarNode |> Seq.cast<YamlNode>),

            YamlScalarNode("DefaultValue"),
            YamlScalarNode(rule.DefaultValue |> Option.defaultValue ""),

            YamlScalarNode("MsdnLink"),
            YamlScalarNode(url + "#" + rule.Name))

    let rec addTree (tree:StyleTree<StylePage>) (parent:YamlMappingNode) =
        match tree with
        | Page (name, page) ->
            let pageMapping = YamlMappingNode()

            let rulesMappings =
                page.Rules
                |> Seq.map (ruleToYaml page.Url)
                |> Seq.cast<YamlNode>

            pageMapping.Add(page.Title, YamlSequenceNode(rulesMappings))
            parent.Add(name, pageMapping)

        | Section (name, children) ->
            let childrenMapping = YamlMappingNode()

            for child in children do
                addTree child childrenMapping

            parent.Add(name, childrenMapping)

    let treeToYaml (tree:StyleTree<StylePage>) =
        let root = YamlMappingNode()
        addTree tree root
        root
