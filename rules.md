#  Table of Contents

[Code style rules](#code-style-rules)\
&nbsp;&nbsp;&nbsp;&nbsp;[Language rules](#language-rules)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[This and Me preferences](#this-and-me-preferences)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_field](#dotnet_style_qualification_for_field)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_property](#dotnet_style_qualification_for_property)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_method](#dotnet_style_qualification_for_method)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_qualification_for_event](#dotnet_style_qualification_for_event)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use language keywords instead of framework type names for type references](#use-language-keywords-instead-of-framework-type-names-for-type-references)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_predefined_type_for_locals_parameters_members](#dotnet_style_predefined_type_for_locals_parameters_members)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_predefined_type_for_member_access](#dotnet_style_predefined_type_for_member_access)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Modifier preferences](#modifier-preferences)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Order modifiers](#order-modifiers)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_preferred_modifier_order](#csharp_preferred_modifier_order)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Add accessibility modifier](#add-accessibility-modifier)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_require_accessibility_modifiers](#dotnet_style_require_accessibility_modifiers)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Add readonly modifier](#add-readonly-modifier)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_readonly_field](#dotnet_style_readonly_field)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Make local function static](#make-local-function-static)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_prefer_static_local_function](#csharp_prefer_static_local_function)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Parentheses preferences](#parentheses-preferences)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_arithmetic_binary_operators](#dotnet_style_parentheses_in_arithmetic_binary_operators)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_relational_binary_operators](#dotnet_style_parentheses_in_relational_binary_operators)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_other_binary_operators](#dotnet_style_parentheses_in_other_binary_operators)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_parentheses_in_other_operators](#dotnet_style_parentheses_in_other_operators)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Expression-level preferences](#expression-level-preferences)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use object initializers](#use-object-initializers)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_object_initializer](#dotnet_style_object_initializer)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Inline variable declaration](#inline-variable-declaration)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_inlined_variable_declaration](#csharp_style_inlined_variable_declaration)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use collection initializers](#use-collection-initializers)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_collection_initializer](#dotnet_style_collection_initializer)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use auto-implemented property](#use-auto-implemented-property)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_auto_properties](#dotnet_style_prefer_auto_properties)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use explicitly provided tuple name](#use-explicitly-provided-tuple-name)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_explicit_tuple_names](#dotnet_style_explicit_tuple_names)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify 'default' expression](#simplify-'default'-expression)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_prefer_simple_default_expression](#csharp_prefer_simple_default_expression)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use inferred member names](#use-inferred-member-names)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_inferred_anonymous_type_member_names](#dotnet_style_prefer_inferred_anonymous_type_member_names)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use local function instead of lambda](#use-local-function-instead-of-lambda)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_local_over_anonymous_function](#csharp_style_prefer_local_over_anonymous_function)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Deconstruct variable declaration](#deconstruct-variable-declaration)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_deconstructed_variable_declaration](#csharp_style_deconstructed_variable_declaration)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use conditional expression for assignment](#use-conditional-expression-for-assignment)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_conditional_expression_over_assignment](#dotnet_style_prefer_conditional_expression_over_assignment)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use conditional expression for return](#use-conditional-expression-for-return)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_conditional_expression_over_return](#dotnet_style_prefer_conditional_expression_over_return)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use compound assignment](#use-compound-assignment)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_compound_assignment](#dotnet_style_prefer_compound_assignment)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify conditional expression](#simplify-conditional-expression)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[dotnet_style_prefer_simplified_boolean_expressions](#dotnet_style_prefer_simplified_boolean_expressions)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Simplify new expression](#simplify-new-expression)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_implicit_object_creation_when_type_is_apparent](#csharp_style_implicit_object_creation_when_type_is_apparent)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Use tuple to swap values](#use-tuple-to-swap-values)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[csharp_style_prefer_tuple_swap](#csharp_style_prefer_tuple_swap)

# <a name="code-style-rules"></a> Code style rules

## <a name="language-rules"></a> Language rules

### <a name="this-and-me-preferences"></a> This and Me preferences

<a name="dotnet_style_qualification_for_field"></a> `dotnet_style_qualification_for_field` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_field)

Selected value:\
Issue:

Possible values:
* true
* false
---

<a name="dotnet_style_qualification_for_property"></a> `dotnet_style_qualification_for_property` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_property)

Selected value:\
Issue:

Possible values:
* true
* false
---

<a name="dotnet_style_qualification_for_method"></a> `dotnet_style_qualification_for_method` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_method)

Selected value:\
Issue:

Possible values:
* true
* false
---

<a name="dotnet_style_qualification_for_event"></a> `dotnet_style_qualification_for_event` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0003-ide0009#dotnet_style_qualification_for_event)

Selected value:\
Issue:

Possible values:
* true
* false
---

### <a name="use-language-keywords-instead-of-framework-type-names-for-type-references"></a> Use language keywords instead of framework type names for type references

<a name="dotnet_style_predefined_type_for_locals_parameters_members"></a> `dotnet_style_predefined_type_for_locals_parameters_members` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0049#dotnet_style_predefined_type_for_locals_parameters_members)

Selected value:\
Issue:

Possible values:
* true
* false
---

<a name="dotnet_style_predefined_type_for_member_access"></a> `dotnet_style_predefined_type_for_member_access` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0049#dotnet_style_predefined_type_for_member_access)

Selected value:\
Issue:

Possible values:
* true
* false
---

### <a name="modifier-preferences"></a> Modifier preferences

#### <a name="order-modifiers"></a> Order modifiers

<a name="csharp_preferred_modifier_order"></a> `csharp_preferred_modifier_order` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0036#csharp_preferred_modifier_order)

Selected value:\
Issue:

Possible values:
* One or more C# modifiers, such as public, private, and protected
---

#### <a name="add-accessibility-modifier"></a> Add accessibility modifier

<a name="dotnet_style_require_accessibility_modifiers"></a> `dotnet_style_require_accessibility_modifiers` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0040#dotnet_style_require_accessibility_modifiers)

Selected value:\
Issue:

Possible values:
* always
* for_non_interface_members
* never
* omit_if_default
---

#### <a name="add-readonly-modifier"></a> Add readonly modifier

<a name="dotnet_style_readonly_field"></a> `dotnet_style_readonly_field` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0044#dotnet_style_readonly_field)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="make-local-function-static"></a> Make local function static

<a name="csharp_prefer_static_local_function"></a> `csharp_prefer_static_local_function` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0062#csharp_prefer_static_local_function)

Selected value:\
Issue:

Possible values:
* true
* false
---

### <a name="parentheses-preferences"></a> Parentheses preferences

<a name="dotnet_style_parentheses_in_arithmetic_binary_operators"></a> `dotnet_style_parentheses_in_arithmetic_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_arithmetic_binary_operators)

Selected value:\
Issue:

Possible values:
* always_for_clarity
* never_if_unnecessary
---

<a name="dotnet_style_parentheses_in_relational_binary_operators"></a> `dotnet_style_parentheses_in_relational_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_relational_binary_operators)

Selected value:\
Issue:

Possible values:
* always_for_clarity
* never_if_unnecessary
---

<a name="dotnet_style_parentheses_in_other_binary_operators"></a> `dotnet_style_parentheses_in_other_binary_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_other_binary_operators)

Selected value:\
Issue:

Possible values:
* always_for_clarity
* never_if_unnecessary
---

<a name="dotnet_style_parentheses_in_other_operators"></a> `dotnet_style_parentheses_in_other_operators` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0047-ide0048#dotnet_style_parentheses_in_other_operators)

Selected value:\
Issue:

Possible values:
* always_for_clarity
* never_if_unnecessary
---

### <a name="expression-level-preferences"></a> Expression-level preferences

#### <a name="use-object-initializers"></a> Use object initializers

<a name="dotnet_style_object_initializer"></a> `dotnet_style_object_initializer` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0017#dotnet_style_object_initializer)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="inline-variable-declaration"></a> Inline variable declaration

<a name="csharp_style_inlined_variable_declaration"></a> `csharp_style_inlined_variable_declaration` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0018#csharp_style_inlined_variable_declaration)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-collection-initializers"></a> Use collection initializers

<a name="dotnet_style_collection_initializer"></a> `dotnet_style_collection_initializer` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0028#dotnet_style_collection_initializer)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-auto-implemented-property"></a> Use auto-implemented property

<a name="dotnet_style_prefer_auto_properties"></a> `dotnet_style_prefer_auto_properties` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0032#dotnet_style_prefer_auto_properties)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-explicitly-provided-tuple-name"></a> Use explicitly provided tuple name

<a name="dotnet_style_explicit_tuple_names"></a> `dotnet_style_explicit_tuple_names` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0033#dotnet_style_explicit_tuple_names)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="simplify-'default'-expression"></a> Simplify 'default' expression

<a name="csharp_prefer_simple_default_expression"></a> `csharp_prefer_simple_default_expression` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0034#csharp_prefer_simple_default_expression)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-inferred-member-names"></a> Use inferred member names

<a name="dotnet_style_prefer_inferred_anonymous_type_member_names"></a> `dotnet_style_prefer_inferred_anonymous_type_member_names` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0037#dotnet_style_prefer_inferred_anonymous_type_member_names)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-local-function-instead-of-lambda"></a> Use local function instead of lambda

<a name="csharp_style_prefer_local_over_anonymous_function"></a> `csharp_style_prefer_local_over_anonymous_function` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0039#csharp_style_prefer_local_over_anonymous_function)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="deconstruct-variable-declaration"></a> Deconstruct variable declaration

<a name="csharp_style_deconstructed_variable_declaration"></a> `csharp_style_deconstructed_variable_declaration` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0042#csharp_style_deconstructed_variable_declaration)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-conditional-expression-for-assignment"></a> Use conditional expression for assignment

<a name="dotnet_style_prefer_conditional_expression_over_assignment"></a> `dotnet_style_prefer_conditional_expression_over_assignment` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0045#dotnet_style_prefer_conditional_expression_over_assignment)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-conditional-expression-for-return"></a> Use conditional expression for return

<a name="dotnet_style_prefer_conditional_expression_over_return"></a> `dotnet_style_prefer_conditional_expression_over_return` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0046#dotnet_style_prefer_conditional_expression_over_return)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-compound-assignment"></a> Use compound assignment

<a name="dotnet_style_prefer_compound_assignment"></a> `dotnet_style_prefer_compound_assignment` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0054-ide0074#dotnet_style_prefer_compound_assignment)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="simplify-conditional-expression"></a> Simplify conditional expression

<a name="dotnet_style_prefer_simplified_boolean_expressions"></a> `dotnet_style_prefer_simplified_boolean_expressions` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0075#dotnet_style_prefer_simplified_boolean_expressions)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="simplify-new-expression"></a> Simplify new expression

<a name="csharp_style_implicit_object_creation_when_type_is_apparent"></a> `csharp_style_implicit_object_creation_when_type_is_apparent` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0090#csharp_style_implicit_object_creation_when_type_is_apparent)

Selected value:\
Issue:

Possible values:
* true
* false
---

#### <a name="use-tuple-to-swap-values"></a> Use tuple to swap values

<a name="csharp_style_prefer_tuple_swap"></a> `csharp_style_prefer_tuple_swap` [MSDN Link](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180#csharp_style_prefer_tuple_swap)

Selected value:\
Issue:

Possible values:
* true
* false
---

