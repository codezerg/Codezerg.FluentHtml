using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLDelElement : Element
{
    public HTMLDelElement() : base("del")
    {
    }
}

public static class HTMLDelElementExtensions
{
    public static HTMLDelElement cite(this HTMLDelElement element, string value) => element.attr("cite", value);
    public static HTMLDelElement datetime(this HTMLDelElement element, string value) => element.attr("datetime", value);
}