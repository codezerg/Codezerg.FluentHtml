namespace Codezerg.FluentHtml
{
    public abstract class Node
    {
        public abstract string Render(int indent = 0);
        
        protected string GetIndentation(int level)
        {
            return new string(' ', level * 2);
        }
    }
}