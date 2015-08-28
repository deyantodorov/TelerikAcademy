namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HTMLRenderer.Contracts;

    public class Element : IElement
    {
        private readonly IList<IElement> childElements;

        public Element(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public Element(string name, string content)
            : this(name)
        {
            this.TextContent = content;
        }

        public string Name { get; private set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(this.childElements); }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (this.TextContent != null)
            {
                output.Append(ClearTextContent(this.TextContent));
            }

            foreach (var childElement in this.childElements)
            {
                childElement.Render(output);
            }

            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);

            return sb.ToString();
        }

        protected string ClearTextContent(string content)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in content)
            {
                if (symbol == '<')
                {
                    sb.Append("&lt;");
                }
                else if (symbol == '>')
                {
                    sb.Append("&gt;");
                }
                else if (symbol == '&')
                {
                    sb.Append("&amp;");
                }
                else
                {
                    sb.Append(symbol);
                }
            }

            return sb.ToString();
        }
    }
}
