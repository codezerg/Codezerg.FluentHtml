using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLTrackElement : Element
{
    public HTMLTrackElement() : base("track")
    {
    }
}

public static class HTMLTrackElementExtensions
{
    public static HTMLTrackElement src(this HTMLTrackElement element, string value) => element.attr("src", value);
    public static HTMLTrackElement kind(this HTMLTrackElement element, string value) => element.attr("kind", value);
    public static HTMLTrackElement srclang(this HTMLTrackElement element, string value) => element.attr("srclang", value);
    public static HTMLTrackElement label(this HTMLTrackElement element, string value) => element.attr("label", value);
    public static HTMLTrackElement @default(this HTMLTrackElement element, bool value = true) => value ? element.attr("default", "default") : element;
}