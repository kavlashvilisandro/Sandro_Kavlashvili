using EventsItAcademyGe.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using EventsItAcademyGe.MVC.Infrastructure.Models;
using EventsItAcademyGe.MVC.Infrastructure.Clients;
using EventsItAcademyGe.MVC.Infrastructure.Extensions;
using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.WebAPI.Infrastructure.Auth;

namespace EventsItAcademyGe.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventsItAcademyGePublicClient _publicClient;
        private readonly IConfiguration _configuration;
        public HomeController(EventsItAcademyGePublicClient publicClient, IConfiguration config)
        {
            this._publicClient = publicClient;
            this._configuration = config;
        }
        public async Task<ViewResult> Index(CancellationToken token)
        {
            List<EventModel> events = await _publicClient.GetActiveEventsAsync(token);
            if (Request.Cookies["JWT"] != null && JWT.IsAuthenticatedJWT(Request.Cookies["JWT"],"User",_configuration))
            {
                return View(new HomePageViewModel { activeEvents = events, IsAuthorized = true });
            }
            return View(new HomePageViewModel { activeEvents = events, IsAuthorized = false});
        }


        [Route("[controller]/[action]/{EventID}")]
        public async Task<ViewResult> DetailedEvent(int EventID, CancellationToken token)
        {
            string jwt = Request.Cookies["JWT"];
            EventModel @event = await _publicClient.GetEventByID(EventID, token);
            if (jwt != null && JWT.IsAuthenticatedJWT(jwt, "User", _configuration))
            {
                return View(new DetailedEventViewModel() { Event = @event, JWT = jwt });
            }
            return View(new DetailedEventViewModel() { Event = @event, JWT = null });
        }
    


        [Route("[controller]/[action]/{StringPointer}/{TraceID}")]//TODO: gasasworebelia
        public async unsafe Task<ViewResult> Error(string StringPointer,string TraceID,CancellationToken token)
        {
            Console.WriteLine();//Delete
            if (!TraceID.Equals(HttpContext.TraceIdentifier.Split(":")[0]))
            {
                ErrorViewModel error = new ErrorViewModel(
                    new APIRequestError("You don't have permission on this resources", 403));
                return View(error);
            }
            ErrorViewModel Error = *StringPointer.ToPointer<ErrorViewModel>();
            return View(Error);
        }  
    
        public async Task<ViewResult> LogInPage(CancellationToken token)
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        public async Task<RedirectToActionResult> LogIn(UserModelDTO user,CancellationToken token)
        {
            string jwt = await _publicClient.LogIn(user,token);
            Response.Cookies.Append("JWT", jwt, new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1)
            });
            return RedirectToAction("Index","Home");
        }

        public async Task<RedirectToActionResult> LogOut(CancellationToken token)
        {
            string jwt = Request.Cookies["JWT"];
            if(jwt != null)
            {
                Response.Cookies.Delete("JWT");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ViewResult> RegisterPage(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Register(UserModelDTO user,CancellationToken token)
        {
            await _publicClient.Register(user,token);
            return RedirectToAction("LogInPage", "Home");
        }
    }
}