using System;
using System.Collections.Generic;
using Codezerg.FluentHtml;

using static Codezerg.FluentHtml.Html;

namespace Codezerg.FluentHtml.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Codezerg.FluentHtml Demo (Lowercase API) ===\n");

            Example1_BasicHtml();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Example2_UsingComponents();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Example3_ConditionalAndLoops();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Example4_FluentAttributes();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Example5_ComplexLayout();
        }

        static void Example1_BasicHtml()
        {
            Console.WriteLine("Example 1: Basic HTML Structure");
            Console.WriteLine("--------------------------------");

            var page = Html.html(
                head(
                    title(text("Hello World"))
                ),
                body(
                    h1(text("Hello, World!")),
                    p(text("This is a simple HTML page generated with Codezerg.FluentHtml."))
                )
            );

            Console.WriteLine(Renderer.RenderPage(page));
        }

        static void Example2_UsingComponents()
        {
            Console.WriteLine("Example 2: Using Components");
            Console.WriteLine("---------------------------");

            var content = Html.div(
                p(text("Welcome to our component-based page!")),
                ul(
                    li(text("Feature One")),
                    li(text("Feature Two")),
                    li(text("Feature Three"))
                )
            );

            var page = Components.MyLayout("Home", content);
            Console.WriteLine(Renderer.RenderPage(page));
        }

        static void Example3_ConditionalAndLoops()
        {
            Console.WriteLine("Example 3: Conditional Rendering and Loops");
            Console.WriteLine("------------------------------------------");

            bool isLoggedIn = true;
            var items = new List<string> { "Apple", "Banana", "Orange", "Grape" };

            var page = Html.html(
                Html.head(
                    Html.title(Html.text("Dynamic Content"))
                ),
                Html.body(
                    Html.h1(Html.text("Dynamic Content Example")),

                    Html.@if(isLoggedIn,
                        () => Html.p(Html.text("Welcome back, user!")),
                        () => Html.p(Html.text("Please log in."))
                    ),

                    Html.h2(Html.text("Shopping List:")),
                    Html.ul(
                        Html.@foreach(items, item =>
                            Html.li(Html.text(item))
                        )
                    ),

                    Html.h2(Html.text("Numbered List:")),
                    Html.ol(
                        Html.@foreach(items, (item, index) =>
                            Html.li(Html.text($"{index + 1}. {item}"))
                        )
                    )
                )
            );

            Console.WriteLine(Renderer.RenderPage(page));
        }

        static void Example4_FluentAttributes()
        {
            Console.WriteLine("Example 4: Fluent Attribute Chaining (Lowercase)");
            Console.WriteLine("------------------------------------------------");

            var page = Html.html(
                Html.head(
                    Html.title(Html.text("Fluent Attributes"))
                ),
                Html.body(
                    Html.div(
                        Html.h1(Html.text("Contact Form")).@class("title"),
                        Html.form(
                            Components.FormGroup("Name", "name", "text", "Enter your name"),
                            Components.FormGroup("Email", "email", "email", "Enter your email"),
                            Html.div(
                                Html.label(Html.text("Message")).@for("message"),
                                Html.textarea().name("message").rows(5).cols(40).@class("form-control").id("message")
                            ).@class("form-group"),
                            Html.button(Html.text("Submit"))
                                .type("submit")
                                .@class("btn btn-primary")
                                .id("submit-btn")
                        ).method("POST").action("/contact")
                    ).id("main-container").@class("container")
                )
            );

            Console.WriteLine(Renderer.RenderPage(page));
        }

        static void Example5_ComplexLayout()
        {
            Console.WriteLine("Example 5: Complex Layout with Cards");
            Console.WriteLine("------------------------------------");

            var products = new[]
            {
                new { Name = "Product 1", Description = "Amazing product with great features", Price = "$29.99" },
                new { Name = "Product 2", Description = "Another fantastic product", Price = "$39.99" },
                new { Name = "Product 3", Description = "Premium quality guaranteed", Price = "$49.99" }
            };

            var navigation = Components.NavigationMenu(
                ("Home", "/"),
                ("Products", "/products"),
                ("About", "/about"),
                ("Contact", "/contact")
            );

            var page = Html.html(
                Html.head(
                    Html.meta().charset("utf-8"),
                    Html.title(Html.text("Product Catalog")),
                    Html.link().rel("stylesheet").href("/css/bootstrap.min.css")
                ),
                Html.body(
                    Html.header(
                        navigation,
                        Html.h1(Html.text("Our Products")).@class("text-center my-4")
                    ),
                    Html.main(
                        Components.Alert("Special offer: 20% off all products this week!", "success"),
                        Html.div(
                            Html.@foreach(products, product =>
                                Html.div(
                                    Components.Card(
                                        product.Name,
                                        product.Description,
                                        "Buy Now"
                                    ),
                                    Html.p(Html.text("Price: "), Html.strong(Html.text(product.Price)))
                                        .@class("price-tag")
                                ).@class("col-md-4")
                            )
                        ).@class("row"),
                        Html.@if(products.Length > 0,
                            () => Html.p(Html.text($"Showing {products.Length} products")).@class("text-muted"),
                            () => Html.p(Html.text("No products available")).@class("text-warning")
                        )
                    ).@class("container"),
                    Components.MyFooter()
                )
            );

            Console.WriteLine(Renderer.RenderPage(page));
        }

        static void Example6_TagSpecificAttributes()
        {
            Console.WriteLine("Example 6: Tag-Specific Attributes (New!)");
            Console.WriteLine("-----------------------------------------");

            var page = Html.html(
                Html.head(
                    Html.meta().charset("utf-8"),
                    Html.meta().name("viewport").content("width=device-width, initial-scale=1.0"),
                    Html.title(Html.text("Tag-Specific Demo")),
                    Html.link().rel("stylesheet").href("/css/style.css").type("text/css"),
                    Html.script().src("/js/app.js").defer().type("module")
                ),
                Html.body(
                    Html.h1(Html.text("Tag-Specific Attribute Examples")),

                    Html.form(
                        Html.label(Html.text("Username")).@for("username"),
                        Html.input().type("text").name("username").id("username")
                            .placeholder("Enter username").required().autofocus(),

                        Html.label(Html.text("Password")).@for("password"),
                        Html.input().type("password").name("password").id("password")
                            .minlength(8).required(),

                        Html.label(Html.text("Remember me")),
                        Html.input().type("checkbox").name("remember").@checked(),

                        Html.button(Html.text("Login")).type("submit")
                    ).method("post").action("/login").novalidate(),

                    Html.img().src("/logo.png").alt("Company Logo").width("200").height("50").loading("lazy"),

                    Html.a(Html.text("Visit our website")).href("https://example.com").target("_blank").rel("noopener")
                )
            );

            Console.WriteLine(Renderer.RenderPage(page));
        }
    }
}