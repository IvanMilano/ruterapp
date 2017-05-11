using Microsoft.Owin;
using Owin;
using RuterApp.Web;

[assembly: OwinStartup(typeof(SignalRStartup))]
namespace RuterApp.Web
{
    public class SignalRStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}