using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableColElement : Element
{
    public HTMLTableColElement() : base("col")
    {
    }
}

public static class HTMLTableColElementExtensions
{
    public static HTMLTableColElement span(this HTMLTableColElement element, int value) => element.attr("span", value.ToString());
    public static HTMLTableColElement align(this HTMLTableColElement element, string value) => element.attr("align", value);
    public static HTMLTableColElement valign(this HTMLTableColElement element, string value) => element.attr("valign", value);
    public static HTMLTableColElement width(this HTMLTableColElement element, string value) => element.attr("width", value);
}