#  Table of Contents

[Code style rules](#code-style-rules)  resolved 10 from 104\
&nbsp;&nbsp;&nbsp;&nbsp;[Language rules](#language-rules)  resolved 8 from 62\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[this and Me preferences](#this-and-me-preferences)  resolved 4 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0003 and IDE0009](#ide0003-and-ide0009)  resolved 4 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[this and Me preferences (IDE0003 and IDE0009)](#this-and-me-preferences-(ide0003-and-ide0009))  resolved 4 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_field](#dotnet_style_qualification_for_field)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_property](#dotnet_style_qualification_for_property)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_method](#dotnet_style_qualification_for_method)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_event](#dotnet_style_qualification_for_event)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use language keywords for types](#use-language-keywords-for-types)  resolved 2 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0049](#ide0049)  resolved 2 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use language keywords instead of framework type names for type references (IDE0049)](#use-language-keywords-instead-of-framework-type-names-for-type-references-(ide0049))  resolved 2 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_predefined_type_for_locals_parameters_members](#dotnet_style_predefined_type_for_locals_parameters_members)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_predefined_type_for_member_access](#dotnet_style_predefined_type_for_member_access)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Modifier preferences](#modifier-preferences)  resolved 0 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0036](#ide0036) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Order modifiers (IDE0036)](#order-modifiers-(ide0036)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_preferred_modifier_order](#csharp_preferred_modifier_order)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0040](#ide0040) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Add accessibility modifiers (IDE0040)](#add-accessibility-modifiers-(ide0040)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_require_accessibility_modifiers](#dotnet_style_require_accessibility_modifiers)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0044](#ide0044) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Add readonly modifier (IDE0044)](#add-readonly-modifier-(ide0044)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_readonly_field](#dotnet_style_readonly_field)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0062](#ide0062) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Make local function static (IDE0062)](#make-local-function-static-(ide0062)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_prefer_static_local_function](#csharp_prefer_static_local_function)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Parentheses preferences](#parentheses-preferences)  resolved 0 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0047 and IDE0048](#ide0047-and-ide0048)  resolved 0 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Parentheses preferences (IDE0047 and IDE0048)](#parentheses-preferences-(ide0047-and-ide0048))  resolved 0 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_arithmetic_binary_operators](#dotnet_style_parentheses_in_arithmetic_binary_operators)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_relational_binary_operators](#dotnet_style_parentheses_in_relational_binary_operators)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_other_binary_operators](#dotnet_style_parentheses_in_other_binary_operators)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_other_operators](#dotnet_style_parentheses_in_other_operators)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Expression-level preferences](#expression-level-preferences)  resolved 0 from 19\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0017](#ide0017) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use object initializers (IDE0017)](#use-object-initializers-(ide0017)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_object_initializer](#dotnet_style_object_initializer)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0018](#ide0018) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Inline variable declaration (IDE0018)](#inline-variable-declaration-(ide0018)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_inlined_variable_declaration](#csharp_style_inlined_variable_declaration)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0028](#ide0028) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use collection initializers (IDE0028)](#use-collection-initializers-(ide0028)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_collection_initializer](#dotnet_style_collection_initializer)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0032](#ide0032) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use auto-implemented property (IDE0032)](#use-auto-implemented-property-(ide0032)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_auto_properties](#dotnet_style_prefer_auto_properties)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0033](#ide0033) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use explicitly provided tuple name (IDE0033)](#use-explicitly-provided-tuple-name-(ide0033)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_explicit_tuple_names](#dotnet_style_explicit_tuple_names)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0034](#ide0034) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify 'default' expression (IDE0034)](#simplify-'default'-expression-(ide0034)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_prefer_simple_default_expression](#csharp_prefer_simple_default_expression)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0037](#ide0037)  resolved 0 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use inferred member names (IDE0037)](#use-inferred-member-names-(ide0037))  resolved 0 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_inferred_tuple_names](#dotnet_style_prefer_inferred_tuple_names)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_inferred_anonymous_type_member_names](#dotnet_style_prefer_inferred_anonymous_type_member_names)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0039](#ide0039) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use local function instead of lambda (IDE0039)](#use-local-function-instead-of-lambda-(ide0039)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_local_over_anonymous_function](#csharp_style_prefer_local_over_anonymous_function)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0042](#ide0042) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Deconstruct variable declaration (IDE0042)](#deconstruct-variable-declaration-(ide0042)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_deconstructed_variable_declaration](#csharp_style_deconstructed_variable_declaration)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0045](#ide0045) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use conditional expression for assignment (IDE0045)](#use-conditional-expression-for-assignment-(ide0045)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_conditional_expression_over_assignment](#dotnet_style_prefer_conditional_expression_over_assignment)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0046](#ide0046) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use conditional expression for return (IDE0046)](#use-conditional-expression-for-return-(ide0046)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_conditional_expression_over_return](#dotnet_style_prefer_conditional_expression_over_return)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0054](#ide0054) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use compound assignment (IDE0054 and IDE0074)](#use-compound-assignment-(ide0054-and-ide0074)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_compound_assignment](#dotnet_style_prefer_compound_assignment)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0056](#ide0056) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use index operator (IDE0056)](#use-index-operator-(ide0056)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_index_operator](#csharp_style_prefer_index_operator)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0057](#ide0057) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use range operator (IDE0057)](#use-range-operator-(ide0057)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_range_operator](#csharp_style_prefer_range_operator)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0071](#ide0071) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify interpolation (IDE0071)](#simplify-interpolation-(ide0071)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_simplified_interpolation](#dotnet_style_prefer_simplified_interpolation)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0075](#ide0075) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify conditional expression (IDE0075)](#simplify-conditional-expression-(ide0075)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_simplified_boolean_expressions](#dotnet_style_prefer_simplified_boolean_expressions)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0090](#ide0090) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify `new` expression (IDE0090)](#simplify-`new`-expression-(ide0090)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_implicit_object_creation_when_type_is_apparent](#csharp_style_implicit_object_creation_when_type_is_apparent)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0180](#ide0180) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use tuple to swap values (IDE0180)](#use-tuple-to-swap-values-(ide0180)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_tuple_swap](#csharp_style_prefer_tuple_swap)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Namespace declaration preferences](#namespace-declaration-preferences) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0160 and IDE0161](#ide0160-and-ide0161) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Namespace declaration preferences (IDE0160 and IDE0161)](#namespace-declaration-preferences-(ide0160-and-ide0161)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_namespace_declarations](#csharp_style_namespace_declarations)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Null-checking preferences](#null-checking-preferences)  resolved 0 from 6\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0016](#ide0016) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use throw expression (IDE0016)](#use-throw-expression-(ide0016)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_throw_expression](#csharp_style_throw_expression)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0029 and IDE0030](#ide0029-and-ide0030) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use coalesce expression (IDE0029 and IDE0030)](#use-coalesce-expression-(ide0029-and-ide0030)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_coalesce_expression](#dotnet_style_coalesce_expression)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0031](#ide0031) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use null propagation (IDE0031)](#use-null-propagation-(ide0031)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_null_propagation](#dotnet_style_null_propagation)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0041](#ide0041) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use 'is null' check (IDE0041)](#use-'is-null'-check-(ide0041)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_is_null_check_over_reference_equality_method](#dotnet_style_prefer_is_null_check_over_reference_equality_method)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0150](#ide0150) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Prefer 'null' check over type check (IDE0150)](#prefer-'null'-check-over-type-check-(ide0150)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_null_check_over_type_check](#csharp_style_prefer_null_check_over_type_check)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE1005](#ide1005) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use conditional delegate call (IDE1005)](#use-conditional-delegate-call-(ide1005)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_conditional_delegate_call](#csharp_style_conditional_delegate_call)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[var preferences](#var-preferences)  resolved 0 from 3\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0007 and IDE0008](#ide0007-and-ide0008)  resolved 0 from 3\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;['var' preferences (IDE0007 and IDE0008)](#'var'-preferences-(ide0007-and-ide0008))  resolved 0 from 3\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_var_for_built_in_types](#csharp_style_var_for_built_in_types)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_var_when_type_is_apparent](#csharp_style_var_when_type_is_apparent)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_var_elsewhere](#csharp_style_var_elsewhere)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Expression-bodied members](#expression-bodied-members)  resolved 0 from 8\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0021](#ide0021) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for constructors (IDE0021)](#use-expression-body-for-constructors-(ide0021)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_constructors](#csharp_style_expression_bodied_constructors)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0022](#ide0022) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for methods (IDE0022)](#use-expression-body-for-methods-(ide0022)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_methods](#csharp_style_expression_bodied_methods)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0023 and IDE0024](#ide0023-and-ide0024) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for operators (IDE0023 and IDE0024)](#use-expression-body-for-operators-(ide0023-and-ide0024)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_operators](#csharp_style_expression_bodied_operators)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0025](#ide0025) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for properties (IDE0025)](#use-expression-body-for-properties-(ide0025)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_properties](#csharp_style_expression_bodied_properties)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0026](#ide0026) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for indexers (IDE0026)](#use-expression-body-for-indexers-(ide0026)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_indexers](#csharp_style_expression_bodied_indexers)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0027](#ide0027) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for accessors (IDE0027)](#use-expression-body-for-accessors-(ide0027)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_accessors](#csharp_style_expression_bodied_accessors)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0053](#ide0053) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for lambdas (IDE0053)](#use-expression-body-for-lambdas-(ide0053)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_lambdas](#csharp_style_expression_bodied_lambdas)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0061](#ide0061) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use expression body for local functions (IDE0061)](#use-expression-body-for-local-functions-(ide0061)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_expression_bodied_local_functions](#csharp_style_expression_bodied_local_functions)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Pattern matching preferences](#pattern-matching-preferences)  resolved 0 from 6\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0019](#ide0019) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use pattern matching to avoid 'as' followed by a 'null' check (IDE0019)](#use-pattern-matching-to-avoid-'as'-followed-by-a-'null'-check-(ide0019)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_pattern_matching_over_as_with_null_check](#csharp_style_pattern_matching_over_as_with_null_check)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0020 and IDE0038](#ide0020-and-ide0038) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use pattern matching to avoid 'is' check followed by a cast (IDE0020 and IDE0038)](#use-pattern-matching-to-avoid-'is'-check-followed-by-a-cast-(ide0020-and-ide0038)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_pattern_matching_over_is_with_cast_check](#csharp_style_pattern_matching_over_is_with_cast_check)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0066](#ide0066) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use switch expression (IDE0066)](#use-switch-expression-(ide0066)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_switch_expression](#csharp_style_prefer_switch_expression)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0078](#ide0078) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use pattern matching (IDE0078)](#use-pattern-matching-(ide0078)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_pattern_matching](#csharp_style_prefer_pattern_matching)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0083](#ide0083) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use pattern matching (`not` operator) (IDE0083)](#use-pattern-matching-(`not`-operator)-(ide0083)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_not_pattern](#csharp_style_prefer_not_pattern)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0170](#ide0170) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify property pattern (IDE0170)](#simplify-property-pattern-(ide0170)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_extended_property_pattern](#csharp_style_prefer_extended_property_pattern)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Code block preferences](#code-block-preferences)  resolved 0 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0011](#ide0011) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Add braces (IDE0011)](#add-braces-(ide0011)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_prefer_braces](#csharp_prefer_braces)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0063](#ide0063) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use simple 'using' statement (IDE0063)](#use-simple-'using'-statement-(ide0063)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_prefer_simple_using_statement](#csharp_prefer_simple_using_statement)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[using directive preferences](#using-directive-preferences) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0065](#ide0065) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;['using' directive placement (IDE0065)](#'using'-directive-placement-(ide0065)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_using_directive_placement](#csharp_using_directive_placement)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[File header preferences](#file-header-preferences) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0073](#ide0073) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Require file header (IDE0073)](#require-file-header-(ide0073)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[file_header_template](#file_header_template)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Namespace naming preferences](#namespace-naming-preferences) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0130](#ide0130) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Namespace does not match folder structure (IDE0130)](#namespace-does-not-match-folder-structure-(ide0130)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_namespace_match_folder](#dotnet_style_namespace_match_folder)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;[Unnecessary code rules](#unnecessary-code-rules)  resolved 0 from 4\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0058](#ide0058) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Remove unnecessary expression value (IDE0058)](#remove-unnecessary-expression-value-(ide0058)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_unused_value_expression_statement_preference](#csharp_style_unused_value_expression_statement_preference)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0059](#ide0059) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Remove unnecessary value assignment (IDE0059)](#remove-unnecessary-value-assignment-(ide0059)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_unused_value_assignment_preference](#csharp_style_unused_value_assignment_preference)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0060](#ide0060) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Remove unused parameter (IDE0060)](#remove-unused-parameter-(ide0060)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_code_quality_unused_parameters](#dotnet_code_quality_unused_parameters)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0079](#ide0079) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Remove unnecessary suppression (IDE0079)](#remove-unnecessary-suppression-(ide0079)) \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_remove_unnecessary_suppression_exclusions](#dotnet_remove_unnecessary_suppression_exclusions)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;[Formatting rules](#formatting-rules)  resolved 2 from 38\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[IDE0055](#ide0055)  resolved 2 from 38\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[.NET formatting options](#.net-formatting-options)  resolved 2 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[.NET namespace rules](#.net-namespace-rules)  resolved 2 from 2\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_sort_system_directives_first](#dotnet_sort_system_directives_first)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_separate_import_directive_groups](#dotnet_separate_import_directive_groups)  resolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[C# formatting options](#c#-formatting-options)  resolved 0 from 36\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ CSharp formatting rules:](#-csharp-formatting-rules:)  resolved 0 from 36\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_new_line_before_else](#csharp_new_line_before_else)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_new_line_before_catch](#csharp_new_line_before_catch)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_new_line_before_finally](#csharp_new_line_before_finally)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_new_line_before_members_in_object_initializers](#csharp_new_line_before_members_in_object_initializers)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_new_line_before_members_in_anonymous_types](#csharp_new_line_before_members_in_anonymous_types)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_new_line_between_query_expression_clauses](#csharp_new_line_between_query_expression_clauses)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_indent_case_contents](#csharp_indent_case_contents)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_indent_switch_labels](#csharp_indent_switch_labels)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_indent_labels](#csharp_indent_labels)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_indent_block_contents](#csharp_indent_block_contents)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_indent_braces](#csharp_indent_braces)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_indent_case_contents_when_block](#csharp_indent_case_contents_when_block)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_after_cast](#csharp_space_after_cast)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_after_keywords_in_control_flow_statements](#csharp_space_after_keywords_in_control_flow_statements)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_parentheses](#csharp_space_between_parentheses)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_before_colon_in_inheritance_clause](#csharp_space_before_colon_in_inheritance_clause)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_after_colon_in_inheritance_clause](#csharp_space_after_colon_in_inheritance_clause)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_around_binary_operators](#csharp_space_around_binary_operators)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_method_declaration_parameter_list_parentheses](#csharp_space_between_method_declaration_parameter_list_parentheses)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_method_declaration_empty_parameter_list_parentheses](#csharp_space_between_method_declaration_empty_parameter_list_parentheses)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_method_declaration_name_and_open_parenthesis](#csharp_space_between_method_declaration_name_and_open_parenthesis)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_method_call_parameter_list_parentheses](#csharp_space_between_method_call_parameter_list_parentheses)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_method_call_empty_parameter_list_parentheses](#csharp_space_between_method_call_empty_parameter_list_parentheses)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_method_call_name_and_opening_parenthesis](#csharp_space_between_method_call_name_and_opening_parenthesis)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_after_comma](#csharp_space_after_comma)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_before_comma](#csharp_space_before_comma)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_after_dot](#csharp_space_after_dot)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_before_dot](#csharp_space_before_dot)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_after_semicolon_in_for_statement](#csharp_space_after_semicolon_in_for_statement)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_before_semicolon_in_for_statement](#csharp_space_before_semicolon_in_for_statement)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_around_declaration_statements](#csharp_space_around_declaration_statements)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_before_open_square_brackets](#csharp_space_before_open_square_brackets)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_empty_square_brackets](#csharp_space_between_empty_square_brackets)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_space_between_square_brackets](#csharp_space_between_square_brackets)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_preserve_single_line_statements](#csharp_preserve_single_line_statements)  unresolved\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_preserve_single_line_blocks](#csharp_preserve_single_line_blocks)  unresolved

# <a name="code-style-rules"></a> Code style rules
## <a name="language-rules"></a> Language rules
### <a name="this-and-me-preferences"></a> this and Me preferences
#### <a name="ide0003-and-ide0009"></a> IDE0003 and IDE0009
##### <a name="this-and-me-preferences-(ide0003-and-ide0009)"></a> this and Me preferences (IDE0003 and IDE0009)
<a name="dotnet_style_qualification_for_field"></a> `dotnet_style_qualification_for_field` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_field)

Selected value: `false:error`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `false`

---

<a name="dotnet_style_qualification_for_property"></a> `dotnet_style_qualification_for_property` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_property)

Selected value: `false:error`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `false`

---

<a name="dotnet_style_qualification_for_method"></a> `dotnet_style_qualification_for_method` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_method)

Selected value: `false:silent`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `false`

---

<a name="dotnet_style_qualification_for_event"></a> `dotnet_style_qualification_for_event` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_event)

Selected value: `false:error`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `false`

---

### <a name="use-language-keywords-for-types"></a> Use language keywords for types
#### <a name="ide0049"></a> IDE0049
##### <a name="use-language-keywords-instead-of-framework-type-names-for-type-references-(ide0049)"></a> Use language keywords instead of framework type names for type references (IDE0049)
<a name="dotnet_style_predefined_type_for_locals_parameters_members"></a> `dotnet_style_predefined_type_for_locals_parameters_members` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0049#dotnet_style_predefined_type_for_locals_parameters_members)

Selected value: `true:error`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `true`

---

<a name="dotnet_style_predefined_type_for_member_access"></a> `dotnet_style_predefined_type_for_member_access` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0049#dotnet_style_predefined_type_for_member_access)

Selected value: `false:error`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `true`

---

### <a name="modifier-preferences"></a> Modifier preferences
#### <a name="ide0036"></a> IDE0036
##### <a name="order-modifiers-(ide0036)"></a> Order modifiers (IDE0036)
<a name="csharp_preferred_modifier_order"></a> `csharp_preferred_modifier_order` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0036#csharp_preferred_modifier_order)

Selected value:\
Issue:

Possible values:
* One or more C# modifiers, such as `public`, `private`, and `protected`

Default value: `public, private, protected, internal, file, static, extern, new, virtual, abstract, sealed, override, readonly, unsafe, required, volatile, async`

---

#### <a name="ide0040"></a> IDE0040
##### <a name="add-accessibility-modifiers-(ide0040)"></a> Add accessibility modifiers (IDE0040)
<a name="dotnet_style_require_accessibility_modifiers"></a> `dotnet_style_require_accessibility_modifiers` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0040#dotnet_style_require_accessibility_modifiers)

Selected value:\
Issue:

Possible values:
* `always`
* `for_non_interface_members`
* `never`
* `omit_if_default`

Default value: `for_non_interface_members`

---

#### <a name="ide0044"></a> IDE0044
##### <a name="add-readonly-modifier-(ide0044)"></a> Add readonly modifier (IDE0044)
<a name="dotnet_style_readonly_field"></a> `dotnet_style_readonly_field` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0044#dotnet_style_readonly_field)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0062"></a> IDE0062
##### <a name="make-local-function-static-(ide0062)"></a> Make local function static (IDE0062)
<a name="csharp_prefer_static_local_function"></a> `csharp_prefer_static_local_function` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0062#csharp_prefer_static_local_function)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true:suggestion`

---

### <a name="parentheses-preferences"></a> Parentheses preferences
#### <a name="ide0047-and-ide0048"></a> IDE0047 and IDE0048
##### <a name="parentheses-preferences-(ide0047-and-ide0048)"></a> Parentheses preferences (IDE0047 and IDE0048)
<a name="dotnet_style_parentheses_in_arithmetic_binary_operators"></a> `dotnet_style_parentheses_in_arithmetic_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_arithmetic_binary_operators)

Selected value:\
Issue:

Possible values:
* `always_for_clarity`
* `never_if_unnecessary`

Default value: `always_for_clarity`

---

<a name="dotnet_style_parentheses_in_relational_binary_operators"></a> `dotnet_style_parentheses_in_relational_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_relational_binary_operators)

Selected value:\
Issue:

Possible values:
* `always_for_clarity`
* `never_if_unnecessary`

Default value: `always_for_clarity`

---

<a name="dotnet_style_parentheses_in_other_binary_operators"></a> `dotnet_style_parentheses_in_other_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_other_binary_operators)

Selected value:\
Issue:

Possible values:
* `always_for_clarity`
* `never_if_unnecessary`

Default value: `always_for_clarity`

---

<a name="dotnet_style_parentheses_in_other_operators"></a> `dotnet_style_parentheses_in_other_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_other_operators)

Selected value:\
Issue:

Possible values:
* `always_for_clarity`
* `never_if_unnecessary`

Default value: `never_if_unnecessary`

---

### <a name="expression-level-preferences"></a> Expression-level preferences
#### <a name="ide0017"></a> IDE0017
##### <a name="use-object-initializers-(ide0017)"></a> Use object initializers (IDE0017)
<a name="dotnet_style_object_initializer"></a> `dotnet_style_object_initializer` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0017#dotnet_style_object_initializer)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0018"></a> IDE0018
##### <a name="inline-variable-declaration-(ide0018)"></a> Inline variable declaration (IDE0018)
<a name="csharp_style_inlined_variable_declaration"></a> `csharp_style_inlined_variable_declaration` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0018#csharp_style_inlined_variable_declaration)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0028"></a> IDE0028
##### <a name="use-collection-initializers-(ide0028)"></a> Use collection initializers (IDE0028)
<a name="dotnet_style_collection_initializer"></a> `dotnet_style_collection_initializer` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0028#dotnet_style_collection_initializer)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0032"></a> IDE0032
##### <a name="use-auto-implemented-property-(ide0032)"></a> Use auto-implemented property (IDE0032)
<a name="dotnet_style_prefer_auto_properties"></a> `dotnet_style_prefer_auto_properties` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0032#dotnet_style_prefer_auto_properties)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0033"></a> IDE0033
##### <a name="use-explicitly-provided-tuple-name-(ide0033)"></a> Use explicitly provided tuple name (IDE0033)
<a name="dotnet_style_explicit_tuple_names"></a> `dotnet_style_explicit_tuple_names` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0033#dotnet_style_explicit_tuple_names)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0034"></a> IDE0034
##### <a name="simplify-'default'-expression-(ide0034)"></a> Simplify 'default' expression (IDE0034)
<a name="csharp_prefer_simple_default_expression"></a> `csharp_prefer_simple_default_expression` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0034#csharp_prefer_simple_default_expression)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0037"></a> IDE0037
##### <a name="use-inferred-member-names-(ide0037)"></a> Use inferred member names (IDE0037)
<a name="dotnet_style_prefer_inferred_tuple_names"></a> `dotnet_style_prefer_inferred_tuple_names` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0037#dotnet_style_prefer_inferred_tuple_names)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

<a name="dotnet_style_prefer_inferred_anonymous_type_member_names"></a> `dotnet_style_prefer_inferred_anonymous_type_member_names` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0037#dotnet_style_prefer_inferred_anonymous_type_member_names)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0039"></a> IDE0039
##### <a name="use-local-function-instead-of-lambda-(ide0039)"></a> Use local function instead of lambda (IDE0039)
<a name="csharp_style_prefer_local_over_anonymous_function"></a> `csharp_style_prefer_local_over_anonymous_function` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0039#csharp_style_prefer_local_over_anonymous_function)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0042"></a> IDE0042
##### <a name="deconstruct-variable-declaration-(ide0042)"></a> Deconstruct variable declaration (IDE0042)
<a name="csharp_style_deconstructed_variable_declaration"></a> `csharp_style_deconstructed_variable_declaration` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0042#csharp_style_deconstructed_variable_declaration)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0045"></a> IDE0045
##### <a name="use-conditional-expression-for-assignment-(ide0045)"></a> Use conditional expression for assignment (IDE0045)
<a name="dotnet_style_prefer_conditional_expression_over_assignment"></a> `dotnet_style_prefer_conditional_expression_over_assignment` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0045#dotnet_style_prefer_conditional_expression_over_assignment)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0046"></a> IDE0046
##### <a name="use-conditional-expression-for-return-(ide0046)"></a> Use conditional expression for return (IDE0046)
<a name="dotnet_style_prefer_conditional_expression_over_return"></a> `dotnet_style_prefer_conditional_expression_over_return` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0046#dotnet_style_prefer_conditional_expression_over_return)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0054"></a> IDE0054
##### <a name="use-compound-assignment-(ide0054-and-ide0074)"></a> Use compound assignment (IDE0054 and IDE0074)
<a name="dotnet_style_prefer_compound_assignment"></a> `dotnet_style_prefer_compound_assignment` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0054-ide0074#dotnet_style_prefer_compound_assignment)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0056"></a> IDE0056
##### <a name="use-index-operator-(ide0056)"></a> Use index operator (IDE0056)
<a name="csharp_style_prefer_index_operator"></a> `csharp_style_prefer_index_operator` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0056#csharp_style_prefer_index_operator)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0057"></a> IDE0057
##### <a name="use-range-operator-(ide0057)"></a> Use range operator (IDE0057)
<a name="csharp_style_prefer_range_operator"></a> `csharp_style_prefer_range_operator` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0057#csharp_style_prefer_range_operator)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0071"></a> IDE0071
##### <a name="simplify-interpolation-(ide0071)"></a> Simplify interpolation (IDE0071)
<a name="dotnet_style_prefer_simplified_interpolation"></a> `dotnet_style_prefer_simplified_interpolation` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0071#dotnet_style_prefer_simplified_interpolation)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0075"></a> IDE0075
##### <a name="simplify-conditional-expression-(ide0075)"></a> Simplify conditional expression (IDE0075)
<a name="dotnet_style_prefer_simplified_boolean_expressions"></a> `dotnet_style_prefer_simplified_boolean_expressions` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0075#dotnet_style_prefer_simplified_boolean_expressions)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0090"></a> IDE0090
##### <a name="simplify-`new`-expression-(ide0090)"></a> Simplify `new` expression (IDE0090)
<a name="csharp_style_implicit_object_creation_when_type_is_apparent"></a> `csharp_style_implicit_object_creation_when_type_is_apparent` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0090#csharp_style_implicit_object_creation_when_type_is_apparent)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0180"></a> IDE0180
##### <a name="use-tuple-to-swap-values-(ide0180)"></a> Use tuple to swap values (IDE0180)
<a name="csharp_style_prefer_tuple_swap"></a> `csharp_style_prefer_tuple_swap` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180#csharp_style_prefer_tuple_swap)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

### <a name="namespace-declaration-preferences"></a> Namespace declaration preferences
#### <a name="ide0160-and-ide0161"></a> IDE0160 and IDE0161
##### <a name="namespace-declaration-preferences-(ide0160-and-ide0161)"></a> Namespace declaration preferences (IDE0160 and IDE0161)
<a name="csharp_style_namespace_declarations"></a> `csharp_style_namespace_declarations` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0160-ide0161#csharp_style_namespace_declarations)

Selected value:\
Issue:

Possible values:
* `block_scoped`
* `file_scoped`

Default value: `block_scoped`

---

### <a name="null-checking-preferences"></a> Null-checking preferences
#### <a name="ide0016"></a> IDE0016
##### <a name="use-throw-expression-(ide0016)"></a> Use throw expression (IDE0016)
<a name="csharp_style_throw_expression"></a> `csharp_style_throw_expression` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0016#csharp_style_throw_expression)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0029-and-ide0030"></a> IDE0029 and IDE0030
##### <a name="use-coalesce-expression-(ide0029-and-ide0030)"></a> Use coalesce expression (IDE0029 and IDE0030)
<a name="dotnet_style_coalesce_expression"></a> `dotnet_style_coalesce_expression` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0029-ide0030#dotnet_style_coalesce_expression)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0031"></a> IDE0031
##### <a name="use-null-propagation-(ide0031)"></a> Use null propagation (IDE0031)
<a name="dotnet_style_null_propagation"></a> `dotnet_style_null_propagation` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0031#dotnet_style_null_propagation)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0041"></a> IDE0041
##### <a name="use-'is-null'-check-(ide0041)"></a> Use 'is null' check (IDE0041)
<a name="dotnet_style_prefer_is_null_check_over_reference_equality_method"></a> `dotnet_style_prefer_is_null_check_over_reference_equality_method` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0041#dotnet_style_prefer_is_null_check_over_reference_equality_method)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0150"></a> IDE0150
##### <a name="prefer-'null'-check-over-type-check-(ide0150)"></a> Prefer 'null' check over type check (IDE0150)
<a name="csharp_style_prefer_null_check_over_type_check"></a> `csharp_style_prefer_null_check_over_type_check` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0150#csharp_style_prefer_null_check_over_type_check)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide1005"></a> IDE1005
##### <a name="use-conditional-delegate-call-(ide1005)"></a> Use conditional delegate call (IDE1005)
<a name="csharp_style_conditional_delegate_call"></a> `csharp_style_conditional_delegate_call` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide1005#csharp_style_conditional_delegate_call)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

### <a name="var-preferences"></a> var preferences
#### <a name="ide0007-and-ide0008"></a> IDE0007 and IDE0008
##### <a name="'var'-preferences-(ide0007-and-ide0008)"></a> 'var' preferences (IDE0007 and IDE0008)
<a name="csharp_style_var_for_built_in_types"></a> `csharp_style_var_for_built_in_types` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0007-ide0008#csharp_style_var_for_built_in_types)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `false`

---

<a name="csharp_style_var_when_type_is_apparent"></a> `csharp_style_var_when_type_is_apparent` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0007-ide0008#csharp_style_var_when_type_is_apparent)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `false`

---

<a name="csharp_style_var_elsewhere"></a> `csharp_style_var_elsewhere` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0007-ide0008#csharp_style_var_elsewhere)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `false`

---

### <a name="expression-bodied-members"></a> Expression-bodied members
#### <a name="ide0021"></a> IDE0021
##### <a name="use-expression-body-for-constructors-(ide0021)"></a> Use expression body for constructors (IDE0021)
<a name="csharp_style_expression_bodied_constructors"></a> `csharp_style_expression_bodied_constructors` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0021#csharp_style_expression_bodied_constructors)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `false`

---

#### <a name="ide0022"></a> IDE0022
##### <a name="use-expression-body-for-methods-(ide0022)"></a> Use expression body for methods (IDE0022)
<a name="csharp_style_expression_bodied_methods"></a> `csharp_style_expression_bodied_methods` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0022#csharp_style_expression_bodied_methods)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `false`

---

#### <a name="ide0023-and-ide0024"></a> IDE0023 and IDE0024
##### <a name="use-expression-body-for-operators-(ide0023-and-ide0024)"></a> Use expression body for operators (IDE0023 and IDE0024)
<a name="csharp_style_expression_bodied_operators"></a> `csharp_style_expression_bodied_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0023-ide0024#csharp_style_expression_bodied_operators)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `false`

---

#### <a name="ide0025"></a> IDE0025
##### <a name="use-expression-body-for-properties-(ide0025)"></a> Use expression body for properties (IDE0025)
<a name="csharp_style_expression_bodied_properties"></a> `csharp_style_expression_bodied_properties` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0025#csharp_style_expression_bodied_properties)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `true`

---

#### <a name="ide0026"></a> IDE0026
##### <a name="use-expression-body-for-indexers-(ide0026)"></a> Use expression body for indexers (IDE0026)
<a name="csharp_style_expression_bodied_indexers"></a> `csharp_style_expression_bodied_indexers` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0026#csharp_style_expression_bodied_indexers)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `true`

---

#### <a name="ide0027"></a> IDE0027
##### <a name="use-expression-body-for-accessors-(ide0027)"></a> Use expression body for accessors (IDE0027)
<a name="csharp_style_expression_bodied_accessors"></a> `csharp_style_expression_bodied_accessors` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0027#csharp_style_expression_bodied_accessors)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `true`

---

#### <a name="ide0053"></a> IDE0053
##### <a name="use-expression-body-for-lambdas-(ide0053)"></a> Use expression body for lambdas (IDE0053)
<a name="csharp_style_expression_bodied_lambdas"></a> `csharp_style_expression_bodied_lambdas` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0053#csharp_style_expression_bodied_lambdas)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `true`

---

#### <a name="ide0061"></a> IDE0061
##### <a name="use-expression-body-for-local-functions-(ide0061)"></a> Use expression body for local functions (IDE0061)
<a name="csharp_style_expression_bodied_local_functions"></a> `csharp_style_expression_bodied_local_functions` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0061#csharp_style_expression_bodied_local_functions)

Selected value:\
Issue:

Possible values:
* `true`
* `when_on_single_line`
* `false`

Default value: `false`

---

### <a name="pattern-matching-preferences"></a> Pattern matching preferences
#### <a name="ide0019"></a> IDE0019
##### <a name="use-pattern-matching-to-avoid-'as'-followed-by-a-'null'-check-(ide0019)"></a> Use pattern matching to avoid 'as' followed by a 'null' check (IDE0019)
<a name="csharp_style_pattern_matching_over_as_with_null_check"></a> `csharp_style_pattern_matching_over_as_with_null_check` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0019#csharp_style_pattern_matching_over_as_with_null_check)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0020-and-ide0038"></a> IDE0020 and IDE0038
##### <a name="use-pattern-matching-to-avoid-'is'-check-followed-by-a-cast-(ide0020-and-ide0038)"></a> Use pattern matching to avoid 'is' check followed by a cast (IDE0020 and IDE0038)
<a name="csharp_style_pattern_matching_over_is_with_cast_check"></a> `csharp_style_pattern_matching_over_is_with_cast_check` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0020-ide0038#csharp_style_pattern_matching_over_is_with_cast_check)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0066"></a> IDE0066
##### <a name="use-switch-expression-(ide0066)"></a> Use switch expression (IDE0066)
<a name="csharp_style_prefer_switch_expression"></a> `csharp_style_prefer_switch_expression` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0066#csharp_style_prefer_switch_expression)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0078"></a> IDE0078
##### <a name="use-pattern-matching-(ide0078)"></a> Use pattern matching (IDE0078)
<a name="csharp_style_prefer_pattern_matching"></a> `csharp_style_prefer_pattern_matching` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0078#csharp_style_prefer_pattern_matching)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0083"></a> IDE0083
##### <a name="use-pattern-matching-(`not`-operator)-(ide0083)"></a> Use pattern matching (`not` operator) (IDE0083)
<a name="csharp_style_prefer_not_pattern"></a> `csharp_style_prefer_not_pattern` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0083#csharp_style_prefer_not_pattern)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

#### <a name="ide0170"></a> IDE0170
##### <a name="simplify-property-pattern-(ide0170)"></a> Simplify property pattern (IDE0170)
<a name="csharp_style_prefer_extended_property_pattern"></a> `csharp_style_prefer_extended_property_pattern` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0170#csharp_style_prefer_extended_property_pattern)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

### <a name="code-block-preferences"></a> Code block preferences
#### <a name="ide0011"></a> IDE0011
##### <a name="add-braces-(ide0011)"></a> Add braces (IDE0011)
<a name="csharp_prefer_braces"></a> `csharp_prefer_braces` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0011#csharp_prefer_braces)

Selected value:\
Issue:

Possible values:
* `true`
* `false`
* `when_multiline`

Default value: `true`

---

#### <a name="ide0063"></a> IDE0063
##### <a name="use-simple-'using'-statement-(ide0063)"></a> Use simple 'using' statement (IDE0063)
<a name="csharp_prefer_simple_using_statement"></a> `csharp_prefer_simple_using_statement` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0063#csharp_prefer_simple_using_statement)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

Default value: `true`

---

### <a name="using-directive-preferences"></a> using directive preferences
#### <a name="ide0065"></a> IDE0065
##### <a name="'using'-directive-placement-(ide0065)"></a> 'using' directive placement (IDE0065)
<a name="csharp_using_directive_placement"></a> `csharp_using_directive_placement` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0065#csharp_using_directive_placement)

Selected value:\
Issue:

Possible values:
* `outside_namespace`
* `inside_namespace`

Default value: `outside_namespace`

---

### <a name="file-header-preferences"></a> File header preferences
#### <a name="ide0073"></a> IDE0073
##### <a name="require-file-header-(ide0073)"></a> Require file header (IDE0073)
<a name="file_header_template"></a> `file_header_template` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0073#file_header_template)

Selected value: `unset`\
Issue:

Possible values:
* non-empty string, optionally containing a `{fileName}` placeholder
* `unset` or empty string

Default value: `unset`

---

### <a name="namespace-naming-preferences"></a> Namespace naming preferences
#### <a name="ide0130"></a> IDE0130
##### <a name="namespace-does-not-match-folder-structure-(ide0130)"></a> Namespace does not match folder structure (IDE0130)
<a name="dotnet_style_namespace_match_folder"></a> `dotnet_style_namespace_match_folder` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0130#dotnet_style_namespace_match_folder)

Selected value: `true:error`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

Default value: `true`

---

## <a name="unnecessary-code-rules"></a> Unnecessary code rules
### <a name="ide0058"></a> IDE0058
#### <a name="remove-unnecessary-expression-value-(ide0058)"></a> Remove unnecessary expression value (IDE0058)
<a name="csharp_style_unused_value_expression_statement_preference"></a> `csharp_style_unused_value_expression_statement_preference` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0058#csharp_style_unused_value_expression_statement_preference)

Selected value:\
Issue:

Possible values:
* `discard_variable`
* `unused_local_variable`

Default value: `discard_variable`

---

### <a name="ide0059"></a> IDE0059
#### <a name="remove-unnecessary-value-assignment-(ide0059)"></a> Remove unnecessary value assignment (IDE0059)
<a name="csharp_style_unused_value_assignment_preference"></a> `csharp_style_unused_value_assignment_preference` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0059#csharp_style_unused_value_assignment_preference)

Selected value:\
Issue:

Possible values:
* `discard_variable`
* `unused_local_variable`

Default value: `discard_variable`

---

### <a name="ide0060"></a> IDE0060
#### <a name="remove-unused-parameter-(ide0060)"></a> Remove unused parameter (IDE0060)
<a name="dotnet_code_quality_unused_parameters"></a> `dotnet_code_quality_unused_parameters` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0060#dotnet_code_quality_unused_parameters)

Selected value:\
Issue:

Possible values:
* `all`
* `non_public`

Default value: `all`

---

### <a name="ide0079"></a> IDE0079
#### <a name="remove-unnecessary-suppression-(ide0079)"></a> Remove unnecessary suppression (IDE0079)
<a name="dotnet_remove_unnecessary_suppression_exclusions"></a> `dotnet_remove_unnecessary_suppression_exclusions` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0079#dotnet_remove_unnecessary_suppression_exclusions)

Selected value:\
Issue:

Possible values:
* `,` separated list of rule IDs or categories (prefixed with `category:`)
* `all`
* `none`

Default value: `none`

---

## <a name="formatting-rules"></a> Formatting rules
### <a name="ide0055"></a> IDE0055
#### <a name=".net-formatting-options"></a> .NET formatting options
##### <a name=".net-namespace-rules"></a> .NET namespace rules
<a name="dotnet_sort_system_directives_first"></a> `dotnet_sort_system_directives_first` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/dotnet-formatting-options#dotnet_sort_system_directives_first)

Selected value: `false`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

---

<a name="dotnet_separate_import_directive_groups"></a> `dotnet_separate_import_directive_groups` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/dotnet-formatting-options#dotnet_separate_import_directive_groups)

Selected value: `false`\
Issue: [1](https://github.com/Anton-A-Sakovich/editor-config-discourse/issues/1)

Possible values:
* `true`
* `false`

---

#### <a name="c#-formatting-options"></a> C# formatting options
##### <a name="-csharp-formatting-rules:"></a>  CSharp formatting rules:
<a name="csharp_new_line_before_else"></a> `csharp_new_line_before_else` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_new_line_before_else)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_new_line_before_catch"></a> `csharp_new_line_before_catch` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_new_line_before_catch)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_new_line_before_finally"></a> `csharp_new_line_before_finally` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_new_line_before_finally)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_new_line_before_members_in_object_initializers"></a> `csharp_new_line_before_members_in_object_initializers` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_new_line_before_members_in_object_initializers)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_new_line_before_members_in_anonymous_types"></a> `csharp_new_line_before_members_in_anonymous_types` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_new_line_before_members_in_anonymous_types)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_new_line_between_query_expression_clauses"></a> `csharp_new_line_between_query_expression_clauses` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_new_line_between_query_expression_clauses)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_indent_case_contents"></a> `csharp_indent_case_contents` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_indent_case_contents)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_indent_switch_labels"></a> `csharp_indent_switch_labels` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_indent_switch_labels)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_indent_labels"></a> `csharp_indent_labels` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_indent_labels)

Selected value:\
Issue:

Possible values:
* `flush_left`
* `one_less_than_current`
* `no_change`

---

<a name="csharp_indent_block_contents"></a> `csharp_indent_block_contents` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_indent_block_contents)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_indent_braces"></a> `csharp_indent_braces` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_indent_braces)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_indent_case_contents_when_block"></a> `csharp_indent_case_contents_when_block` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_indent_case_contents_when_block)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_after_cast"></a> `csharp_space_after_cast` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_after_cast)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_after_keywords_in_control_flow_statements"></a> `csharp_space_after_keywords_in_control_flow_statements` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_after_keywords_in_control_flow_statements)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_parentheses"></a> `csharp_space_between_parentheses` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_parentheses)

Selected value:\
Issue:

Possible values:
* `control_flow_statements`
* `expressions`
* `type_casts`

---

<a name="csharp_space_before_colon_in_inheritance_clause"></a> `csharp_space_before_colon_in_inheritance_clause` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_before_colon_in_inheritance_clause)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_after_colon_in_inheritance_clause"></a> `csharp_space_after_colon_in_inheritance_clause` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_after_colon_in_inheritance_clause)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_around_binary_operators"></a> `csharp_space_around_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_around_binary_operators)

Selected value:\
Issue:

Possible values:
* `before_and_after`
* `none`
* `ignore`

---

<a name="csharp_space_between_method_declaration_parameter_list_parentheses"></a> `csharp_space_between_method_declaration_parameter_list_parentheses` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_method_declaration_parameter_list_parentheses)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_method_declaration_empty_parameter_list_parentheses"></a> `csharp_space_between_method_declaration_empty_parameter_list_parentheses` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_method_declaration_empty_parameter_list_parentheses)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_method_declaration_name_and_open_parenthesis"></a> `csharp_space_between_method_declaration_name_and_open_parenthesis` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_method_declaration_name_and_open_parenthesis)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_method_call_parameter_list_parentheses"></a> `csharp_space_between_method_call_parameter_list_parentheses` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_method_call_parameter_list_parentheses)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_method_call_empty_parameter_list_parentheses"></a> `csharp_space_between_method_call_empty_parameter_list_parentheses` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_method_call_empty_parameter_list_parentheses)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_method_call_name_and_opening_parenthesis"></a> `csharp_space_between_method_call_name_and_opening_parenthesis` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_method_call_name_and_opening_parenthesis)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_after_comma"></a> `csharp_space_after_comma` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_after_comma)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_before_comma"></a> `csharp_space_before_comma` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_before_comma)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_after_dot"></a> `csharp_space_after_dot` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_after_dot)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_before_dot"></a> `csharp_space_before_dot` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_before_dot)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_after_semicolon_in_for_statement"></a> `csharp_space_after_semicolon_in_for_statement` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_after_semicolon_in_for_statement)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_before_semicolon_in_for_statement"></a> `csharp_space_before_semicolon_in_for_statement` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_before_semicolon_in_for_statement)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_around_declaration_statements"></a> `csharp_space_around_declaration_statements` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_around_declaration_statements)

Selected value:\
Issue:

Possible values:
* `ignore`
* `false`

---

<a name="csharp_space_before_open_square_brackets"></a> `csharp_space_before_open_square_brackets` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_before_open_square_brackets)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_empty_square_brackets"></a> `csharp_space_between_empty_square_brackets` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_empty_square_brackets)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_space_between_square_brackets"></a> `csharp_space_between_square_brackets` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_space_between_square_brackets)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_preserve_single_line_statements"></a> `csharp_preserve_single_line_statements` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_preserve_single_line_statements)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

<a name="csharp_preserve_single_line_blocks"></a> `csharp_preserve_single_line_blocks` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/csharp-formatting-options#csharp_preserve_single_line_blocks)

Selected value:\
Issue:

Possible values:
* `true`
* `false`

---

