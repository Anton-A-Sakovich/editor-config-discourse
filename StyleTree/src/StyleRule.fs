namespace EditorconfigDiscourse.StyleTree

type StyleRule =
    { Name: string;
      Values: list<string>;
      DefaultValue: option<string>;
      MsdnLink: string; }
