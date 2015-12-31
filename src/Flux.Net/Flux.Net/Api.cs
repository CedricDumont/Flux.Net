using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{
    public class Api
    {
        public void UpperCaseData()
        {
            Action action = new Action() { Type = Action.UPPERCASE_DATA, Data = null };
            action.Dispatch();
        }
    }
}
