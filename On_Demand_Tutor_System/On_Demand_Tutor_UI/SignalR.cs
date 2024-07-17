using Microsoft.AspNetCore.SignalR;

namespace On_Demand_Tutor_UI
{
    public class SignalR : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
