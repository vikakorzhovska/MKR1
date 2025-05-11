using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.State.States
{
    public class InvalidState : IValidationState
    {
        public void Apply(LightElementNode element)
        {
            element.CssClasses.Remove("valid");
            element.CssClasses.Add("error");
        }
    }
}
