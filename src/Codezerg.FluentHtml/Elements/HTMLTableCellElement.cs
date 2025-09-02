using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTableCellElement : Element
{
    public HTMLTableCellElement(string tagName) : base(tagName)
    {
    }
}

public static class HTMLTableCellElementExtensions
{
    public static HTMLTableCellElement colspan(this HTMLTableCellElement element, int value) => element.attr("colspan", value.ToString());
    public static HTMLTableCellElement rowspan(this HTMLTableCellElement element, int value) => element.attr("rowspan", value.ToString());
    public static HTMLTableCellElement headers(this HTMLTableCellElement element, string value) => element.attr("headers", value);
    public static HTMLTableCellElement scope(this HTMLTableCellElement element, string value) => element.attr("scope", value);
    public static HTMLTableCellElement abbr(this HTMLTableCellElement element, string value) => element.attr("abbr", value);
    public static HTMLTableCellElement align(this HTMLTableCellElement element, string value) => element.attr("align", value);
    public static HTMLTableCellElement valign(this HTMLTableCellElement element, string value) => element.attr("valign", value);
    public static HTMLTableCellElement nowrap(this HTMLTableCellElement element, bool value = true) => value ? element.attr("nowrap", "nowrap") : element;
    public static HTMLTableCellElement width(this HTMLTableCellElement element, string value) => element.attr("width", value);
    public static HTMLTableCellElement height(this HTMLTableCellElement element, string value) => element.attr("height", value);
}