using System.Linq;

namespace Codezerg.FluentHtml
{
    // General element extensions - all lowercase
    public static partial class GlobalAttributeExtensions
    {
        public static T attr<T>(this T element, string name, string value) where T : Element
        {
            if (!string.IsNullOrEmpty(name))
            {
                element.Attributes[name] = value ?? string.Empty;
            }
            return element;
        }

        public static T content<T>(this T element, Node child) where T : Element
        {
            if (child != null)
            {
                element.Children.Add(child);
            }
            return element;
        }

        public static T content<T>(this T element, params Node[] children) where T : Element
        {
            if (children != null)
            {
                foreach (var child in children.Where(c => c != null))
                {
                    element.Children.Add(child);
                }
            }
            return element;
        }


        // Core attributes
        public static T id<T>(this T element, string value) where T : Element
        {
            return element.attr("id", value) as T;
        }

        public static T @class<T>(this T element, string value) where T : Element
        {
            return element.attr("class", value) as T;
        }

        public static T style<T>(this T element, string value) where T : Element
        {
            return element.attr("style", value) as T;
        }

        public static T title<T>(this T element, string value) where T : Element
        {
            return element.attr("title", value) as T;
        }

        public static T lang<T>(this T element, string value) where T : Element
        {
            return element.attr("lang", value) as T;
        }

        public static T dir<T>(this T element, string value) where T : Element
        {
            return element.attr("dir", value) as T;
        }

        // Accessibility
        public static T role<T>(this T element, string value) where T : Element
        {
            return element.attr("role", value) as T;
        }

        public static T arialabel<T>(this T element, string value) where T : Element
        {
            return element.attr("aria-label", value) as T;
        }

        public static T ariadescribedby<T>(this T element, string value) where T : Element
        {
            return element.attr("aria-describedby", value) as T;
        }

        public static T ariahidden<T>(this T element, string value) where T : Element
        {
            return element.attr("aria-hidden", value) as T;
        }

        // Data attributes
        public static T data<T>(this T element, string name, string value) where T : Element
        {
            return element.attr($"data-{name}", value) as T;
        }

        // Global boolean attributes
        public static T hidden<T>(this T element) where T : Element
        {
            return element.attr("hidden", "hidden") as T;
        }

        public static T contenteditable<T>(this T element, string value = "true") where T : Element
        {
            return element.attr("contenteditable", value) as T;
        }

        public static T draggable<T>(this T element, string value = "true") where T : Element
        {
            return element.attr("draggable", value) as T;
        }

        public static T spellcheck<T>(this T element, string value = "true") where T : Element
        {
            return element.attr("spellcheck", value) as T;
        }

        public static T tabindex<T>(this T element, string value) where T : Element
        {
            return element.attr("tabindex", value) as T;
        }

        // Events (onclick, onchange, etc.) - lowercase
        public static T onclick<T>(this T element, string value) where T : Element
        {
            return element.attr("onclick", value) as T;
        }

        public static T onchange<T>(this T element, string value) where T : Element
        {
            return element.attr("onchange", value) as T;
        }

        public static T onsubmit<T>(this T element, string value) where T : Element
        {
            return element.attr("onsubmit", value) as T;
        }

        public static T onfocus<T>(this T element, string value) where T : Element
        {
            return element.attr("onfocus", value) as T;
        }

        public static T onblur<T>(this T element, string value) where T : Element
        {
            return element.attr("onblur", value) as T;
        }
    }
}