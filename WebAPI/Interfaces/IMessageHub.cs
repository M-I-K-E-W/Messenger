using DTOs;

namespace WebAPI.Interfaces
{
    public interface IMessageHub
    {
        Task NewMessage(WebMessageDTO webMessage);
        Task NewUser(WebUserDTO webUserDTO);
        Task OnConnectedAsync();
        Task OnDisconnectedAsync(Exception? exception);
    }
}