open MsdnTableParser.MsdnSectionParser

let table: Table =
    Rows [
        Values (["Option name"; "Name"; ""]);
        Values (["Option value"; "value 1"]);
        Values ([""; "value 2"]);
        Values (["Default option value"; "default"])
    ]

let section: Section =
    {
        Header =
            {
                Title = "Title";
                Link = "Link";
            };
        Table = table;
    }

section |> parseSection |> printf "%A"