using DTOs;
using EntityFramework.Interfaces;
using EntityFramework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using WebAPI.Hubs;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api")]
    public class MessageCenterController : ControllerBase
    {
        private readonly ILogger<MessageCenterController> _logger;
        private readonly IDataRepository _dataRepository;
        private readonly IHubContext<MessageHub> _messageHub;

        public MessageCenterController(
            ILogger<MessageCenterController> logger,
            IHubContext<MessageHub> hubContext,
            IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _messageHub = hubContext;
        }

        #region Messages

        [Route("addNewMessage")]
        [EnableCors]
        [HttpPost]
        public async Task<IActionResult> addNewMessage([FromForm] WebNewMessageDTO webNewMessageDTO)
        {
            try { 

                // Save new message
                var message = await _dataRepository.AddMessage(webNewMessageDTO);

                if (message != null) { 

                    // Send signalR message
                    var webMessageDTO = new WebMessageDTO
                    {
                        Id = message.Id,
                        SenderUserId = message.SenderUserId,
                        RecipientUserId= message.RecipientUserId,
                        TimeStamp = message.TimeStamp,
                        MessageBody= message.MessageBody
                    };

                    await _messageHub.Clients.All.SendAsync("NewMessage", webMessageDTO);

                    return Ok();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return BadRequest();
        }

        [Route("getMessages")]
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<WebMessageDTO>?>> GetMessages([FromForm]int recipientId)
        {
            try { 
                return await _dataRepository.GetMessagesByUserId(recipientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return BadRequest();
        }

        #endregion Messages

        #region Users

        [Route("addUser")]
        [EnableCors]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] WebNewUserDTO webNewUsereDTO)
        {
            try
            {

                // Save new user
                var user = await _dataRepository.AddUser(webNewUsereDTO);

                if (user != null)
                {

                    // Send signalR message
                    var webUserDTO = new WebUserDTO
                    {
                        Id = user.Id,
                        Email = user.Email
                    };
                    await _messageHub.Clients.All.SendAsync("NewUser", webUserDTO);

                    return Ok();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return BadRequest();
        }

        [Route("getRecipients")]
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<WebUserDTO>?>> GetRecipients([FromForm] int userId)
        {
            return await _dataRepository.GetAllUsers();
        }

        [Route("getUserIdByCredentials")]
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<int?>> GetUserIdByCredentials([FromForm]string email, [FromForm]string password)
        {
            return await _dataRepository.GetUserIdByCredentials(email, password);
        }

        #endregion Users

    }
}