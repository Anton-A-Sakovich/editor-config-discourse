namespace MarkdownUpdater

type StyleRuleMetadata = {
    Name: string;
    Values: string list;
    DefaultValue: string option;
    MsdnLink: string; }

type StyleRule = {
    Metadata: StyleRuleMetadata;
    SelectedValue: string option;
    IssueId: string option; }

type MarkdownNode<'T> =
    | Rule of 'T
    | Section of title:string * children:list<MarkdownNode<'T>>

type EditorconfigRule = {
    Name: string;
    Value: string;
    IssueId: string option }

module Merger =
    let inline private mergeConfigsIntoMetadata (editorconfigRules:Map<string, EditorconfigRule>) (metadata:StyleRuleMetadata) =
        match editorconfigRules |> Map.tryFind metadata.Name with
        | Some config ->
            {
                Metadata = metadata;
                SelectedValue = Some config.Value;
                IssueId = config.IssueId;
            }
        | None ->
            {
                Metadata = metadata;
                SelectedValue = None;
                IssueId = None;
            }

    let rec mergeConfigIntoMarkdownNode (editorconfigRules:Map<string, EditorconfigRule>) (node:MarkdownNode<StyleRuleMetadata>) =
        match node with
        | Rule metadata -> Rule (metadata |> mergeConfigsIntoMetadata editorconfigRules)
        | Section (title, children) -> Section (title, children |> List.map (mergeConfigIntoMarkdownNode editorconfigRules))