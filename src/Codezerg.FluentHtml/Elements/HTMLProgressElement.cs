using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLProgressElement : Element
{
    public HTMLProgressElement() : base("progress")
    {
    }
}

public static class HTMLProgressElementExtensions
{
    public static HTMLProgressElement value(this HTMLProgressElement element, string value) => element.attr("value", value);
    public static HTMLProgressElement max(this HTMLProgressElement element, string value) => element.attr("max", value);
}