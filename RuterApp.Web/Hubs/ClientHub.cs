using Microsoft.AspNet.SignalR;

namespace RuterApp.Web.Hubs
{
    public class ClientHub : Hub
    {
        public static void Notify(HoldeplassInfoViewModel holdeplassInfoViewModel)
        {
            //var _hub = GlobalHost.ConnectionManager.GetHubContext<RuterAppHub>();
            _hub.Clients.All.displayHoldePlasser(holdeplassInfoViewModel);
        }

        static readonly IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<RuterAppHub>();
    }
}