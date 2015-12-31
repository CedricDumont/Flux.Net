using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{
    public class Dispatcher
    {
        private Dispatcher(){}

        public static Dispatcher Instance = new Dispatcher();

        public List<Action<Action>> callbacks = new List<Action<Action>>();

        public void Register(Action<Action> cb)
        {
            callbacks.Add(cb);
        }

        public void Dispatch(Action action)
        {
            callbacks.ForEach((x) => x(action));
        }

    }
}
