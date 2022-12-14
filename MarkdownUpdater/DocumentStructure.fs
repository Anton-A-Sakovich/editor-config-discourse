namespace MarkdownUpdater

type StyleRule =
    {
        Name: string;
        Values: string list;
        DefaultValue: string option;
        MsdnLink: string;
        SelectedValue: string option;
        IssueId: string option;
    }

type DocumentNode =
    | Rule of StyleRule
    | Section of title:string * children:list<DocumentNode>