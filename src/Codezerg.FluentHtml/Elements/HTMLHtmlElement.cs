using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLHtmlElement : Element
{
    public HTMLHtmlElement() : base("html")
    {
    }
}

public static class HTMLHtmlElementExtensions
{
    public static HTMLHtmlElement version(this HTMLHtmlElement element, string value) => element.attr("version", value);
    public static HTMLHtmlElement xmlns(this HTMLHtmlElement element, string value) => element.attr("xmlns", value);
}