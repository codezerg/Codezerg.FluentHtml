using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLDetailsElement : Element
{
    public HTMLDetailsElement() : base("details")
    {
    }
}

public static class HTMLDetailsElementExtensions
{
    public static HTMLDetailsElement open(this HTMLDetailsElement element, bool value = true) => value ? element.attr("open", "open") : element;
}