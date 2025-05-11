using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.State
{
    public interface IValidationState
    {
        void Apply(LightElementNode element);
    }
}
