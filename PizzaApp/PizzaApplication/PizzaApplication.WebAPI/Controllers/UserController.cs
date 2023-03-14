using Microsoft.AspNetCore.Mvc;
using PizzaApplication.WebAPI.Infrastrucutre.Models;
using FluentValidation;
using FluentValidation.Results;
using PizzaApplication.WebAPI.Infrastrucutre.Abstractions;
using Mapster;
using Application.Models;
using Repository;

namespace PizzaApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] UserModel user, [FromServices] IValidator<UserModel> UserValidator)
        {
            ValidationResult validationResult = await UserValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            return Ok(await UserServices.AddUser(user.Adapt<UserRequestModel>()));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Id must me greater than 0");
            }
            IUserResponseModel res = await UserServices.GetUser(id);
            if(res == null)
            {
                return BadRequest("There is not user with this id");
            }
            return Ok(new UserDTO(res));
            
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(DBContext.users);
        }
    }
}
