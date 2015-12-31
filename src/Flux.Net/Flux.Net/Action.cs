using Flux.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{
    public class Action
    {
        public ActionTypes Type { get; set; }

        public Message Message { get; set; }

        public void Dispatch()
        {
            Dispatcher.Instance.Dispatch(this);
        }

    }
}
