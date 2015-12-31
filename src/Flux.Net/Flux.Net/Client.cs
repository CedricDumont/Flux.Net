using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{
    public class Client
    {
        public Store _store;
    
        public string Name { get; } 

        public Client(String name, Store store)
        {
            this.Name = name;
            this._store = store;
            this._store.Changed += StoreChanged;
        }

        public void StoreChanged(object sender, EventArgs args)
        {
            //Kind of rendering
            Console.WriteLine($"I am {Name} and Got a change event from store : new data is :" + _store.Data);
        }

        public void ChangeData(string data)
        {
            Action action = new Action() { Type = ActionTypes.CHANGE_DATA, Data = data };
            action.Dispatch();
        }
    }
}
