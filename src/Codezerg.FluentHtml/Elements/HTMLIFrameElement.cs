using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLIFrameElement : Element
{
    public HTMLIFrameElement() : base("iframe")
    {
    }
}

public static class HTMLIFrameElementExtensions
{
    public static HTMLIFrameElement src(this HTMLIFrameElement element, string value) => element.attr("src", value);
    public static HTMLIFrameElement srcdoc(this HTMLIFrameElement element, string value) => element.attr("srcdoc", value);
    public static HTMLIFrameElement name(this HTMLIFrameElement element, string value) => element.attr("name", value);
    public static HTMLIFrameElement width(this HTMLIFrameElement element, string value) => element.attr("width", value);
    public static HTMLIFrameElement height(this HTMLIFrameElement element, string value) => element.attr("height", value);
    public static HTMLIFrameElement allow(this HTMLIFrameElement element, string value) => element.attr("allow", value);
    public static HTMLIFrameElement allowfullscreen(this HTMLIFrameElement element, bool value = true) => value ? element.attr("allowfullscreen", "allowfullscreen") : element;
    public static HTMLIFrameElement allowpaymentrequest(this HTMLIFrameElement element, bool value = true) => value ? element.attr("allowpaymentrequest", "allowpaymentrequest") : element;
    public static HTMLIFrameElement loading(this HTMLIFrameElement element, string value) => element.attr("loading", value);
    public static HTMLIFrameElement referrerpolicy(this HTMLIFrameElement element, string value) => element.attr("referrerpolicy", value);
    public static HTMLIFrameElement sandbox(this HTMLIFrameElement element, string value) => element.attr("sandbox", value);
}