using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLBlockQuoteElement : Element
{
    public HTMLBlockQuoteElement() : base("blockquote")
    {
    }
}

public static class HTMLBlockQuoteElementExtensions
{
    public static HTMLBlockQuoteElement cite(this HTMLBlockQuoteElement element, string value) => element.attr("cite", value);
}