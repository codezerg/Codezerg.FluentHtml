using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codezerg.FluentHtml
{
    public class Element : Node
    {
        private static readonly HashSet<string> VoidElements = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "area", "base", "br", "col", "embed", "hr", "img", "input",
            "link", "meta", "param", "source", "track", "wbr"
        };

        public string TagName { get; }
        public Dictionary<string, string> Attributes { get; }
        public List<Node> Children { get; }

        public Element(string tagName)
        {
            TagName = tagName ?? throw new ArgumentNullException(nameof(tagName));
            Attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Children = new List<Node>();
        }

        public override string Render(int indent = 0)
        {
            var sb = new StringBuilder();
            var indentation = GetIndentation(indent);
            
            sb.Append(indentation);
            sb.Append('<');
            sb.Append(TagName);

            foreach (var attr in Attributes)
            {
                sb.Append(' ');
                sb.Append(attr.Key);
                sb.Append("=\"");
                sb.Append(System.Net.WebUtility.HtmlEncode(attr.Value));
                sb.Append('"');
            }

            bool isVoid = VoidElements.Contains(TagName);

            if (isVoid)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            sb.Append('>');

            if (Children.Count == 0)
            {
                sb.Append("</");
                sb.Append(TagName);
                sb.Append('>');
                return sb.ToString();
            }

            bool hasOnlyTextNodes = Children.All(c => c is TextNode);
            
            if (hasOnlyTextNodes && Children.Count == 1)
            {
                var textNode = Children[0] as TextNode;
                sb.Append(textNode.Render(0).TrimStart());
                sb.Append("</");
                sb.Append(TagName);
                sb.Append('>');
            }
            else
            {
                sb.AppendLine();
                foreach (var child in Children)
                {
                    sb.AppendLine(child.Render(indent + 1));
                }
                sb.Append(indentation);
                sb.Append("</");
                sb.Append(TagName);
                sb.Append('>');
            }

            return sb.ToString();
        }
    }
}