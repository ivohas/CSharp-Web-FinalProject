using Microsoft.AspNetCore.SignalR;

namespace BookFindingAndRatingSystem.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var userName = Context.User!.Identity!.Name;
            await Clients.All.SendAsync("ReceiveMessage", userName, message);           
        }
    }
}
