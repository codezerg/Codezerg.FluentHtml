using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableSectionElement : Element
{
    public HTMLTableSectionElement(string tagName) : base(tagName)
    {
    }
}

public static class HTMLTableSectionElementExtensions
{
    public static HTMLTableSectionElement align(this HTMLTableSectionElement element, string value) => element.attr("align", value);
    public static HTMLTableSectionElement valign(this HTMLTableSectionElement element, string value) => element.attr("valign", value);
}