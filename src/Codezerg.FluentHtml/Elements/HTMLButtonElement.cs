using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLButtonElement : Element
{
    public HTMLButtonElement(params Node[] children) : base("button")
    {
    }
}

public static class HTMLButtonElementExtensions
{
    public static HTMLButtonElement type(this HTMLButtonElement element, string value) => element.attr("type", value);
    public static HTMLButtonElement name(this HTMLButtonElement element, string value) => element.attr("name", value);
    public static HTMLButtonElement value(this HTMLButtonElement element, string value) => element.attr("value", value);
    public static HTMLButtonElement disabled(this HTMLButtonElement element, bool value = true) => value ? element.attr("disabled", "disabled") : element;
    public static HTMLButtonElement form(this HTMLButtonElement element, string value) => element.attr("form", value);
    public static HTMLButtonElement formaction(this HTMLButtonElement element, string value) => element.attr("formaction", value);
    public static HTMLButtonElement formenctype(this HTMLButtonElement element, string value) => element.attr("formenctype", value);
    public static HTMLButtonElement formmethod(this HTMLButtonElement element, string value) => element.attr("formmethod", value);
    public static HTMLButtonElement formnovalidate(this HTMLButtonElement element, bool value = true) => value ? element.attr("formnovalidate", "formnovalidate") : element;
    public static HTMLButtonElement formtarget(this HTMLButtonElement element, string value) => element.attr("formtarget", value);
    public static HTMLButtonElement autofocus(this HTMLButtonElement element, bool value = true) => value ? element.attr("autofocus", "autofocus") : element;
}