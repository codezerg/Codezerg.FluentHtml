namespace Codezerg.FluentHtml;

public enum HxSwap
{
    innerHTML,
    outerHTML,
    beforebegin,
    afterbegin,
    beforeend,
    afterend,
    delete,   // remove element
    none      // do not swap
}

public enum HxTrigger
{
    click,
    change,
    load,
    revealed,
    submit,
    mouseenter,
    mouseleave,
    input
    // extend with more as needed
}

public enum HxConfirmBehavior
{
    trueDialog,
    falseDialog
}

/// <summary>
/// Fluent extensions for htmx attributes.
/// </summary>
public static class HtmxExtensions
{
    // CRUD requests
    public static T hx_get<T>(this T element, string url) where T : Element
        => element.attr("hx-get", url);

    public static T hx_post<T>(this T element, string url) where T : Element
        => element.attr("hx-post", url);

    public static T hx_put<T>(this T element, string url) where T : Element
        => element.attr("hx-put", url);

    public static T hx_delete<T>(this T element, string url) where T : Element
        => element.attr("hx-delete", url);

    // targets & swapping
    public static T hx_target<T>(this T element, string selector) where T : Element
        => element.attr("hx-target", selector);

    public static T hx_swap<T>(this T element, HxSwap swap) where T : Element
        => element.attr("hx-swap", swap.ToString().ToLower());

    // triggers
    public static T hx_trigger<T>(this T element, HxTrigger trigger) where T : Element
        => element.attr("hx-trigger", trigger.ToString().ToLower());

    // confirm
    public static T hx_confirm<T>(this T element, string message) where T : Element
        => element.attr("hx-confirm", message);

    // boosting, history
    public static T hx_boost<T>(this T element, bool enabled = true) where T : Element
        => element.attr("hx-boost", enabled ? "true" : "false");

    public static T hx_push_url<T>(this T element, string value) where T : Element
        => element.attr("hx-push-url", value);

    // hx-vals
    public static T hx_vals<T>(this T element, string json) where T : Element
        => element.attr("hx-vals", json);

    // hx-indicator
    public static T hx_indicator<T>(this T element, string selector) where T : Element
        => element.attr("hx-indicator", selector);
}