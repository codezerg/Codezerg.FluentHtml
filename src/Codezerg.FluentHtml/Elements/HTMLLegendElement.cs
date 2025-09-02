using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLLegendElement : Element
{
    public HTMLLegendElement() : base("legend")
    {
    }
}

public static class HTMLLegendElementExtensions
{
    public static HTMLLegendElement align(this HTMLLegendElement element, string value) => element.attr("align", value);
}