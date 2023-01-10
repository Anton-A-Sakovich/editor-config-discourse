# MSDN Table Parser

Parses reference pages for code style rules from MSDN (aka Microsoft learn) and saves
specifications for possible rule options in a YAML file. At the time of writing these
documentation pages can be found at

* https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ (generated HTML),
* https://github.com/dotnet/docs/tree/main/docs/fundamentals/code-analysis/style-rules/ (source Markdown).

Note that the program parses Markdown sources rather than generated HTML content. Also note that the actual
content should be fetched as raw data, not HTML pages, located at https://raw.githubusercontent.com/.

The program fetches the table of contents file (`toc.yml`), tries to find the following path inside it

```
/Tools and diagnostics/Code analysis/Rule reference/Code style rules/
```

and parses each page it can find under this path. Note that the program uses only the table of contents file
for searching for pages, it does not scan the corresponding directories.

At the time of writing the relevant table of contents file is located at https://github.com/dotnet/docs/blob/main/docs/fundamentals/toc.yml.

## Synopsis

```
dotnet MsdnTableParser <output_file_path>[ <table_of_contents_path>]
```

where

* `<output_file_path>` is the path where to save the rule options specs;
* `<table_of_contents_path>` is the path where the file `toc.yml` resides (without `toc.yml` segment itself),
can be either a URL or a local file path, optional, defaults to https://raw.githubusercontent.com/dotnet/docs/main/docs/fundamentals/;

Using a local file path for `<table_of_contents_path>` allows using pre downloaded documents in order to avoid
excessive network requests.

## Output file structure

The output file is a YAML file containing a tree of mappings. The tree reflects the table of contents structure.
Each section or page corresponds to a mapping key-value pair, with the key being the name of the section or page
and the value being either a child mapping for sections or a sequence of rule options for pages. For example

```yaml
Root section:
    Section 1:
        Section 1.1:
            Page title A:
                - Rule option X
                - Rule option Y
            Page title B:
                - Rule option Z
        Section 1.2:
            Page title C:
                - Rule option W
    Section 2:
        Page title D:
            - Rule option Q
```

Each rule option is a mapping of the following form

```yaml
Name: <rule_name>
Values:
    - <possible_value_1>
    - <possible_value_2>
    - ...
DefaultValue: <value_or_empty_string>
MsdnLink: <link>
```

Sections or pages without any successfully parsed rule options are excluded from the output file tree.
