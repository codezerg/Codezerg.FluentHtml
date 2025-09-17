using static Codezerg.FluentHtml.Html;

namespace Codezerg.FluentHtml.Demo
{
    public static class Components
    {
        public static Element MyLayout(string title, params Node[] content)
        {
            return html().attr("lang", "en").content(
                head(
                    meta().attr("charset", "UTF-8"),
                    meta().attr("viewport", "width=device-width, initial-scale=1.0"),
                    Html.title(text(title)),
                    link().attr("rel", "stylesheet").attr("href", "/css/styles.css")
                ),
                body(
                    MyHeader(),
                    main(content).attr("class", "container"),
                    MyFooter()
                )
            );
        }

        public static Element MyHeader()
        {
            return header().attr("class", "site-header").content(
                nav().attr("class", "nav-menu").content(
                    a(text("Home")).attr("href", "/").attr("class", "nav-link"),
                    a(text("About")).attr("href", "/about").attr("class", "nav-link"),
                    a(text("Contact")).attr("href", "/contact").attr("class", "nav-link")
                )
            );
        }

        public static Element MyFooter()
        {
            return footer().attr("class", "site-footer").content(
                p(text("© 2024 My Company. All rights reserved."))
            );
        }

        public static Element Card(string title, string content)
        {
            return div().attr("class", "card").content(
                h3(text(title)).attr("class", "card-title"),
                p(text(content)).attr("class", "card-content")
            );
        }

        public static Element Alert(string message, string type = "info")
        {
            return div().attr("class", $"alert alert-{type}").attr("role", "alert").content(
                text(message)
            );
        }

        public static Element NavigationMenu(params (string text, string href)[] items)
        {
            var links = new Node[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                links[i] = li(
                    a(text(items[i].text)).attr("href", items[i].href)
                );
            }

            return nav(
                ul(links).attr("class", "nav-list")
            ).attr("class", "navigation");
        }

        public static Element FormGroup(string label, Element input)
        {
            return div(
                Html.label(text(label)).attr("for", input.Attributes.ContainsKey("id") ? input.Attributes["id"] : ""),
                input
            ).attr("class", "form-group");
        }
    }
}