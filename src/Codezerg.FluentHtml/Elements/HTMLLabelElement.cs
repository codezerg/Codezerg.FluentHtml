using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLLabelElement : Element
{
    public HTMLLabelElement() : base("label")
    {
    }
}

public static class HTMLLabelElementExtensions
{
    public static HTMLLabelElement @for(this HTMLLabelElement element, string value) => element.attr("for", value);
    public static HTMLLabelElement form(this HTMLLabelElement element, string value) => element.attr("form", value);
}