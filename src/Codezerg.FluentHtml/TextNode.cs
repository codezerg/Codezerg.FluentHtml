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

        public override void Render(HtmlWriter writer)
        {
            writer.WriteEncodedText(_text);
        }
    }
}