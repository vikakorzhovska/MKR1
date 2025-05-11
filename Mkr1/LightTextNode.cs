using Mkr1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1
{
    public class LightTextNode : LightNode, IVisitable
    {
        public string Text { get; set; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHTML()
        {
            return Text;
        }

        public override string InnerHTML()
        {
            return Text;
        }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
