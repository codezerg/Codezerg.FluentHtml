using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codezerg.FluentHtml
{
    public class Element : Node
    {
        public string TagName { get; }
        public Dictionary<string, string> Attributes { get; }
        public List<Node> Children { get; }

        public Element(string tagName)
        {
            TagName = tagName ?? throw new ArgumentNullException(nameof(tagName));
            Attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Children = new List<Node>();
        }

        public override void Render(HtmlWriter writer)
        {
            // Start the element
            writer.WriteBeginTag(TagName);

            // Add attributes
            foreach (var attr in Attributes)
            {
                writer.WriteAttribute(attr.Key, attr.Value);
            }

            // Render children
            foreach (var child in Children)
            {
                child.Render(writer);
            }

            writer.WriteEndTag();
        }       
    }
}