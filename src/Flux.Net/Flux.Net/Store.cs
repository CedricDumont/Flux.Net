using Flux.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{

    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class Store
    {
        private IList<Message> messages = new List<Message>();

        public event ChangedEventHandler Changed;

        public IList<Message> Messages {
            get
            {
                return messages;
            }
        }

        public void AddMessage(Message msg)
        {
            this.messages.Add(msg);
            NotifyChange();
        }

        public void RemoveMessage(Message message)
        {
            Message msgtobeRemoved = this.messages.Where((msg) => msg.Id == message.Id).FirstOrDefault();
            this.messages.Remove(msgtobeRemoved);
            NotifyChange();
        }

        private void NotifyChange()
        {
            if (Changed != null)
            {
                Changed(this, null);
            }
        }


        public void HandleAction(Action action)
        {
            switch(action.Type)
            {
                case ActionTypes.ADD_MESSAGE:
                    this.AddMessage(action.Message);
                    break;
                case ActionTypes.DELETE_MESSAGE:
                    this.RemoveMessage(action.Message);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
