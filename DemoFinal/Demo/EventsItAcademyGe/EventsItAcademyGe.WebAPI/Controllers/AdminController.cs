using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventsItAcademyGe.Application.Services;
using System.Text.Json;
using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using Mapster;
using EventsItAcademyGe.WebAPI.Infrastructure.Mappings;

namespace EventsItAcademyGe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IEventService _eventServices;
        private readonly IAdminService _adminService;

        public AdminController(IEventService eventService, IAdminService adminService)
        {
            this._eventServices = eventService;
            this._adminService = adminService;
        }



        [Authorize(Roles = "Admin")]
        [HttpPost("[action]/{DaysAmount}")]
        public async Task ChangeEventUpdateTimeLimit(int DaysAmount, CancellationToken token)
        {
            if (DaysAmount <= 0) throw new IncorrectDaysAmountException();
            string path = Directory.GetCurrentDirectory() + @"\appsettings.json";
            string AppSettingsAsJson = await System.IO.File.ReadAllTextAsync(path, token);
            Dictionary<string, object> AppSettings = JsonSerializer.Deserialize<Dictionary<string, object>>(AppSettingsAsJson);
            AppSettings["EventUpdateTimeLimitInDays"] = DaysAmount;
            System.IO.File.WriteAllText(path, JsonSerializer.Serialize(AppSettings, new JsonSerializerOptions() { WriteIndented = true }));
        }



        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet("[action]")]
        public async Task<List<EventResponseDTO>> GetAllPendingEvents(CancellationToken token)
        {
            return (await _eventServices.GetAllPendingEvents(token)).Adapt<List<EventResponseDTO>>
                (FromIEventResponseModel.FromIEventResponseModelToEventResponseModel);
        }


        [Authorize(Roles = "Admin,Moderator")]
        [HttpPatch("[action]/{EventID}")]
        public async Task ActivateEvent(int EventID, CancellationToken token)
        {
            await _eventServices.ActivatePendingEvent(EventID, token);
        }



        [Authorize(Roles = "Admin")]
        [HttpPatch("[action]/{UserID}")]
        public async Task SetAsModerator(int UserID, CancellationToken token)
        {
            await _adminService.SetAsModerator(UserID, token);
        }
    }
}
