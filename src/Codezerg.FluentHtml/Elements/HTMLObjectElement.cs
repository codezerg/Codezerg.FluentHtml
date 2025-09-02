using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLObjectElement : Element
{
    public HTMLObjectElement() : base("object")
    {
    }
}

public static class HTMLObjectElementExtensions
{
    public static HTMLObjectElement data(this HTMLObjectElement element, string value) => element.attr("data", value);
    public static HTMLObjectElement type(this HTMLObjectElement element, string value) => element.attr("type", value);
    public static HTMLObjectElement name(this HTMLObjectElement element, string value) => element.attr("name", value);
    public static HTMLObjectElement width(this HTMLObjectElement element, string value) => element.attr("width", value);
    public static HTMLObjectElement height(this HTMLObjectElement element, string value) => element.attr("height", value);
    public static HTMLObjectElement usemap(this HTMLObjectElement element, string value) => element.attr("usemap", value);
    public static HTMLObjectElement form(this HTMLObjectElement element, string value) => element.attr("form", value);
}