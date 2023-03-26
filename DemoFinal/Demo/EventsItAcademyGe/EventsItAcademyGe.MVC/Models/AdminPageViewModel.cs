using EventsItAcademyGe.MVC.Infrastructure.Clients.Models;

namespace EventsItAcademyGe.MVC.Models
{
    public class AdminPageViewModel
    {
        public List<EventResponseModel> PendingEvents { get; set; }
        public bool IsAdmin { get; set; }
    }
}
