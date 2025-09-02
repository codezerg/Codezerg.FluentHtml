using Xunit;
using Codezerg.FluentHtml;

namespace Codezerg.FluentHtml.Tests
{
    public class HtmlTests
    {
        [Fact]
        public void TextNode_Should_HtmlEncode_Content()
        {
            var node = new TextNode("<script>alert('XSS')</script>");
            var result = node.Render();
            
            Assert.DoesNotContain("<script>", result);
            Assert.Contains("&lt;script&gt;", result);
        }

        [Fact]
        public void Element_Should_Render_SelfClosing_Tags()
        {
            var img = Html.img().src("/image.jpg").alt("Test Image");
            var result = img.Render();
            
            Assert.Contains("<img", result);
            Assert.Contains("/>", result);
            Assert.DoesNotContain("</img>", result);
        }

        [Fact]
        public void Html_Should_Create_Basic_Structure()
        {
            var page = Html.html(
                Html.head(
                    Html.title(Html.text("Test Page"))
                ),
                Html.body(
                    Html.h1(Html.text("Hello World"))
                )
            );
            
            var result = page.Render();
            
            Assert.Contains("<html>", result);
            Assert.Contains("<head>", result);
            Assert.Contains("<title>Test Page</title>", result);
            Assert.Contains("<body>", result);
            Assert.Contains("<h1>Hello World</h1>", result);
            Assert.Contains("</html>", result);
        }

        [Fact]
        public void Attrs_Should_Chain_Fluently_Lowercase()
        {
            var div = Html.div(Html.p(Html.text("Content")))
                .id("main")
                .@class("container")
                .style("padding: 10px");
                
            var result = div.Render();
            
            Assert.Contains("id=\"main\"", result);
            Assert.Contains("class=\"container\"", result);
            Assert.Contains("style=\"padding: 10px\"", result);
        }

        [Fact]
        public void Conditional_Should_Render_Based_On_Condition()
        {
            var trueCase = Html.@if(true, 
                () => Html.p(Html.text("True")), 
                () => Html.p(Html.text("False")));
            
            var falseCase = Html.@if(false,
                () => Html.p(Html.text("True")),
                () => Html.p(Html.text("False")));
                
            Assert.Contains("True", trueCase?.Render());
            Assert.Contains("False", falseCase?.Render());
        }

        [Fact]
        public void Foreach_Should_Render_Items()
        {
            var items = new[] { "One", "Two", "Three" };
            var nodes = Html.@foreach(items, item => Html.li(Html.text(item)));
            
            var ul = Html.ul(nodes);
            var result = ul.Render();
            
            Assert.Contains("<li>One</li>", result);
            Assert.Contains("<li>Two</li>", result);
            Assert.Contains("<li>Three</li>", result);
        }

        [Fact]
        public void Renderer_Should_Add_Doctype()
        {
            var page = Html.html(
                Html.head(Html.title(Html.text("Test"))),
                Html.body(Html.p(Html.text("Content")))
            );
            
            var result = Renderer.RenderPage(page);
            
            Assert.StartsWith("<!DOCTYPE html>", result);
        }

        [Fact]
        public void TagSpecific_Attributes_Should_Work()
        {
            var meta = Html.meta().charset("utf-8");
            var link = Html.link().rel("stylesheet").href("/style.css");
            var form = Html.form().method("post").action("/submit");
            var input = Html.input().type("text").name("username").required();
            
            Assert.Contains("charset=\"utf-8\"", meta.Render());
            Assert.Contains("rel=\"stylesheet\"", link.Render());
            Assert.Contains("method=\"post\"", form.Render());
            Assert.Contains("type=\"text\"", input.Render());
            Assert.Contains("required=\"required\"", input.Render());
        }

        [Fact]
        public void HtmlElement_Should_Support_Specialized_Attributes()
        {
            var html = Html.html().xmlns("http://www.w3.org/1999/xhtml");
            var result = html.Render();
            
            Assert.Contains("xmlns=\"http://www.w3.org/1999/xhtml\"", result);
        }

        [Fact]
        public void Parameterless_Factories_Should_Create_Empty_Elements()
        {
            var meta = Html.meta();
            var link = Html.link();
            var input = Html.input();
            var img = Html.img();
            
            Assert.Equal("<meta />", meta.Render().Trim());
            Assert.Equal("<link />", link.Render().Trim());
            Assert.Equal("<input />", input.Render().Trim());
            Assert.Equal("<img />", img.Render().Trim());
        }
    }
}