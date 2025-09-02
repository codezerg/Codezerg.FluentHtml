using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLFieldSetElement : Element
{
    public HTMLFieldSetElement() : base("fieldset")
    {
    }
}

public static class HTMLFieldSetElementExtensions
{
    public static HTMLFieldSetElement disabled(this HTMLFieldSetElement element, bool value = true) => value ? element.attr("disabled", "disabled") : element;
    public static HTMLFieldSetElement form(this HTMLFieldSetElement element, string value) => element.attr("form", value);
    public static HTMLFieldSetElement name(this HTMLFieldSetElement element, string value) => element.attr("name", value);
}