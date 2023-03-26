using EventsItAcademyGe.MVC.Infrastructure.Models;


namespace EventsItAcademyGe.MVC.Models
{
    public class HomePageViewModel
    {
        public List<EventModel> activeEvents { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
