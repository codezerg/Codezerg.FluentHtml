using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLVideoElement : Element
{
    public HTMLVideoElement() : base("video")
    {
    }
}

public static class HTMLVideoElementExtensions
{
    public static HTMLVideoElement src(this HTMLVideoElement element, string value) => element.attr("src", value);
    public static HTMLVideoElement controls(this HTMLVideoElement element, bool value = true) => value ? element.attr("controls", "controls") : element;
    public static HTMLVideoElement autoplay(this HTMLVideoElement element, bool value = true) => value ? element.attr("autoplay", "autoplay") : element;
    public static HTMLVideoElement loop(this HTMLVideoElement element, bool value = true) => value ? element.attr("loop", "loop") : element;
    public static HTMLVideoElement muted(this HTMLVideoElement element, bool value = true) => value ? element.attr("muted", "muted") : element;
    public static HTMLVideoElement preload(this HTMLVideoElement element, string value) => element.attr("preload", value);
    public static HTMLVideoElement poster(this HTMLVideoElement element, string value) => element.attr("poster", value);
    public static HTMLVideoElement width(this HTMLVideoElement element, int value) => element.attr("width", value.ToString());
    public static HTMLVideoElement height(this HTMLVideoElement element, int value) => element.attr("height", value.ToString());
    public static HTMLVideoElement playsinline(this HTMLVideoElement element, bool value = true) => value ? element.attr("playsinline", "playsinline") : element;
    public static HTMLVideoElement crossorigin(this HTMLVideoElement element, string value) => element.attr("crossorigin", value);
}