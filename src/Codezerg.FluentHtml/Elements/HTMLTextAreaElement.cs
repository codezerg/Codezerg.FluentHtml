using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTextAreaElement : Element
{
    public HTMLTextAreaElement() : base("textarea")
    {
    }
}

public static class HTMLTextAreaElementExtensions
{
    public static HTMLTextAreaElement name(this HTMLTextAreaElement element, string value) => element.attr("name", value);
    public static HTMLTextAreaElement rows(this HTMLTextAreaElement element, int value) => element.attr("rows", value.ToString());
    public static HTMLTextAreaElement cols(this HTMLTextAreaElement element, int value) => element.attr("cols", value.ToString());
    public static HTMLTextAreaElement placeholder(this HTMLTextAreaElement element, string value) => element.attr("placeholder", value);
    public static HTMLTextAreaElement required(this HTMLTextAreaElement element, bool value = true) => value ? element.attr("required", "required") : element;
    public static HTMLTextAreaElement disabled(this HTMLTextAreaElement element, bool value = true) => value ? element.attr("disabled", "disabled") : element;
    public static HTMLTextAreaElement @readonly(this HTMLTextAreaElement element, bool value = true) => value ? element.attr("readonly", "readonly") : element;
    public static HTMLTextAreaElement autofocus(this HTMLTextAreaElement element, bool value = true) => value ? element.attr("autofocus", "autofocus") : element;
    public static HTMLTextAreaElement maxlength(this HTMLTextAreaElement element, int value) => element.attr("maxlength", value.ToString());
    public static HTMLTextAreaElement minlength(this HTMLTextAreaElement element, int value) => element.attr("minlength", value.ToString());
    public static HTMLTextAreaElement wrap(this HTMLTextAreaElement element, string value) => element.attr("wrap", value);
    public static HTMLTextAreaElement form(this HTMLTextAreaElement element, string value) => element.attr("form", value);
    public static HTMLTextAreaElement autocomplete(this HTMLTextAreaElement element, string value) => element.attr("autocomplete", value);
    public static HTMLTextAreaElement spellcheck(this HTMLTextAreaElement element, bool value) => element.attr("spellcheck", value.ToString().ToLower());
}