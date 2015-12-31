using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = Dispatcher.Instance;
            Store store = new Store();
            dispatcher.Register(store.HandleAction);
            Client cli1 = new Client("Bill", store);
            Client cli2 = new Client("Jing", store);
            cli1.CreateMessage("Hey jin, how are you");
            cli2.CreateMessage("Fine thanks !");

            Console.ReadLine();
        }
    }
}
