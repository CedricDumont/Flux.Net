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
            Client cli1 = new Client("client 1", store);
            Client cli2 = new Client("client 2", store);
            cli1.ChangeData("newData");
            cli1.ChangeData("anotherData");
            Api api = new Api();
            api.UpperCaseData();

            Console.ReadLine();
        }
    }
}
