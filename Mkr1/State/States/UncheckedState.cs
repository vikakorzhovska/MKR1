using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.State.States
{
    public class UncheckedState : IValidationState
    {
        public void Apply(LightElementNode element)
        {
            element.CssClasses.Remove("error");
            element.CssClasses.Remove("valid");
        }
    }
}
