namespace StyleTree

type StyleTree<'T> =
    | Page of string * 'T
    | Section of string * list<StyleTree<'T>>

module StyleTree =
    open YamlDotNet.RepresentationModel

    let rec map f (tree:StyleTree<_>) =
        match tree with
        | Page (name, value) -> Page (name, f value)
        | Section (name, children) -> Section(name, children |> List.map (map f))

    let rec cat onPage onSection (tree:StyleTree<_>) =
        match tree with
        | Page (name, value) -> onPage (name, value)
        | Section (name, children) ->
            let children' = children |> List.map (cat onPage onSection)
            onSection (name, children')

    let rec tryFind (path:list<string>) (tree:StyleTree<_>) =
        match (path, tree) with
        | ([], _) -> Some tree

        | ([segment], _) ->
            let name =
                match tree with
                | Page (name, _) -> name
                | Section (name, _) -> name

            if segment = name then
                Some tree
            else
                None

        | (segment::rest, Section(name, children)) ->
            if segment = name then
                Seq.tryPick (tryFind rest) children
            else
                None

        | (_, _) -> None

    let rec addToYaml converter (tree:StyleTree<_>) (parent:YamlMappingNode) =
        match tree with
        | Page (name, leaf) ->
            let leafNode:YamlNode = converter leaf
            parent.Add(name, leafNode)
        | Section (name, children) ->
            let childrenNode = YamlMappingNode()

            for child in children do
                addToYaml converter child childrenNode

            parent.Add(name, childrenNode)

    let toYaml converter tree =
        let rootNode = YamlMappingNode()
        addToYaml converter tree rootNode
        rootNode

    let rec fromYaml converter (node:YamlNode) =
        match converter node with
        | Some leaf ->
            fun name -> Page(name, leaf)
        | None ->
            match node with
            | :? YamlMappingNode as mappingNode ->
                fun name ->
                    let chidren =
                        mappingNode.Children
                        |> Seq.map (fun pair ->
                            let name = (pair.Key :?> YamlScalarNode).Value
                            name |> fromYaml converter pair.Value)
                        |> List.ofSeq

                    Section(name, chidren)
            | _ -> failwith "Error"
