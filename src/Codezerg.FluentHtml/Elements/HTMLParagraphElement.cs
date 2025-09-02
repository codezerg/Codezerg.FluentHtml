using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLParagraphElement : Element
{
    public HTMLParagraphElement() : base("p")
    {
    }
}

public static class HTMLParagraphElementExtensions
{
    public static HTMLParagraphElement align(this HTMLParagraphElement element, string value) => element.attr("align", value);
}