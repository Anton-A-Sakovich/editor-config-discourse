namespace EditorconfigDiscourse.MarkdownUpdater

module EditorconfigParser =
    open EditorconfigDiscourse.Utilities
    open System
    open System.Collections.Generic
    open System.Text.RegularExpressions

    [<Struct; NoComparison; NoEquality; RequireQualifiedAccess>]
    type private SourceLineKind =
        | None
        | Invalid
        | Comment
        | Section
        | KeyValuePair

    type private ISourceLineMatcher =
        abstract MatchNone : unit -> unit
        abstract MatchInvalid : unit -> unit
        abstract MatchComment : comment:string -> unit
        abstract MatchSection : section:string -> unit
        abstract MatchKeyValuePair : key:string * value:string -> unit

    type private ISourceLineMatcher<'T> =
        abstract MatchNone : unit -> 'T
        abstract MatchInvalid : unit -> 'T
        abstract MatchComment : comment:string -> 'T
        abstract MatchSection : section:string -> 'T
        abstract MatchKeyValuePair : key:string * value:string -> 'T

    type private IssueIdParser() =
        interface ISourceLineMatcher<option<string>> with
            member _.MatchNone() = None
            member _.MatchInvalid() = None

            member _.MatchComment(comment) =
                let referenceMatch = Regex.Match(comment, @"^#\(([^\)]+)\)")
                if referenceMatch.Success then
                    Some referenceMatch.Groups[1].Value
                else
                    None

            member _.MatchSection(_) = None
            member _.MatchKeyValuePair(_, _) = None

        static member Instance = IssueIdParser()

    type private SourceLine() =
        let mutable kind = SourceLineKind.None
        let mutable key = ""
        let mutable value = ""

        member _.None() =
            kind <- SourceLineKind.None

        member _.Invalid() =
            kind <- SourceLineKind.Invalid

        member _.Comment(newComment) =
            kind <- SourceLineKind.Comment
            value <- newComment

        member _.Section(newSection) =
            kind <- SourceLineKind.Section
            value <- newSection

        member _.KeyValuePair(newKey, newValue) =
            kind <- SourceLineKind.KeyValuePair
            key <- newKey
            value <- newValue

        member _.Match(matcher:ISourceLineMatcher) =
            match kind with
            | SourceLineKind.None -> matcher.MatchNone()
            | SourceLineKind.Invalid -> matcher.MatchInvalid()
            | SourceLineKind.Comment -> matcher.MatchComment(value)
            | SourceLineKind.Section -> matcher.MatchSection(value)
            | SourceLineKind.KeyValuePair -> matcher.MatchKeyValuePair(key, value)

        member _.Match(matcher:ISourceLineMatcher<_>) =
            match kind with
            | SourceLineKind.None -> matcher.MatchNone()
            | SourceLineKind.Invalid -> matcher.MatchInvalid()
            | SourceLineKind.Comment -> matcher.MatchComment(value)
            | SourceLineKind.Section -> matcher.MatchSection(value)
            | SourceLineKind.KeyValuePair -> matcher.MatchKeyValuePair(key, value)

        interface ISourceLineMatcher with
            member this.MatchNone() = this.None();
            member this.MatchInvalid() = this.Invalid()
            member this.MatchComment(comment) = this.Comment(comment)
            member this.MatchSection(section) = this.Section(section)
            member this.MatchKeyValuePair(key, value) = this.KeyValuePair(key, value)

    type private SourceParser() =
        let line1 = SourceLine()
        let line2 = SourceLine()
        let rules = List<EditorconfigRule>()

        member _.Rules
            with get() = rules |> Seq.map (fun rule -> (rule.Name, rule)) |> Map.ofSeq

        member this.ParseLine(line:ReadOnlySpan<char>) =
            // line2 should update line1 to match line2, so line2 should call mutating methods of line1.
            line2.Match(line1)
            this.TryParseAsSection(line)

        member private this.TryParseAsSection(line:ReadOnlySpan<char>) =
            let mutable matches = Regex.EnumerateMatches(line, @"^\s*\[.*\]\s*$")
            if matches.MoveNext() then
                let section = String (line.Trim(' '))
                line2.Section(section)
            else
                this.TryParseAsComment(line)

        member private this.TryParseAsComment(line:ReadOnlySpan<char>) =
            let mutable matches = Regex.EnumerateMatches(line, @"^\s*[#;].*$")
            if matches.MoveNext() then
                let comment = String (line.TrimStart(' '))
                line2.Comment(comment)
            else
                this.TryParseAsKeyValuePair(line)

        member private this.TryParseAsKeyValuePair(line:ReadOnlySpan<char>) =
            let mutable matches = Regex.EnumerateMatches(line, @"^\s*[^\s=]*\s*=.+$")
            if matches.MoveNext() then
                let equalIndex = line.IndexOf('=')
                let key = String (line.Slice(0, equalIndex).Trim(' '))
                let value = String (line.Slice(equalIndex + 1).TrimStart(' '))
                line2.KeyValuePair(key, value)

                let rule:EditorconfigRule =
                    { Name = key; Value = value; IssueId = line1.Match(IssueIdParser.Instance); }

                rules.Add(rule)
            else
                this.TryParseAsNone(line)

        member private _.TryParseAsNone(line:ReadOnlySpan<char>) =
            let mutable matches = Regex.EnumerateMatches(line, @"^\s*$")
            if matches.MoveNext() then
                line2.None()
            else
                line2.Invalid()

    let parseEditorconfig(text:string) =
        let parser = SourceParser()
        for line in text |> EnumeratedLines do
            parser.ParseLine(line)
        parser.Rules
