using EntityFramework.Models;
using DTOs;

namespace EntityFramework.Interfaces
{
    public interface IDataRepository
    {

        Task<User> AddUser(User user);
        Task<User?> AddUser(WebNewUserDTO webNewUsereDTO);
        Task<int?> GetUserIdByCredentials(string email, string password);
        Task<List<WebUserDTO>?> GetAllUsers();

        Task<Message?> AddMessage(Message message);
        Task<Message?> AddMessage(WebNewMessageDTO webNewMessageDTO);
        Task<List<WebMessageDTO>?> GetMessagesByUserId(int UserId);
        
    }
}