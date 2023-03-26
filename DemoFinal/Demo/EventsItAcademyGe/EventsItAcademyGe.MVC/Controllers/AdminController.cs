using Microsoft.AspNetCore.Mvc;
using EventsItAcademyGe.MVC.Infrastructure.Models;
using EventsItAcademyGe.MVC.Infrastructure.Clients;
using EventsItAcademyGe.MVC.Models;
using EventsItAcademyGe.MVC.Infrastructure.Clients.Models;
using EventsItAcademyGe.WebAPI.Infrastructure.Auth;
using EventsItAcademyGe.Domain.Exceptions;

namespace EventsItAcademyGe.MVC.Controllers
{
    public class AdminController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly EventsItAcademyGeAdminClient _client;
        public AdminController(EventsItAcademyGeAdminClient client, IConfiguration config)
        {
            this._client = client;
            this._configuration = config;
        }

        public async Task<ViewResult> AdminPage(CancellationToken token)
        {
            if(Request.Cookies["JWT"] != null && (JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Admin", _configuration)
                 || JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Moderator", _configuration)))
            {
                List<EventResponseModel> PendingEvents = await _client.GetPendingEvents(Request.Cookies["JWT"], token);

                AdminPageViewModel ViewModel = new AdminPageViewModel()
                {
                    PendingEvents = PendingEvents,
                    IsAdmin = JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Admin", _configuration)
                };
                return View(ViewModel);
            }
            else
            {
                throw new APIRequestError("You arenot admin or moderator", 403);
            }
        }

        public async Task<ViewResult> AdminLoginPage(CancellationToken token)
        {
            return View();
        }

        [HttpPost]
        public async Task<RedirectToActionResult> LoginAdmin(AdminDTO admin,CancellationToken token)
        {
            string jwt = await _client.LoginAdmin(admin, token);
            Response.Cookies.Append("JWT", jwt, new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1)
            });
            return RedirectToAction("AdminPage", "Admin");
        }

        [Route("[controller]/[action]/{EventID}")]
        public async Task<RedirectToActionResult> ActivateEvent(int EventID, CancellationToken token)
        {
            if (Request.Cookies["JWT"] != null && 
                (JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Admin", _configuration) || JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Moderator", _configuration)))
            {
                await _client.ActivateEvent(Request.Cookies["JWT"], EventID, token);
                return RedirectToAction("AdminPage", "Admin");
            }
            else
            {
                throw new APIRequestError("You arenot admin or moderator", 403);
            }
        }


        [Route("[controller]/[action]")]
        public async Task<RedirectToActionResult> ChangeEventUpdateTimeLimit(int DaysAmount, CancellationToken token)
        {
            if (Request.Cookies["JWT"] != null && JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Admin", _configuration))
            {
                await _client.ChangeUpdateTimeLimit(Request.Cookies["JWT"], DaysAmount, token);
                return RedirectToAction("AdminPage", "Admin");
            }
            else
            {
                throw new APIRequestError("You arenot admin", 403);
            }
        }


        [Route("[controller]/[action]")]
        public async Task<RedirectToActionResult> SetUserAsAdmin(int UserID,CancellationToken token)
        {
            if (Request.Cookies["JWT"] != null && JWT.IsAuthenticatedJWT(Request.Cookies["JWT"], "Admin", _configuration))
            {
                await _client.SetAsModerator(Request.Cookies["JWT"], UserID, token);
                return RedirectToAction("AdminPage", "Admin");
            }
            else
            {
                throw new APIRequestError("You arenot admin", 403);
            }
        }
    }
}
