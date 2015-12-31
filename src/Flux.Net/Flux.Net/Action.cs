﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Net
{


    public class Action
    {

        public string Type { get; set; }

        public string Data { get; set; }

        public void Dispatch()
        {
            Dispatcher.Instance.Dispatch(this);
        }


    }
}
