namespace MsdnTableParser

type OptionMetadata =
    {
        Name: string;
        Values: list<string>;
        DefaultValue: string option;
        MsdnLink: string;
    }