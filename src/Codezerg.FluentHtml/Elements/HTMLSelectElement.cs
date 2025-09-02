using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLSelectElement : Element
{
    public HTMLSelectElement() : base("select")
    {
    }
}

public static class HTMLSelectElementExtensions
{
    public static HTMLSelectElement name(this HTMLSelectElement element, string value) => element.attr("name", value);
    public static HTMLSelectElement multiple(this HTMLSelectElement element, bool value = true) => value ? element.attr("multiple", "multiple") : element;
    public static HTMLSelectElement size(this HTMLSelectElement element, int value) => element.attr("size", value.ToString());
    public static HTMLSelectElement required(this HTMLSelectElement element, bool value = true) => value ? element.attr("required", "required") : element;
    public static HTMLSelectElement disabled(this HTMLSelectElement element, bool value = true) => value ? element.attr("disabled", "disabled") : element;
    public static HTMLSelectElement autofocus(this HTMLSelectElement element, bool value = true) => value ? element.attr("autofocus", "autofocus") : element;
    public static HTMLSelectElement form(this HTMLSelectElement element, string value) => element.attr("form", value);
    public static HTMLSelectElement autocomplete(this HTMLSelectElement element, string value) => element.attr("autocomplete", value);
}