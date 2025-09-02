using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLMetaElement : Element
{
    public HTMLMetaElement() : base("meta")
    {
    }
}

public static class MetaElementExtensions
{
    public static HTMLMetaElement charset(this HTMLMetaElement element, string value) => element.attr("charset", value);
    public static HTMLMetaElement content(this HTMLMetaElement element, string value) => element.attr("content", value);
    public static HTMLMetaElement http_equiv(this HTMLMetaElement element, string value) => element.attr("http-equiv", value);
    public static HTMLMetaElement media(this HTMLMetaElement element, string value) => element.attr("media", value);
    public static HTMLMetaElement name(this HTMLMetaElement element, string value) => element.attr("name", value);
}