using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLAnchorElement : Element
{
    public HTMLAnchorElement() : base("a")
    {
    }
}

public static class HTMLAnchorElementExtensions
{
    public static HTMLAnchorElement href(this HTMLAnchorElement element, string value) => element.attr("href", value);
    public static HTMLAnchorElement target(this HTMLAnchorElement element, string value) => element.attr("target", value);
    public static HTMLAnchorElement download(this HTMLAnchorElement element, string value = "") => element.attr("download", value);
    public static HTMLAnchorElement ping(this HTMLAnchorElement element, string value) => element.attr("ping", value);
    public static HTMLAnchorElement hreflang(this HTMLAnchorElement element, string value) => element.attr("hreflang", value);
    public static HTMLAnchorElement referrerpolicy(this HTMLAnchorElement element, string value) => element.attr("referrerpolicy", value);
    public static HTMLAnchorElement rel(this HTMLAnchorElement element, string value) => element.attr("rel", value);
    public static HTMLAnchorElement type(this HTMLAnchorElement element, string value) => element.attr("type", value);
}