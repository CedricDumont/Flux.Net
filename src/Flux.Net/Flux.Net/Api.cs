using Flux.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{
    public class Api
    {
        public void DeleteMessage(Message msg)
        {
            Action action = new Action() { Type = ActionTypes.DELETE_MESSAGE, Message = msg };
            action.Dispatch();
        }
    }
}
