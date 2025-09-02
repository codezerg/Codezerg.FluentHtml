using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLPreElement : Element
{
    public HTMLPreElement() : base("pre")
    {
    }
}

public static class HTMLPreElementExtensions
{
    public static HTMLPreElement width(this HTMLPreElement element, string value) => element.attr("width", value);
}