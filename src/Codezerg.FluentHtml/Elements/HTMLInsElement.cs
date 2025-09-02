using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLInsElement : Element
{
    public HTMLInsElement() : base("ins")
    {
    }
}

public static class HTMLInsElementExtensions
{
    public static HTMLInsElement cite(this HTMLInsElement element, string value) => element.attr("cite", value);
    public static HTMLInsElement datetime(this HTMLInsElement element, string value) => element.attr("datetime", value);
}