using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLDivElement : Element
{
    public HTMLDivElement() : base("div")
    {
    }
}

public static class HTMLDivElementExtensions
{
    public static HTMLDivElement align(this HTMLDivElement element, string value) => element.attr("align", value);
}