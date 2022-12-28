namespace MsdnTableParser

module StyleTreePostProcessor =
    open EditorconfigDiscourse.StyleTree

    val refine : StyleTree<option<MsdnPage>> -> option<StyleTree<MsdnPage>>
