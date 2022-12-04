using CloudChatService.API.Hubs;
using CloudChatService.Core.DTOs.Message;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Security.Claims;

namespace CloudChatService.API.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        private static int _usersCount;
        private static Dictionary<string, UserData> _users = new Dictionary<string, UserData>();
        public override Task OnConnectedAsync()
        {
            var phoneNumber = Context.User.FindFirstValue(ClaimTypes.MobilePhone);

            Interlocked.Increment(ref _usersCount);
            var user = new UserData()
            {
                Active = true,
                ConnectionNumber = _usersCount,
                ConnectedAt = DateTime.Now,
                ConnectionId = Context.ConnectionId
            };
            Debug.WriteLine("ConnectionId: " + user.ConnectionId);
            _users[phoneNumber] = user;
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(MessageDTO<IFormFile> message)
        {
            UserData user;
            if (_users.TryGetValue(message.ReceiverPhoneNumber, out user))
            {
                await Clients.Client(user.ConnectionId).SendAsync("ReceiveMessage", $"{message.MessageTxt}");
            }
        }
        public async Task JoinGroup(string gName, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, user);
            //Clients.OthersInGroup(gName).newMember(user, gName);
        }
        public async Task SendToGroup(string gName, string username, string message)
        {
            await Clients.Group(gName).SendAsync(username, gName, message);
        }
    }
}
