using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerPlanning.API.Hubs
{
    public class RoomHub : Hub
    {
        public async Task ShowResult(long roomId)
        {
            List<string> users = new List<string>();
            List<string> result = new List<string>();
            await Clients.Clients(users).SendAsync("showResult", result);
        }
    }
}
