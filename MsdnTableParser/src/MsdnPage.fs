namespace EditorconfigDiscourse.MsdnTableParser

type MsdnRule =
    { Name: string;
      Values: list<string>;
      DefaultValue: option<string>; }

type MsdnPageContent =
    { Title: string;
      Rules: list<MsdnRule>; }

type MsdnPage =
    { Title: string;
      Url: string;
      Rules: list<MsdnRule>; }
