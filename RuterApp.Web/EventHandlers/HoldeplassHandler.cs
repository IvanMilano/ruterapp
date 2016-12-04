using System.Threading.Tasks;
using NServiceBus;
using RuterApp.Contracts;
using RuterApp.Contracts.Events;
using RuterApp.Web.Hubs;

namespace RuterApp.Web.EventHandlers
{
    public class HoldeplassHandler : IHandleMessages<HoldeplassInfoProcessed>
    {
        public Task Handle(HoldeplassInfoProcessed message, IMessageHandlerContext context)
        {
            ClientHub.Notify(new HoldeplassInfoViewModel
            {
                Navn = message.Navn,
                LinjeNavn = message.LinjeNavn,
                Direction = message.Direction,
                Holdeplass = message.Holdeplass,
                TidTilAnkomst = message.TidTilAnkomst,
                Forsinkelse = message.Forsinkelse
            });

            return Task.CompletedTask;
        }
    }
}