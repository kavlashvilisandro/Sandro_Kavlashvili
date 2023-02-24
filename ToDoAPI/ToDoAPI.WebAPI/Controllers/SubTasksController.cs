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
    public class SubTasksController : ControllerBase
    {
        private readonly ISubTaskService _subTaskService;
        private readonly IServiceProvider _serviceProvider;
        public SubTasksController(ISubTaskService service, IServiceProvider provider)
        {
            this._subTaskService = service;
            this._serviceProvider = provider;
        }


        [HttpPost("[action]")]
        [SwaggerOperationFilter(typeof(HeaderParameterOption))]
        public async Task<IActionResult> AddSubTask([FromBody] SubTaskModel model)
        {
            int UserID = JWT.GetUserIDFromUserJWT(HttpContext.Request.Headers);
            int id = await _subTaskService.AddSubTask(model.Adapt<SubTaskRequest>());
            return await Ok(id).Response(_serviceProvider);
        }
    }
}
