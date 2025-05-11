using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.Iterator
{
    public interface ILightNodeIterator
    {
        bool MoveNext();
        LightElementNode Current { get; }
        void Reset();
    }
}
