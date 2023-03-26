using Microsoft.AspNetCore.Mvc;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using EventsItAcademyGe.Application.Services;
using EventsItAcademyGe.Application.Services.Models;
using Mapster;
using EventsItAcademyGe.WebAPI.Infrastructure.Mappings;
using EventsItAcademyGe.WebAPI.Infrastructure.Auth;
using Microsoft.AspNetCore.JsonPatch;
using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly IConfiguration _config;
        public UserController(IUserService userService,IEventService eventService,IConfiguration config)
        {
            this._userService = userService;
            this._config = config;
            this._eventService = eventService;
        }


        [HttpPost("[action]")]
        public async Task<int> AddEvent(EventDTO @event,CancellationToken token)
        {
            EventDTOWithOwnerID Event = @event.Adapt<EventDTOWithOwnerID>();
            Event.ownerID = JWT.GetUserIDFromJWT(HttpContext.Request.Headers["Authorization"]);
            return await _eventService.AddNewEvent(Event.Adapt<EventRequestModel>(ToEventRequestModel.EventDTOWithOwnerIDToEventRequestModel),token);
        }


        [HttpPost("[action]")]
        public async Task<List<int>> AddEvents(List<EventDTO> @event, CancellationToken token)
        {
            List<EventDTOWithOwnerID> Events = @event.Adapt<List<EventDTOWithOwnerID>>();
            for (int i = 0; i < Events.Count; i++)
            {
                Events[i].ownerID = JWT.GetUserIDFromJWT(HttpContext.Request.Headers["Authorization"]);
            }
            return await _eventService.AddNewEvents(Events.GetEventRequestModels(), token);
        }
        

        [HttpPost("[action]/{EventID}")]//This method returns ReservationID
        public async Task<int> ReserveTicket(int EventID,CancellationToken token)
        {
            int UserID = JWT.GetUserIDFromJWT(HttpContext.Request.Headers["Authorization"]);
            return await _eventService.ReserveTicket(UserID, EventID, token);
        }

        [HttpGet("[action]/{EventID}")]
        public async Task BuyTicket(int EventID,CancellationToken token)
        {
            int UserID = JWT.GetUserIDFromJWT(HttpContext.Request.Headers["Authorization"]);
            await _eventService.BuyTicket(UserID, EventID, token);
        }

        [HttpPatch("[action]/{EventID}")]//PATCH = Partial update
        public async Task UpdateEntity(int EventID,[FromBody] JsonPatchDocument<Event> updateModel,CancellationToken token)
        {
            int UserID = JWT.GetUserIDFromJWT(HttpContext.Request.Headers["Authorization"]);
            int TimeLimit = _config.GetValue<int>("EventUpdateTimeLimitInDays");
            await _eventService.UpdatePartialEvent(TimeLimit, UserID, EventID, updateModel, token);
        }
        

    }
}
