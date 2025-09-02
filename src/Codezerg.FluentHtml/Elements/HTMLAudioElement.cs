using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLAudioElement : Element
{
    public HTMLAudioElement() : base("audio")
    {
    }
}

public static class HTMLAudioElementExtensions
{
    public static HTMLAudioElement src(this HTMLAudioElement element, string value) => element.attr("src", value);
    public static HTMLAudioElement controls(this HTMLAudioElement element, bool value = true) => value ? element.attr("controls", "controls") : element;
    public static HTMLAudioElement autoplay(this HTMLAudioElement element, bool value = true) => value ? element.attr("autoplay", "autoplay") : element;
    public static HTMLAudioElement loop(this HTMLAudioElement element, bool value = true) => value ? element.attr("loop", "loop") : element;
    public static HTMLAudioElement muted(this HTMLAudioElement element, bool value = true) => value ? element.attr("muted", "muted") : element;
    public static HTMLAudioElement preload(this HTMLAudioElement element, string value) => element.attr("preload", value);
    public static HTMLAudioElement crossorigin(this HTMLAudioElement element, string value) => element.attr("crossorigin", value);
}