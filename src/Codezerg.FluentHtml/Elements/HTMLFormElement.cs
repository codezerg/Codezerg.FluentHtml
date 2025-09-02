using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLFormElement : Element
{
    public HTMLFormElement() : base("form")
    {
    }
}

public static class HTMLFormElementExtensions
{
    public static HTMLFormElement action(this HTMLFormElement element, string value) => element.attr("action", value);
    public static HTMLFormElement method(this HTMLFormElement element, string value) => element.attr("method", value);
    public static HTMLFormElement enctype(this HTMLFormElement element, string value) => element.attr("enctype", value);
    public static HTMLFormElement target(this HTMLFormElement element, string value) => element.attr("target", value);
    public static HTMLFormElement name(this HTMLFormElement element, string value) => element.attr("name", value);
    public static HTMLFormElement novalidate(this HTMLFormElement element, bool value = true) => value ? element.attr("novalidate", "novalidate") : element;
    public static HTMLFormElement autocomplete(this HTMLFormElement element, string value) => element.attr("autocomplete", value);
    public static HTMLFormElement accept_charset(this HTMLFormElement element, string value) => element.attr("accept-charset", value);
}