using Flux.Net.Model;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flux.Net.Web
{
    public class MessageStore
    {
        public static Store _store;

        private readonly static Lazy<MessageStore> _instance = new Lazy<MessageStore>(
         () => new MessageStore(GlobalHost.ConnectionManager.GetHubContext<MessageActions>(), Dispatcher.Instance));

        private IHubContext _context;

        private MessageStore(IHubContext context, Dispatcher dispatcher)
        {
            _context = context;
            _store = new Store();
            _store.Changed += StoreChanged;
            dispatcher.Register(_store.HandleAction);
        }

        public static MessageStore Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void StoreChanged(object sender, EventArgs args)
        {
            Message lastMessage = _store.Messages.Last();

            _context.Clients.All.broadcastMessage(lastMessage.Author.Name, lastMessage.Text);
        }


    }
}