using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkr1.State
{
    public class ValidationContext
    {
        private IValidationState _state;

        public ValidationContext(IValidationState initialState)
        {
            _state = initialState;
        }

        public void SetState(IValidationState state)
        {
            _state = state;
        }

        public void Apply(LightElementNode element)
        {
            _state.Apply(element);
        }
    }

}
