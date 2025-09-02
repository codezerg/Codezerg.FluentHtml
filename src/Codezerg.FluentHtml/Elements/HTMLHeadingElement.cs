using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLHeadingElement : Element
{
    public HTMLHeadingElement(int level) : base($"h{level}")
    {
        if (level < 1 || level > 6)
            throw new ArgumentOutOfRangeException(nameof(level), "Heading level must be between 1 and 6");
    }
}

public static class HTMLHeadingElementExtensions
{
    public static HTMLHeadingElement align(this HTMLHeadingElement element, string value) => element.attr("align", value);
}