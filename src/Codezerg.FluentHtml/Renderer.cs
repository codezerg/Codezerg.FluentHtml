using System.Text;

namespace Codezerg.FluentHtml
{
    public static class Renderer
    {
        public static string RenderPage(Node node)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.Append(node.Render());
            return sb.ToString();
        }

        public static string RenderFragment(Node node)
        {
            return node.Render();
        }

        public static string RenderMinified(Node node)
        {
            var html = node.Render(0);
            return System.Text.RegularExpressions.Regex.Replace(html, @"\s+", " ").Trim();
        }
    }
}