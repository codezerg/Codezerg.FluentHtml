using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTimeElement : Element
{
    public HTMLTimeElement() : base("time")
    {
    }
}

public static class HTMLTimeElementExtensions
{
    public static HTMLTimeElement datetime(this HTMLTimeElement element, string value) => element.attr("datetime", value);
}