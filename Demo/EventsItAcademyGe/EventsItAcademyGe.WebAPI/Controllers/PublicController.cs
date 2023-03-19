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
        public PublicController(IUserService userService, IEventService eventService, IConfiguration config)
        {
            this._userService = userService;
            this._config = config;
            this._eventService = eventService;
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
            int id = await _userService.LoginUser(newUser.Adapt<UserRequestModel>(ToUserServiceRequestModel.UserDTOToUserRequestModel), token);
            //Claims: Role = User and UserID = id
            return JWT.GenerateJwtToken(_config, new Claim(ClaimTypes.Role, "User"), new Claim("UserID", id.ToString()));
        }


        [HttpGet("[action]")]
        public async Task<List<EventResponseDTO>> GetAllActiveEvents(CancellationToken token)
        {
            return (await _eventService.GetAllActiveEvents(token)).Adapt<List<EventResponseDTO>>
                (FromIEventResponseModel.FromIEventResponseModelToEventResponseModel);
        }
    }
}
