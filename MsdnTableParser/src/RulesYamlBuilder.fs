namespace EditorconfigDiscourse.MsdnTableParser

module RulesYamlBuilder =
    open EditorconfigDiscourse.StyleTree
    open YamlDotNet.RepresentationModel

    let pageToYaml (page:MsdnPage) =
        let ruleNodes =
            page.Rules
            |> Seq.map (fun rule ->
                { Name = rule.Name;
                  Values = rule.Values;
                  DefaultValue = rule.DefaultValue;
                  MsdnLink = page.Url + "#" + rule.Name; })
            |> Seq.map YamlRepresentation.serializeStyleRule
            |> Seq.map (fun x -> x :> YamlNode)

        YamlMappingNode(YamlScalarNode(page.Title), YamlSequenceNode(ruleNodes))
