using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.Visitor
{
    public class CharacterCountVisitor : IVisitor
    {
        public int TotalCharacters { get; private set; }

        public void Visit(LightTextNode textNode)
        {
            TotalCharacters += textNode.Text.Length;
        }

        public void Visit(LightElementNode elementNode)
        {
        }
    }

}
