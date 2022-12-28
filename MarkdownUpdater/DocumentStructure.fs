namespace MarkdownUpdater
open EditorconfigDiscourse.StyleTree

type StyleRuleResolution =
    { Rule: StyleRule;
      SelectedValue: option<string>;
      IssueId: option<string>; }

type EditorconfigRule =
    { Name: string;
      Value: string;
      IssueId: option<string>; }

module Merger =
    let inline private createResolution (editorconfigRules:Map<string, EditorconfigRule>) (rule:StyleRule) =
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

    let rec createResolutions (editorconfigRules:Map<string, EditorconfigRule>) (tree:StyleTree<list<StyleRule>>) =
        match tree with
        | Page (name, rules) -> Page (name, rules |> List.map (createResolution editorconfigRules))
        | Section (name, children) -> Section (name, children |> List.map (createResolutions editorconfigRules))
