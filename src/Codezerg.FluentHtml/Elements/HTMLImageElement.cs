using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLImageElement : Element
{
    public HTMLImageElement() : base("img")
    {
    }
}

public static class HTMLImageElementExtensions
{
    public static HTMLImageElement src(this HTMLImageElement element, string value) => element.attr("src", value);
    public static HTMLImageElement alt(this HTMLImageElement element, string value) => element.attr("alt", value);
    public static HTMLImageElement width(this HTMLImageElement element, string value) => element.attr("width", value);
    public static HTMLImageElement height(this HTMLImageElement element, string value) => element.attr("height", value);
    public static HTMLImageElement srcset(this HTMLImageElement element, string value) => element.attr("srcset", value);
    public static HTMLImageElement sizes(this HTMLImageElement element, string value) => element.attr("sizes", value);
    public static HTMLImageElement loading(this HTMLImageElement element, string value) => element.attr("loading", value);
    public static HTMLImageElement decoding(this HTMLImageElement element, string value) => element.attr("decoding", value);
    public static HTMLImageElement crossorigin(this HTMLImageElement element, string value) => element.attr("crossorigin", value);
    public static HTMLImageElement usemap(this HTMLImageElement element, string value) => element.attr("usemap", value);
    public static HTMLImageElement ismap(this HTMLImageElement element, bool value = true) => value ? element.attr("ismap", "ismap") : element;
    public static HTMLImageElement referrerpolicy(this HTMLImageElement element, string value) => element.attr("referrerpolicy", value);
}