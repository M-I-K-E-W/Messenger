using Microsoft.AspNetCore.SignalR;
using DTOs;
using WebAPI.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Hubs
{
    [AllowAnonymous]
    [EnableCors]
    public class MessageHub : Hub
    {
        //private readonly ILogger<MessageHub> _logger;

        //private MessageHub(ILogger<MessageHub> logger)
        //{
        //    _logger = logger;
        //}

        public override Task OnConnectedAsync()
        {
            //_logger.LogInformation("New Connection");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //_logger.LogInformation("Disconnection");

            return base.OnDisconnectedAsync(exception);
        }

    }
}
