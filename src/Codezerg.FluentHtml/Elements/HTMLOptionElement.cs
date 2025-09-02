using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLOptionElement : Element
{
    public HTMLOptionElement() : base("option")
    {
    }
}

public static class HTMLOptionElementExtensions
{
    public static HTMLOptionElement value(this HTMLOptionElement element, string value) => element.attr("value", value);
    public static HTMLOptionElement selected(this HTMLOptionElement element, bool value = true) => value ? element.attr("selected", "selected") : element;
    public static HTMLOptionElement disabled(this HTMLOptionElement element, bool value = true) => value ? element.attr("disabled", "disabled") : element;
    public static HTMLOptionElement label(this HTMLOptionElement element, string value) => element.attr("label", value);
}