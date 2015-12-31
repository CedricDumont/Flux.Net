using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Flux.Net.Model;

namespace Flux.Net.Web
{
    public class MessageActions : Hub
    {
        public void CreateMessage(string name, string message)
        {
            Author author = new Author() { Name = name };
            Message msg = new Message(author, message);
            Action action = new Action() { Type = ActionTypes.ADD_MESSAGE, Message = msg };
            action.Dispatch();
        }

        
    }
}