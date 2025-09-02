using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLDataElement : Element
{
    public HTMLDataElement() : base("data")
    {
    }
}

public static class HTMLDataElementExtensions
{
    public static HTMLDataElement value(this HTMLDataElement element, string value) => element.attr("value", value);
}