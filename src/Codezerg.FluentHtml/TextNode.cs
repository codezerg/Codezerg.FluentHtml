using System.Net;

namespace Codezerg.FluentHtml
{
    public class TextNode : Node
    {
        private readonly string _text;

        public TextNode(string text)
        {
            _text = text ?? string.Empty;
        }

        public override string Render(int indent = 0)
        {
            return GetIndentation(indent) + WebUtility.HtmlEncode(_text);
        }
    }
}