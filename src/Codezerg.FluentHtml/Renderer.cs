using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Codezerg.FluentHtml
{
    public static class Renderer
    {
        public static string RenderPage(Node node)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.Append(Render(node));
            return sb.ToString();
        }

        public static string RenderFragment(Node node)
        {
            return Render(node);
        }

        public static string Render(Node node, bool minified = false)
        {
            using var stringWriter = new StringWriter();
            var htmlWriter = new HtmlWriter(stringWriter, minified);
            node.Render(htmlWriter);
            return stringWriter.ToString();
        }

        public static void Render(Node node, TextWriter output, bool minified = false)
        {
            var htmlWriter = new HtmlWriter(output, minified);
            node.Render(htmlWriter);
        }

        public static async Task RenderAsync(Node node, TextWriter output, bool minified = false)
        {
            var htmlWriter = new HtmlWriter(output, minified);
            node.Render(htmlWriter);
            await output.FlushAsync();
        }

        public static string RenderMinified(Node node)
        {
            return Render(node, minified: true);
        }
    }
}