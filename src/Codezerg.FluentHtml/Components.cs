namespace Codezerg.FluentHtml
{
    public static class Components
    {
        public static Element MyHeader(string title)
        {
            return Html.header(
                Html.nav().@class("main-nav"),
                Html.h1(Html.text(title)).@class("page-title")
            );
        }

        public static Element MyFooter()
        {
            return Html.footer(
                Html.p(Html.text($"© {System.DateTime.Now.Year} Codezerg. All rights reserved.")).@class("copyright")
            );
        }

        public static Node MyLayout(string title, Node content)
        {
            return Html.html(
                Html.head(
                    Html.meta().charset("utf-8"),
                    Html.title(Html.text(title)),
                    Html.link().rel("stylesheet").href("/css/style.css")
                ),
                Html.body(
                    MyHeader(title),
                    Html.main(content).@class("main-content"),
                    MyFooter()
                )
            );
        }

        public static Element Card(string title, string description, string buttonText = "Learn More")
        {
            return Html.div(
                Html.h3(Html.text(title)),
                Html.p(Html.text(description)),
                Html.button(Html.text(buttonText)).@class("btn btn-primary")
            ).@class("card");
        }

        public static Element NavigationMenu(params (string text, string href)[] items)
        {
            var menuItems = new Node[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                menuItems[i] = Html.li(
                    Html.a(Html.text(items[i].text)).href(items[i].href)
                );
            }
            return Html.nav(
                Html.ul(menuItems).@class("nav-list")
            ).@class("navigation");
        }

        public static Element Alert(string message, string type = "info")
        {
            return Html.div(
                Html.text(message)
            ).@class($"alert alert-{type}").role("alert");
        }

        public static Element FormGroup(string label, string name, string type = "text", string placeholder = null)
        {
            var input = Html.input().type(type).name(name).@class("form-control").id(name);
            if (!string.IsNullOrEmpty(placeholder))
            {
                input.placeholder(placeholder);
            }

            return Html.div(
                Html.label(Html.text(label)).@for(name),
                input
            ).@class("form-group");
        }
    }
}