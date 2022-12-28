namespace EditorconfigDiscourse.MsdnTableParser

type MsdnRule =
    { Name: string;
      Values: list<string>;
      DefaultValue: option<string>; }

type MsdnPage =
    { Title: string;
      Url: string;
      Rules: list<MsdnRule>; }
