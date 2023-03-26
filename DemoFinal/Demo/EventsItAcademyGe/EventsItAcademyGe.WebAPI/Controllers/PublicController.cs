using Microsoft.AspNetCore.Mvc;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using EventsItAcademyGe.Application.Services;
using EventsItAcademyGe.Application.Services.Models;
using Mapster;
using EventsItAcademyGe.WebAPI.Infrastructure.Mappings;
using EventsItAcademyGe.WebAPI.Infrastructure.Auth;
using System.Security.Claims;


namespace EventsItAcademyGe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly IConfiguration _config;
        private readonly IAdminService _adminService;
        public PublicController(IUserService userService, IEventService eventService, IConfiguration config
            ,IAdminService adminService)
        {
            this._userService = userService;
            this._config = config;
            this._eventService = eventService;
            this._adminService = adminService;
        }


        [HttpPost("[action]")]
        public async Task<int> RegisterUser([FromBody] UserLoginRegistrationDTO newUser, CancellationToken token)
        {
            newUser.HashObject();
            return await _userService.AddUserAsync(newUser.Adapt<UserRequestModel>(ToUserServiceRequestModel.UserDTOToUserRequestModel), token);
        }


        [HttpPost("[action]")]
        public async Task<string> LoginUser([FromBody] UserLoginRegistrationDTO newUser, CancellationToken token)
        {
            newUser.HashObject();
            (int id, bool IsModerator )= await _userService.LoginUser(newUser.Adapt<UserRequestModel>(ToUserServiceRequestModel.UserDTOToUserRequestModel), token);
            if (IsModerator)
            {
                return JWT.GenerateJwtToken(_config, new Claim(ClaimTypes.Role, "Moderator"), new Claim(ClaimTypes.Role, "User"), 
                                                     new Claim("UserID", id.ToString()));
            }
            //Claims: Role = User and UserID = id
            return JWT.GenerateJwtToken(_config, new Claim(ClaimTypes.Role, "User"), new Claim("UserID", id.ToString()));
        }


        [HttpGet("[action]")]
        public async Task<List<EventResponseDTO>> GetAllActiveEvents(CancellationToken token)
        {
            return (await _eventService.GetAllActiveEvents(token)).Adapt<List<EventResponseDTO>>
                (FromIEventResponseModel.FromIEventResponseModelToEventResponseModel);
        }



        [HttpPost("[action]")]
        public async Task<string> LoginAdmin([FromBody] AdminDTO admin, CancellationToken token)
        {
            int AdminID = await _adminService.LoginAdmin(admin.Adapt<AdminRequestModel>(), token);
            return JWT.GenerateJwtToken(_config, new Claim(ClaimTypes.Role, "Admin"), new Claim("AdminID", AdminID.ToString())); ;
        }

        [HttpGet("[action]/{EventID}")]
        public async Task<EventResponseDTO> GetEventByID(int EventID,CancellationToken token)
        {
            return (await _eventService.GetEventByID(EventID, token)).Adapt<EventResponseDTO>
                (FromIEventResponseModel.FromIEventResponseModelToEventResponseModel);
        }
    }
}
