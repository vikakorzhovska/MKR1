using Mkr1.Iterator;
using Mkr1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1
{
    public class LightElementNode : LightNode, ILightNodeAggregate, IVisitable
    {
        public string TagName { get; set; }
        public string DisplayType { get; set; }
        public bool SelfClosing { get; set; }
        public List<string> CssClasses { get; set; } = new List<string>();
        public List<LightNode> Children { get; set; } = new List<LightNode>();

        public LightElementNode(string tagName, string displayType, bool selfClosing)
        {
            TagName = tagName;
            DisplayType = displayType;
            SelfClosing = selfClosing;
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }

        public override string OuterHTML()
        {
            string outerHtml = $"<{TagName}";

            if (CssClasses.Count > 0)
            {
                outerHtml += " class=\"" + string.Join(" ", CssClasses) + "\"";
            }

            if (SelfClosing)
            {
                outerHtml += " />";
            }
            else
            {
                outerHtml += ">";
                outerHtml += InnerHTML();
                outerHtml += $"</{TagName}>";
            }

            return outerHtml;
        }

        public override string InnerHTML()
        {
            string innerHtml = string.Empty;

            foreach (var child in Children)
            {
                innerHtml += child.OuterHTML();
            }

            return innerHtml;
        }
        public ILightNodeIterator GetIterator(string className)
        {
            return new ClassFilteredIterator(this, className);
        }
        public LightElementNode(string tagName)
    : this(tagName, "block", false) 
        {
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in Children)
            {
                if (child is IVisitable visitable)
                    visitable.Accept(visitor);
            }
        }
    }
}
