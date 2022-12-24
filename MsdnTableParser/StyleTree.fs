namespace MsdnTableParser

type StyleRule =
    { Name: string;
      Values: list<string>;
      DefaultValue: option<string>; }

type StylePage =
    { Title: string;
      Url: string;
      Rules: list<StyleRule>; }
