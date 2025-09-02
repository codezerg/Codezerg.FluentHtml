using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableCaptionElement : Element
{
    public HTMLTableCaptionElement() : base("caption")
    {
    }
}

public static class HTMLTableCaptionElementExtensions
{
    public static HTMLTableCaptionElement align(this HTMLTableCaptionElement element, string value) => element.attr("align", value);
}