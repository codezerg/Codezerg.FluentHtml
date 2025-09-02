using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLScriptElement : Element
{
    public HTMLScriptElement() : base("script")
    {
    }
}

public static class HTMLScriptElementExtensions
{
    public static HTMLScriptElement src(this HTMLScriptElement element, string value) => element.attr("src", value);
    public static HTMLScriptElement type(this HTMLScriptElement element, string value) => element.attr("type", value);
    public static HTMLScriptElement async(this HTMLScriptElement element, bool value = true) => value ? element.attr("async", "async") : element;
    public static HTMLScriptElement defer(this HTMLScriptElement element, bool value = true) => value ? element.attr("defer", "defer") : element;
    public static HTMLScriptElement crossorigin(this HTMLScriptElement element, string value) => element.attr("crossorigin", value);
    public static HTMLScriptElement integrity(this HTMLScriptElement element, string value) => element.attr("integrity", value);
    public static HTMLScriptElement nomodule(this HTMLScriptElement element, bool value = true) => value ? element.attr("nomodule", "nomodule") : element;
    public static HTMLScriptElement referrerpolicy(this HTMLScriptElement element, string value) => element.attr("referrerpolicy", value);
    public static HTMLScriptElement nonce(this HTMLScriptElement element, string value) => element.attr("nonce", value);
}