using Microsoft.AspNetCore.Mvc;
using ToDoAPI.WebAPI.Infrastructure.Models;
using ToDoAPI.Application.Services;
using Mapster;
using ToDoAPI.Application.Services.Models;
using FluentValidation;
using ToDoAPI.WebAPI.Infrastructure.Extensions;
using ToDoAPI.WebAPI.Infrastructure.Auth;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Annotations;
using ToDoAPI.WebAPI.Infrastructure.Mappings;

namespace ToDoAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoService _toDoService;
        
        public ToDoController(IToDoService toDoService)
        {
            this._toDoService = toDoService;
        }



        [HttpPost("LoggedIn/[action]")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        public async Task<IActionResult> CreateToDo([FromBody] ToDoRegisterDTO todo, [FromServices] IValidator<ToDoRegisterDTO> validator)
        {
            FluentValidation.Results.ValidationResult res = validator.Validate(todo);
            if (!res.IsValid) return BadRequest(res.Errors);
            int UserID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            ToDoModel SendingModel = todo.Adapt<ToDoModel>(ToDoMapping.FromToDoRegisterToModel);
            SendingModel.OwnerID = UserID;
            return Ok(await _toDoService.AddToDo(SendingModel.Adapt<ToDoRequestModel>()));
        }
    
    
    
        [HttpGet("LoggedIn/[action]")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        //Statusses: 1(active), 2(done), 3(deleted)
        //სტატუსი უნდა იყოს 1 ან 2, რადგან წაშლილების წამოღება არ შეგვიძლია
        public async Task<IActionResult> GetAllToDos(int? status = null)
        {
            if(status != null && (status < 1 || status > 2))
            {
                throw new Exception("Status should be active or done (1 -> active), (2 -> done)");
            }
            int UserID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            return Ok(await _toDoService.GetAllToDos(UserID,status));
        }
    
        [HttpGet("LoggedIn/[action]/{ToDoID}")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        public async Task<IActionResult> GetToDo(int ToDoID)
        {
            int UserID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            return Ok(await _toDoService.GetToDo(ToDoID, UserID));
        }


        [HttpPut("LoggedIn/[action]/{ToDoID}")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        public async Task<IActionResult> UpdateToDo(int ToDoID,[FromBody] ToDoUpdateDTO newModel)
        {
            int UserID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            return Ok(await _toDoService.UpdateToDo(UserID, ToDoID, newModel.Adapt<ToDoRequestModel>()));
        }
        

        [HttpPut("loggedIn/[action]/{ToDoID}/Done")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        public async Task<IActionResult> UpdateToDoAsDone(int ToDoID)
        {
            int userID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            return Ok(await _toDoService.SetToDoAsDone(userID, ToDoID));
        }
    
        [HttpPut("loggedIn/[action]/{ToDoID}/Delete")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        public async Task<IActionResult> DeleteToDo(int ToDoID)
        {
            int UserID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            return Ok(await _toDoService.DeleteToDo(UserID, ToDoID));
        }
    }
}
