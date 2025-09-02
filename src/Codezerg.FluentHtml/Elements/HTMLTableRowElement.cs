using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableRowElement : Element
{
    public HTMLTableRowElement() : base("tr")
    {
    }
}

public static class HTMLTableRowElementExtensions
{
    public static HTMLTableRowElement align(this HTMLTableRowElement element, string value) => element.attr("align", value);
    public static HTMLTableRowElement valign(this HTMLTableRowElement element, string value) => element.attr("valign", value);
    public static HTMLTableRowElement bgcolor(this HTMLTableRowElement element, string value) => element.attr("bgcolor", value);
}