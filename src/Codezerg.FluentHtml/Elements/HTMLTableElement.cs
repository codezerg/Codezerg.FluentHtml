using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableElement : Element
{
    public HTMLTableElement() : base("table")
    {
    }
}

public static class HTMLTableElementExtensions
{
    public static HTMLTableElement border(this HTMLTableElement element, string value) => element.attr("border", value);
    public static HTMLTableElement cellpadding(this HTMLTableElement element, string value) => element.attr("cellpadding", value);
    public static HTMLTableElement cellspacing(this HTMLTableElement element, string value) => element.attr("cellspacing", value);
    public static HTMLTableElement summary(this HTMLTableElement element, string value) => element.attr("summary", value);
}