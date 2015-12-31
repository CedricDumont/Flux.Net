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
        public string data;

        public event ChangedEventHandler Changed;

        public string Data {
            get
            {
                return data;
            }
            private set
            {
                data = value;
                if(Changed != null)
                {
                    Changed(this, null);
                }
            }
        }

        public void HandleAction(Action action)
        {
            switch(action.Type)
            {
                case ActionTypes.CHANGE_DATA:
                    this.Data = action.Data;
                    break;
                case ActionTypes.UPPERCASE_DATA:
                    this.Data = this.Data.ToUpper();
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
