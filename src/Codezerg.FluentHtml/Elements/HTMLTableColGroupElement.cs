using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableColGroupElement : Element
{
    public HTMLTableColGroupElement() : base("colgroup")
    {
    }
}

public static class HTMLTableColGroupElementExtensions
{
    public static HTMLTableColGroupElement span(this HTMLTableColGroupElement element, int value) => element.attr("span", value.ToString());
    public static HTMLTableColGroupElement align(this HTMLTableColGroupElement element, string value) => element.attr("align", value);
    public static HTMLTableColGroupElement valign(this HTMLTableColGroupElement element, string value) => element.attr("valign", value);
    public static HTMLTableColGroupElement width(this HTMLTableColGroupElement element, string value) => element.attr("width", value);
}