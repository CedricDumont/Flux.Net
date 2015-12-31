using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Flux.Net.Web.Startup))]

namespace Flux.Net.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //the line below is just needed to bootsrap the application.
            //it should (will) be replaced by DI later on
            var bootstrap = MessageStore.Instance; 
        }
    }
}
