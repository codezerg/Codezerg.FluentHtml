using Xunit;
using static Codezerg.FluentHtml.Html;

namespace Codezerg.FluentHtml.Tests;

public class NewElementsTests
{
    [Fact]
    public void MediaElements_Should_Render_Correctly()
    {
        var audio = Html.audio(
            source().src("audio.mp3").type("audio/mpeg")
        ).controls();
        
        Assert.Contains("<audio controls=\"controls\">", audio.Render());
        Assert.Contains("<source src=\"audio.mp3\" type=\"audio/mpeg\" />", audio.Render());
        
        var video = Html.video().src("video.mp4").width(640).height(480);
        Assert.Contains("<video src=\"video.mp4\" width=\"640\" height=\"480\">", video.Render());
    }
    
    [Fact]
    public void TableElements_Should_Render_Correctly()
    {
        var table = Html.table(
            thead(
                tr(
                    th(text("Header 1")),
                    th(text("Header 2"))
                )
            ),
            tbody(
                tr(
                    td(text("Cell 1")),
                    td(text("Cell 2"))
                )
            )
        );
        
        Assert.Contains("<table>", table.Render());
        Assert.Contains("<thead>", table.Render());
        Assert.Contains("<tbody>", table.Render());
        Assert.Contains("<th>Header 1</th>", table.Render());
        Assert.Contains("<td>Cell 1</td>", table.Render());
    }
    
    [Fact]
    public void HeadingElements_Should_Render_Correctly()
    {
        var h1 = Html.h1(text("Title"));
        var h2 = Html.h2(text("Subtitle"));
        var h6 = Html.h6(text("Small"));
        
        Assert.Equal("<h1>Title</h1>", h1.Render());
        Assert.Equal("<h2>Subtitle</h2>", h2.Render());
        Assert.Equal("<h6>Small</h6>", h6.Render());
    }
    
    [Fact]
    public void SemanticElements_Should_Render_Correctly()
    {
        var article = Html.article(
            header(h1(text("Article Title"))),
            section(p(text("Content"))),
            footer(text("Footer"))
        );
        
        Assert.Contains("<article>", article.Render());
        Assert.Contains("<header>", article.Render());
        Assert.Contains("<section>", article.Render());
        Assert.Contains("<footer>", article.Render());
        
        var nav = Html.nav().@class("navigation");
        Assert.Contains("<nav class=\"navigation\">", nav.Render());
    }
    
    [Fact]
    public void InlineElements_Should_Render_Correctly()
    {
        var paragraph = p(
            strong(text("Bold")),
            text(" and "),
            em(text("Italic")),
            text(" and "),
            code(text("console.log()")),
            text(" and "),
            mark(text("highlighted"))
        );
        
        Assert.Contains("<strong>Bold</strong>", paragraph.Render());
        Assert.Contains("<em>Italic</em>", paragraph.Render());
        Assert.Contains("<code>console.log()</code>", paragraph.Render());
        Assert.Contains("<mark>highlighted</mark>", paragraph.Render());
    }
    
    [Fact]
    public void IFrameElement_Should_Support_Attributes()
    {
        var iframe = Html.iframe()
            .src("https://example.com")
            .width("800")
            .height("600")
            .allowfullscreen();
        
        Assert.Contains("src=\"https://example.com\"", iframe.Render());
        Assert.Contains("width=\"800\"", iframe.Render());
        Assert.Contains("height=\"600\"", iframe.Render());
        Assert.Contains("allowfullscreen=\"allowfullscreen\"", iframe.Render());
    }
    
    [Fact]
    public void FormElements_Should_Support_Attributes()
    {
        var fieldset = Html.fieldset(
            legend(text("User Info")),
            label(text("Name:"))
        ).disabled();
        
        Assert.Contains("<fieldset disabled=\"disabled\">", fieldset.Render());
        Assert.Contains("<legend>User Info</legend>", fieldset.Render());
    }
    
    [Fact]
    public void InteractiveElements_Should_Support_Attributes()
    {
        var details = Html.details(
            summary(text("Click to expand")),
            p(text("Hidden content"))
        ).open();
        
        Assert.Contains("<details open=\"open\">", details.Render());
        
        var progress = Html.progress().value("70").max("100");
        Assert.Contains("value=\"70\"", progress.Render());
        Assert.Contains("max=\"100\"", progress.Render());
        
        var meter = Html.meter().value("6").min("0").max("10");
        Assert.Contains("<meter value=\"6\" min=\"0\" max=\"10\">", meter.Render());
    }
}