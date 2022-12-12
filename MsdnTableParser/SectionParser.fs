namespace MsdnTableParser

module SectionParser =
    type TableRow = Values of list<string>
    type Table = Rows of list<TableRow>

    type SectionHeader =
        {
            Title: string;
            Link: string;
        }

    type Section =
        {
            Header: SectionHeader;
            Table: Table;
        }

    type private TableParsingState =
        | WaitingOptionName
        | WaitingOptionValue of string
        | GatheringOptionValues of string * list<string>
        | WaitingDefaultValue of string * list<string>
        | FoundDefaultValue of string * list<string> * string

    let private parseRow (state:TableParsingState) (TableRow.Values row) =
        match (state, row) with
        | (WaitingOptionName, "Option name"::name::_) -> WaitingOptionValue name
        | (WaitingOptionValue name, "Option value"::value::_) -> GatheringOptionValues (name, [value])
        | (GatheringOptionValues (name, values), ""::value::_) -> GatheringOptionValues (name, value::values)
        | (GatheringOptionValues (name, values), "Default option value"::defaultValue::_) -> FoundDefaultValue (name, values, defaultValue)
        | (GatheringOptionValues (name, values), _) -> WaitingDefaultValue (name, values)
        | (WaitingDefaultValue (name, values), "Default option value"::defaultValue::_) -> FoundDefaultValue (name, values, defaultValue)
        | _ -> state

    let private bindTableParsingState cont (state:TableParsingState) =
        match state with
        | GatheringOptionValues (name, values) -> cont (name, (List.rev values), None)
        | WaitingDefaultValue (name, values) -> cont (name, (List.rev values), None)
        | FoundDefaultValue (name, values, defaultValue) -> cont (name, (List.rev values), (Some defaultValue))
        | _ -> None

    let parseSection (section:Section): OptionMetadata option =
        let (Table.Rows rows) = section.Table
        rows
        |> List.fold parseRow WaitingOptionName
        |> bindTableParsingState (fun (name, values, defaultValue) ->
            Some {
                Name = name;
                Values = values;
                DefaultValue = defaultValue;
                MsdnLink = section.Header.Link;
            })
        

