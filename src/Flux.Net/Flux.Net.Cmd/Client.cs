using Flux.Net.Model;
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
            Message lastMessage = _store.Messages.Last();
            //Kind of rendering
            Console.WriteLine($"[{this.Name} display ] {lastMessage.Author.Name} : {lastMessage.Text}");
        }

        public void CreateMessage(string text)
        {
            Author author = new Author() { Name = this.Name };
            Message msg = new Message(author, text);
            Action action = new Action() { Type = ActionTypes.ADD_MESSAGE, Message = msg };
            action.Dispatch();
        }

        public void DeleteMessage(Message msg)
        {
            Action action = new Action() { Type = ActionTypes.DELETE_MESSAGE, Message = msg };
            action.Dispatch();
        }
    }
}
