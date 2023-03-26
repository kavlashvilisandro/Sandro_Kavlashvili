using Microsoft.AspNetCore.Mvc;
using EventsItAcademyGe.MVC.Infrastructure.Clients;
using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.MVC.Infrastructure.Models;
using EventsItAcademyGe.WebAPI.Infrastructure.Auth;

namespace EventsItAcademyGe.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly EventsItAcademyGeUserClient _userClient;
        public UserController(EventsItAcademyGeUserClient userClient, IConfiguration configuration)
        {
            this._userClient = userClient;
            this._configuration = configuration;
        }


        [Route("[controller]/[action]/{EventID}")]
        public async Task<RedirectToActionResult> BuyTicket(int EventID, CancellationToken token)
        {
            if(Request.Cookies["JWT"] == null || !JWT.IsAuthenticatedJWT(Request.Cookies["JWT"],"User",_configuration))
            {
                throw new APIRequestError("you are't authorized", 403);
            }
            else
            {
                await _userClient.BuyTicket(Request.Cookies["JWT"], EventID, token);
            }
            return RedirectToAction("DetailedEvent","Home",new { EventID = EventID});

        }
        [Route("[controller]/[action]/{EventID}")]
        public async Task<RedirectToActionResult> ReserveTicket(int EventID, CancellationToken token)
        {
            if (Request.Cookies["JWT"] == null || !JWT.IsAuthenticatedJWT(Request.Cookies["JWT"],"User",_configuration))
            {
                throw new APIRequestError("you are't authorized", 403);
            }
            else
            {
                await _userClient.ReserveTicket(Request.Cookies["JWT"], EventID, token);
            }
            return RedirectToAction("DetailedEvent", "Home", new { EventID = EventID });
        }


        [HttpPost]
        public async Task<RedirectToActionResult> AddEvent(RegisterEventDTO @event,CancellationToken token)
        {
            if(Request.Cookies["JWT"] == null || !JWT.IsAuthenticatedJWT(Request.Cookies["JWT"],"User",_configuration))
            {
                throw new APIRequestError("you are't authorized", 403);
            }
            await _userClient.AddEvent(@event,Request.Cookies["JWT"],token);
            return RedirectToAction("Index", "Home");
        }

        public async Task<ViewResult> AddEventPage(CancellationToken token)
        {
            if(Request.Cookies["JWT"] == null || !JWT.IsAuthenticatedJWT(Request.Cookies["JWT"],"User",_configuration))
            {
                throw new APIRequestError("you are't authorized", 403);
            }
            return View();
        } 
    }
}
