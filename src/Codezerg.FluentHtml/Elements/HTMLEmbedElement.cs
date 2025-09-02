using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLEmbedElement : Element
{
    public HTMLEmbedElement() : base("embed")
    {
    }
}

public static class HTMLEmbedElementExtensions
{
    public static HTMLEmbedElement src(this HTMLEmbedElement element, string value) => element.attr("src", value);
    public static HTMLEmbedElement type(this HTMLEmbedElement element, string value) => element.attr("type", value);
    public static HTMLEmbedElement width(this HTMLEmbedElement element, string value) => element.attr("width", value);
    public static HTMLEmbedElement height(this HTMLEmbedElement element, string value) => element.attr("height", value);
}