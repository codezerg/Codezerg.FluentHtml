using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLMeterElement : Element
{
    public HTMLMeterElement() : base("meter")
    {
    }
}

public static class HTMLMeterElementExtensions
{
    public static HTMLMeterElement value(this HTMLMeterElement element, string value) => element.attr("value", value);
    public static HTMLMeterElement min(this HTMLMeterElement element, string value) => element.attr("min", value);
    public static HTMLMeterElement max(this HTMLMeterElement element, string value) => element.attr("max", value);
    public static HTMLMeterElement low(this HTMLMeterElement element, string value) => element.attr("low", value);
    public static HTMLMeterElement high(this HTMLMeterElement element, string value) => element.attr("high", value);
    public static HTMLMeterElement optimum(this HTMLMeterElement element, string value) => element.attr("optimum", value);
    public static HTMLMeterElement form(this HTMLMeterElement element, string value) => element.attr("form", value);
}