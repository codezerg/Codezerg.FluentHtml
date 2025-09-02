using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLSourceElement : Element
{
    public HTMLSourceElement() : base("source")
    {
    }
}

public static class HTMLSourceElementExtensions
{
    public static HTMLSourceElement src(this HTMLSourceElement element, string value) => element.attr("src", value);
    public static HTMLSourceElement type(this HTMLSourceElement element, string value) => element.attr("type", value);
    public static HTMLSourceElement srcset(this HTMLSourceElement element, string value) => element.attr("srcset", value);
    public static HTMLSourceElement sizes(this HTMLSourceElement element, string value) => element.attr("sizes", value);
    public static HTMLSourceElement media(this HTMLSourceElement element, string value) => element.attr("media", value);
}