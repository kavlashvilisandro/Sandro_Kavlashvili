using Microsoft.AspNetCore.Mvc;
using ToDoAPI.WebAPI.Infrastructure.Models;
using ToDoAPI.Application.Services;
using Mapster;
using ToDoAPI.Application.Services.Models;
using FluentValidation;
using ToDoAPI.WebAPI.Infrastructure.Extensions;
using ToDoAPI.WebAPI.Infrastructure.Auth;
using System.Security.Claims;



namespace ToDoAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IConfiguration config)
        {
            this._userService = userService;
            this._config = config;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterUser( [FromBody] UserDTOWithoutID user, [FromServices] IValidator<UserDTOWithoutID> validator)
        {
            FluentValidation.Results.ValidationResult answer = validator.Validate(user);
            if (!answer.IsValid) return BadRequest(answer.Errors);
            user.Password = user.Password.HashString();
            return Ok(await _userService.AddUserAsync(user.Adapt<UserRequestModel>()));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser([FromBody] UserDTOWithoutID user, [FromServices] IValidator<UserDTOWithoutID> validator)
        {
            FluentValidation.Results.ValidationResult answer = validator.Validate(user);
            if (!answer.IsValid) return BadRequest(answer.Errors);
            user.Password = user.Password.HashString();
            int userID = await _userService.GetUserID(user.Adapt<UserRequestModel>());
            if(userID != 0)
            {
                return Ok(new
                {
                    JWT = JWT.GenerateJwtToken
                    (
                         config: _config,
                         Audiance: _config.GetValue<string>("JWT:UserAudience"),
                         claims: new Claim[] { new Claim("UserName", user.UserName), new Claim("UserID", userID.ToString()) }
                    )
                });
            }
            return BadRequest(new { Message = "Incorrect Credentials" });
        }


    }
}
