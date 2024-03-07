using Microsoft.AspNetCore.SignalR;

namespace PruebaSignalR.SignalR
{
    public class BeerHub : Hub
    {
        public async Task Send(string Name , string Brand) 
        { 
            await Clients.All.SendAsync("Receive",Name, Brand);
        }
    }
}
