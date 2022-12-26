namespace MarkdownUpdater

type StyleRule =
    { Name: string;
      Values: list<string>;
      DefaultValue: option<string>;
      MsdnLink: string; }

type StyleRuleResolution =
    { Rule: StyleRule;
      SelectedValue: option<string>;
      IssueId: option<string>; }

type EditorconfigRule =
    { Name: string;
      Value: string;
      IssueId: option<string>; }

module Merger =
    let inline private mergeConfigsIntoMetadata (editorconfigRules:Map<string, EditorconfigRule>) (rule:StyleRule) =
        match editorconfigRules |> Map.tryFind rule.Name with
        | Some config ->
            {
                Rule = rule;
                SelectedValue = Some config.Value;
                IssueId = config.IssueId;
            }
        | None ->
            {
                Rule = rule;
                SelectedValue = None;
                IssueId = None;
            }

    let rec mergeConfigIntoMarkdownNode (editorconfigRules:Map<string, EditorconfigRule>) (node:MarkdownNode<StyleRule>) =
        match node with
        | Rule metadata -> Rule (metadata |> mergeConfigsIntoMetadata editorconfigRules)
        | Section (title, children) -> Section (title, children |> List.map (mergeConfigIntoMarkdownNode editorconfigRules))
