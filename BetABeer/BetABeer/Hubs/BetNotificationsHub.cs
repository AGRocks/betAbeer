using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BetABeer.Hubs
{
    public class BetNotificationsHub : Hub
    {        
        public void SendBetUpdate(long betId)
        {
            Clients.All.newBetArrived(betId);
        }
    }
}