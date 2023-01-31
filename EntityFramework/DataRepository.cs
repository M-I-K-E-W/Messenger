using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace EntityFramework
{
    public class DataRepository : IDataRepository
    {
        private readonly ILogger _logger;

        public DataRepository(ILogger<DataRepository> logger)
        {
            _logger = logger;
        }

        #region Users

        public async Task<int?> GetUserIdByCredentials(string email, string password)
        {
            try
            {
                using (var dataContext = new DataContext())
                {
                    var user = await dataContext.Users
                        .FirstOrDefaultAsync(u =>
                            u.Email.ToLower().Equals(email.ToLower())
                            && u.Password.Equals(password));

                    return user?.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<User?> AddUser(User user)
        {
            try
            {

                using (var dataContext = new DataContext())
                {
                    dataContext.Add(user);
                    await dataContext.SaveChangesAsync();

                    return user;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<User?> AddUser(WebNewUserDTO webNewUsereDTO)
        {
            return await AddUser(new User
            {
                Email = webNewUsereDTO.Email,
                Password = webNewUsereDTO.Password,
                FailedAttempts = 0
            });
        }

        public async Task<List<WebUserDTO>?> GetAllUsers()
        {
            try
            {
                using (var dataContext = new DataContext())
                {
                    return await dataContext.Users
                        .Select(u => new WebUserDTO
                        {
                            Id= u.Id,
                            Email = u.Email
                        })
                        .OrderByDescending(m => m.Email)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        #endregion Users

        #region Messages

        public async Task<Message?> AddMessage(Message message)
        {
            try
            {
                using (var dataContext = new DataContext())
                {
                    dataContext.Add(message);
                    await dataContext.SaveChangesAsync();

                    return message;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Message?> AddMessage(WebNewMessageDTO webNewMessageDTO)
        {
            return await AddMessage(new Message
            {
                SenderUserId = webNewMessageDTO.SenderUserId,
                RecipientUserId = webNewMessageDTO.RecipientUserId,
                TimeStamp = DateTime.Now,
                MessageBody = webNewMessageDTO.MessageBody
            });
        }

        public async Task<List<WebMessageDTO>?> GetMessagesByUserId(int UserId)
        {
            try
            {
                using (var dataContext = new DataContext())
                {
                    return await dataContext.Messages
                        .Where(m => m.RecipientUserId == UserId)
                        .Select(n => new WebMessageDTO
                            {
                                TimeStamp = n.TimeStamp,
                                SenderUserId = n.SenderUserId,
                                RecipientUserId = n.RecipientUserId,
                                MessageBody = n.MessageBody
                            })
                        .OrderByDescending(m => m.TimeStamp)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        #endregion Messages

        #region Logging

        // To complete

        #endregion Logging

    }
}
