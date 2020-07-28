using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureSignalR.SignalR.Hubs
{
    public class SimpleNotificationsHub : Hub
    {
        public SimpleNotificationsHub()
        {

        }

        public void BroadcastMessage(string message)
        {
            Clients.All.SendAsync("broadcastMessage", message);
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }
    }
}
