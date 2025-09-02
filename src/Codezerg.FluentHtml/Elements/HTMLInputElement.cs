using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLInputElement : Element
{
    public HTMLInputElement() : base("input")
    {
    }
}

public static class HTMLInputElementExtensions
{
    public static HTMLInputElement type(this HTMLInputElement element, string value) => element.attr("type", value);
    public static HTMLInputElement name(this HTMLInputElement element, string value) => element.attr("name", value);
    public static HTMLInputElement value(this HTMLInputElement element, string value) => element.attr("value", value);
    public static HTMLInputElement placeholder(this HTMLInputElement element, string value) => element.attr("placeholder", value);
    public static HTMLInputElement required(this HTMLInputElement element, bool value = true) => value ? element.attr("required", "required") : element;
    public static HTMLInputElement disabled(this HTMLInputElement element, bool value = true) => value ? element.attr("disabled", "disabled") : element;
    public static HTMLInputElement @readonly(this HTMLInputElement element, bool value = true) => value ? element.attr("readonly", "readonly") : element;
    public static HTMLInputElement @checked(this HTMLInputElement element, bool value = true) => value ? element.attr("checked", "checked") : element;
    public static HTMLInputElement autofocus(this HTMLInputElement element, bool value = true) => value ? element.attr("autofocus", "autofocus") : element;
    public static HTMLInputElement autocomplete(this HTMLInputElement element, string value) => element.attr("autocomplete", value);
    public static HTMLInputElement min(this HTMLInputElement element, string value) => element.attr("min", value);
    public static HTMLInputElement max(this HTMLInputElement element, string value) => element.attr("max", value);
    public static HTMLInputElement step(this HTMLInputElement element, string value) => element.attr("step", value);
    public static HTMLInputElement pattern(this HTMLInputElement element, string value) => element.attr("pattern", value);
    public static HTMLInputElement maxlength(this HTMLInputElement element, int value) => element.attr("maxlength", value.ToString());
    public static HTMLInputElement minlength(this HTMLInputElement element, int value) => element.attr("minlength", value.ToString());
    public static HTMLInputElement size(this HTMLInputElement element, int value) => element.attr("size", value.ToString());
    public static HTMLInputElement multiple(this HTMLInputElement element, bool value = true) => value ? element.attr("multiple", "multiple") : element;
    public static HTMLInputElement accept(this HTMLInputElement element, string value) => element.attr("accept", value);
    public static HTMLInputElement form(this HTMLInputElement element, string value) => element.attr("form", value);
    public static HTMLInputElement list(this HTMLInputElement element, string value) => element.attr("list", value);
}