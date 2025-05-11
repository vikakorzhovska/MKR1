using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.Visitor
{
    public interface IVisitor
    {
        void Visit(LightTextNode textNode);
        void Visit(LightElementNode elementNode);
    }
}
