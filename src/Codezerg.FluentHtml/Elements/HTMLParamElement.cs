using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLParamElement : Element
{
    public HTMLParamElement() : base("param")
    {
    }
}

public static class HTMLParamElementExtensions
{
    public static HTMLParamElement name(this HTMLParamElement element, string value) => element.attr("name", value);
    public static HTMLParamElement value(this HTMLParamElement element, string value) => element.attr("value", value);
}