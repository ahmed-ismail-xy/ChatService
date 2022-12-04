using CloudChatService.Infrastructure.Data;
using CloudChatService.Infrastrucure.Data;
using Microsoft.AspNetCore.SignalR;

namespace CloudChatService.API.Hubs
{
    public class HubService 
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ApplicationDbContext _dataContext;
        public HubService(IHubContext<ChatHub> hubContext, ApplicationDbContext dbContext)
        {
            _hubContext = hubContext;
            _dataContext = dbContext;
        }
        public async Task SendMessageAsync(string request, string _email)
        {
        }

        public async Task JoinGroup(string gName, string user)
        {
           // await _hubContext.Groups.AddToGroupAsync(_hubContext..ConnectionId, user);
            //Clients.OthersInGroup(gName).newMember(user, gName);
        }
        public async Task SendToGroup(string gName, string username, string message)
        {
           // await Clients.Group(gName).SendAsync(username, gName, message);
        }

    }
}
