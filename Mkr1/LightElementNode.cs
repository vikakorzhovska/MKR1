using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1
{
    internal class LightElementNode : LightNode
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
    }
}
