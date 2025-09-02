using System.Linq;

namespace Codezerg.FluentHtml;

public static class Html
{
    /// <summary>
    /// Convenience helper to include HTMX.
    /// Adds: &lt;script src=&quot;https://unpkg.com/htmx.org&quot;&gt;&lt;/script&gt;
    /// </summary>
    public static HTMLScriptElement htmx(string version = null)
    {
        var src = "https://unpkg.com/htmx.org";
        if (!string.IsNullOrEmpty(version))
        {
            src += $"@{version}";
        }
        return new HTMLScriptElement().src(src);
    }

    // Document structure
    public static HTMLHtmlElement html(params Node[] children) => new HTMLHtmlElement().content(children);

    public static Element head(params Node[] children) => new Element("head").content(children);

    public static Element body(params Node[] children) => new Element("body").content(children);

    // Metadata - parameterless
    public static Element title(params Node[] children) => new Element("title").content(children);

    public static HTMLMetaElement meta() => new HTMLMetaElement();

    public static HTMLLinkElement link() => new HTMLLinkElement();

    public static Element @base() => new Element("base");

    // Headings - with children overload
    public static HTMLHeadingElement h1(params Node[] children) => new HTMLHeadingElement(1).content(children);

    public static HTMLHeadingElement h2(params Node[] children) => new HTMLHeadingElement(2).content(children);

    public static HTMLHeadingElement h3(params Node[] children) => new HTMLHeadingElement(3).content(children);

    public static HTMLHeadingElement h4(params Node[] children) => new HTMLHeadingElement(4).content(children);

    public static HTMLHeadingElement h5(params Node[] children) => new HTMLHeadingElement(5).content(children);

    public static HTMLHeadingElement h6(params Node[] children) => new HTMLHeadingElement(6).content(children);

    // Text content
    public static HTMLParagraphElement p(params Node[] children) => new HTMLParagraphElement().content(children);

    public static HTMLDivElement div(params Node[] children) => new HTMLDivElement().content(children);

    public static HTMLSpanElement span(params Node[] children) => new HTMLSpanElement().content(children);

    public static HTMLStrongElement strong(params Node[] children) => new HTMLStrongElement().content(children);

    public static HTMLEmElement em(params Node[] children) => new HTMLEmElement().content(children);

    public static HTMLSmallElement small(params Node[] children) => new HTMLSmallElement().content(children);

    public static HTMLMarkElement mark(params Node[] children) => new HTMLMarkElement().content(children);

    public static HTMLDelElement del(params Node[] children) => new HTMLDelElement().content(children);

    public static HTMLInsElement ins(params Node[] children) => new HTMLInsElement().content(children);

    public static HTMLSubElement sub(params Node[] children) => new HTMLSubElement().content(children);

    public static HTMLSupElement sup(params Node[] children) => new HTMLSupElement().content(children);

    // Forms - parameterless
    public static HTMLFormElement form(params Node[] children) => new HTMLFormElement().content(children);

    public static HTMLInputElement input() => new HTMLInputElement();

    public static HTMLTextAreaElement textarea() => new HTMLTextAreaElement();

    public static HTMLButtonElement button(params Node[] children) => new HTMLButtonElement().content(children);

    public static HTMLSelectElement select(params Node[] children) => new HTMLSelectElement().content(children);

    public static HTMLOptionElement option(params Node[] children) => new HTMLOptionElement().content(children);

    public static HTMLLabelElement label(params Node[] children) => new HTMLLabelElement().content(children);

    public static HTMLFieldSetElement fieldset(params Node[] children) => new HTMLFieldSetElement().content(children);

    public static HTMLLegendElement legend(params Node[] children) => new HTMLLegendElement().content(children);

    // Lists
    public static Element ul(params Node[] children) => new Element("ul").content(children);

    public static Element ol(params Node[] children) => new Element("ol").content(children);

    public static Element li(params Node[] children) => new Element("li").content(children);

    public static Element dl(params Node[] children) => new Element("dl").content(children);

    public static Element dt(params Node[] children) => new Element("dt").content(children);

    public static Element dd(params Node[] children) => new Element("dd").content(children);

    // Links
    public static HTMLAnchorElement a(params Node[] children) => new HTMLAnchorElement().content(children);

    // Media - parameterless
    public static HTMLImageElement img() => new HTMLImageElement();

    public static HTMLAudioElement audio(params Node[] children) => new HTMLAudioElement().content(children);

    public static HTMLVideoElement video(params Node[] children) => new HTMLVideoElement().content(children);

    public static HTMLSourceElement source() => new HTMLSourceElement();

    public static HTMLTrackElement track() => new HTMLTrackElement();

    public static HTMLEmbedElement embed() => new HTMLEmbedElement();

    public static HTMLObjectElement @object(params Node[] children) => new HTMLObjectElement().content(children);

    public static HTMLParamElement param() => new HTMLParamElement();

    // Inline frames
    public static HTMLIFrameElement iframe(params Node[] children) => new HTMLIFrameElement().content(children);

    // Line breaks - parameterless
    public static Element br() => new Element("br");

    public static Element hr() => new Element("hr");

    public static Element wbr() => new Element("wbr");

    // Tables
    public static HTMLTableElement table(params Node[] children) => new HTMLTableElement().content(children);

    public static HTMLTableSectionElement thead(params Node[] children) => new HTMLTableSectionElement("thead").content(children);

    public static HTMLTableSectionElement tbody(params Node[] children) => new HTMLTableSectionElement("tbody").content(children);

    public static HTMLTableSectionElement tfoot(params Node[] children) => new HTMLTableSectionElement("tfoot").content(children);

    public static HTMLTableRowElement tr(params Node[] children) => new HTMLTableRowElement().content(children);

    public static HTMLTableCellElement th(params Node[] children) => new HTMLTableCellElement("th").content(children);

    public static HTMLTableCellElement td(params Node[] children) => new HTMLTableCellElement("td").content(children);

    public static HTMLTableCaptionElement caption(params Node[] children) => new HTMLTableCaptionElement().content(children);

    public static HTMLTableColElement col() => new HTMLTableColElement();

    public static HTMLTableColGroupElement colgroup(params Node[] children) => new HTMLTableColGroupElement().content(children);

    // Sections
    public static HTMLSectionElement section(params Node[] children) => new HTMLSectionElement().content(children);

    public static HTMLArticleElement article(params Node[] children) => new HTMLArticleElement().content(children);

    public static HTMLHeaderElement header(params Node[] children) => new HTMLHeaderElement().content(children);

    public static HTMLFooterElement footer(params Node[] children) => new HTMLFooterElement().content(children);

    public static HTMLNavElement nav(params Node[] children) => new HTMLNavElement().content(children);

    public static Element main(params Node[] children) => new Element("main").content(children);

    public static HTMLAsideElement aside(params Node[] children) => new HTMLAsideElement().content(children);

    public static HTMLAddressElement address(params Node[] children) => new HTMLAddressElement().content(children);

    // Grouping
    public static HTMLPreElement pre(params Node[] children) => new HTMLPreElement().content(children);

    public static HTMLBlockQuoteElement blockquote(params Node[] children) => new HTMLBlockQuoteElement().content(children);

    public static HTMLFigureElement figure(params Node[] children) => new HTMLFigureElement().content(children);

    public static HTMLFigCaptionElement figcaption(params Node[] children) => new HTMLFigCaptionElement().content(children);

    // Code
    public static HTMLCodeElement code(params Node[] children) => new HTMLCodeElement().content(children);

    public static HTMLKbdElement kbd(params Node[] children) => new HTMLKbdElement().content(children);

    public static HTMLSampElement samp(params Node[] children) => new HTMLSampElement().content(children);

    public static HTMLVarElement @var(params Node[] children) => new HTMLVarElement().content(children);

    // Time
    public static HTMLTimeElement time(params Node[] children) => new HTMLTimeElement().content(children);

    // Ruby annotations
    public static Element ruby(params Node[] children) => new Element("ruby").content(children);

    public static Element rt(params Node[] children) => new Element("rt").content(children);

    public static Element rp(params Node[] children) => new Element("rp").content(children);

    // Interactive
    public static HTMLDetailsElement details(params Node[] children) => new HTMLDetailsElement().content(children);

    public static Element summary(params Node[] children) => new Element("summary").content(children);

    public static HTMLDialogElement dialog(params Node[] children) => new HTMLDialogElement().content(children);

    // Scripting - parameterless
    public static HTMLScriptElement script(params Node[] children) => new HTMLScriptElement().content(children);

    public static Element noscript(params Node[] children) => new Element("noscript").content(children);

    public static Element template(params Node[] children) => new Element("template").content(children);

    public static Element canvas(params Node[] children) => new Element("canvas").content(children);

    // Style
    public static Element style(params Node[] children) => new Element("style").content(children);

    // Other
    public static Element area() => new Element("area");

    public static Element map(params Node[] children) => new Element("map").content(children);

    public static Element picture(params Node[] children) => new Element("picture").content(children);

    public static HTMLDataElement data(params Node[] children) => new HTMLDataElement().content(children);

    public static Element datalist(params Node[] children) => new Element("datalist").content(children);

    public static HTMLMeterElement meter(params Node[] children) => new HTMLMeterElement().content(children);

    public static HTMLProgressElement progress(params Node[] children) => new HTMLProgressElement().content(children);

    public static Element output(params Node[] children) => new Element("output").content(children);

    // Text node helper
    public static TextNode text(string content) => new TextNode(content);

    // Developer sugar methods
    public static Node @if(bool condition, System.Func<Node> trueFactory, System.Func<Node> falseFactory = null)
    {
        if (condition)
        {
            return trueFactory?.Invoke();
        }
        else if (falseFactory != null)
        {
            return falseFactory.Invoke();
        }
        return null;
    }

    public static Node[] @foreach<T>(System.Collections.Generic.IEnumerable<T> items, System.Func<T, Node> factory)
    {
        if (items == null || factory == null)
            return new Node[0];

        var nodes = new System.Collections.Generic.List<Node>();
        foreach (var item in items)
        {
            var node = factory(item);
            if (node != null)
            {
                nodes.Add(node);
            }
        }
        return nodes.ToArray();
    }

    public static Node[] @foreach<T>(System.Collections.Generic.IEnumerable<T> items, System.Func<T, int, Node> factory)
    {
        if (items == null || factory == null)
            return new Node[0];

        var nodes = new System.Collections.Generic.List<Node>();
        int index = 0;
        foreach (var item in items)
        {
            var node = factory(item, index);
            if (node != null)
            {
                nodes.Add(node);
            }
            index++;
        }
        return nodes.ToArray();
    }

    public static Node fragment(params Node[] children) => new Element("fragment").content(children);
}