using Microsoft.Owin;

using Owin;
using RuterApp.Web.App_Start;

[assembly: OwinStartup(typeof(SignalRStartup))]
namespace RuterApp.Web.App_Start
{
    public class SignalRStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}