using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLLinkElement : Element
{
    public HTMLLinkElement() : base("link")
    {
    }
}

public static class HTMLLinkElementExtensions
{
    public static HTMLLinkElement href(this HTMLLinkElement element, string value) => element.attr("href", value);
    public static HTMLLinkElement rel(this HTMLLinkElement element, string value) => element.attr("rel", value);
    public static HTMLLinkElement type(this HTMLLinkElement element, string value) => element.attr("type", value);
    public static HTMLLinkElement media(this HTMLLinkElement element, string value) => element.attr("media", value);
    public static HTMLLinkElement sizes(this HTMLLinkElement element, string value) => element.attr("sizes", value);
    public static HTMLLinkElement integrity(this HTMLLinkElement element, string value) => element.attr("integrity", value);
    public static HTMLLinkElement crossorigin(this HTMLLinkElement element, string value) => element.attr("crossorigin", value);
    public static HTMLLinkElement hreflang(this HTMLLinkElement element, string value) => element.attr("hreflang", value);
    public static HTMLLinkElement referrerpolicy(this HTMLLinkElement element, string value) => element.attr("referrerpolicy", value);
}