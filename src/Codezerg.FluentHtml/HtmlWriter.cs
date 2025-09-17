using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Codezerg.FluentHtml
{
    public class HtmlWriter
    {
        private static readonly HashSet<string> _voidElements = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "area", "base", "br", "col", "embed", "hr", "img", "input",
            "link", "meta", "param", "source", "track", "wbr"
        };

        private readonly TextWriter _writer;
        private readonly bool _minified;
        private bool _insideElement = false;
        private readonly Stack<string> _elementStack = new Stack<string>();
        private int _indentLevel = 0;
        private bool _hasContent = false;

        public HtmlWriter(TextWriter writer, bool minified = false)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
            _minified = minified;
        }

        public HtmlWriter WriteBeginTag(string tagName)
        {
            if (_insideElement)
                CloseTag();

            if (!_minified && _elementStack.Count > 0)
            {
                _writer.WriteLine();
                WriteIndent();
            }

            _writer.Write($"<{tagName}");
            _insideElement = true;
            _elementStack.Push(tagName);
            _hasContent = false;
            return this;
        }

        public HtmlWriter WriteEndTag()
        {
            if (_elementStack.Count == 0)
                throw new InvalidOperationException("No element to close");

            var tagName = _elementStack.Pop();

            if (_insideElement)
            {
                if (IsVoidElement(tagName))
                {
                    SelfClose();
                    return this;
                }
                else
                {
                    CloseTag();
                }
            }

            // Decrease indent level before writing closing tag
            if (!_minified)
                _indentLevel--;

            // Write closing tag on new line with proper indentation if no inline content
            if (!_minified && !_hasContent)
            {
                _writer.WriteLine();
                WriteIndent();
            }

            _writer.Write($"</{tagName}>");
            _hasContent = false; // Reset for parent element

            return this;
        }

        public HtmlWriter WriteAttribute(string name, string value, bool encode = true)
        {
            if (!_insideElement)
                throw new InvalidOperationException("Attributes must be written inside an element");

            if (value == null)
                _writer.Write($" {name}");
            else if (encode)
                _writer.Write($" {name}=\"{WebUtility.HtmlEncode(value)}\"");
            else
                _writer.Write($" {name}=\"{value}\"");

            return this;
        }

        private HtmlWriter SelfClose()
        {
            if (!_insideElement)
                return this;

            _writer.Write("/>");
            _insideElement = false;
            return this;
        }

        private HtmlWriter CloseTag()
        {
            if (!_insideElement)
                return this;

            _writer.Write(">");
            _insideElement = false;

            if (!_minified)
                _indentLevel++;

            return this;
        }

        public HtmlWriter WriteEncodedText(string text)
        {
            if (_insideElement)
                CloseTag();

            if (!string.IsNullOrWhiteSpace(text))
            {
                _writer.Write(WebUtility.HtmlEncode(text));
                _hasContent = true;
            }

            return this;
        }

        public HtmlWriter WriteRawText(string text)
        {
            if (_insideElement)
                CloseTag();

            if (!string.IsNullOrWhiteSpace(text))
            {
                _writer.Write(text);
                _hasContent = true;
            }

            return this;
        }

        private bool IsVoidElement(string tagName)
        {
            return _voidElements.Contains(tagName);
        }

        private void WriteIndent()
        {
            if (!_minified)
            {
                for (int i = 0; i < _indentLevel; i++)
                {
                    _writer.Write("  "); // 2 spaces per indent level
                }
            }
        }
    }
}