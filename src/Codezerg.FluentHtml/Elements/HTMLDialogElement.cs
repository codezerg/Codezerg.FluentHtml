using System;
using System.Collections.Generic;
using System.Text;

namespace Codezerg.FluentHtml;

public class HTMLDialogElement : Element
{
    public HTMLDialogElement() : base("dialog")
    {
    }
}

public static class HTMLDialogElementExtensions
{
    public static HTMLDialogElement open(this HTMLDialogElement element, bool value = true) => value ? element.attr("open", "open") : element;
}