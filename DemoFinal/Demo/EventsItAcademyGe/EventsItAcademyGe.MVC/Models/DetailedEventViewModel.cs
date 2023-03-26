using EventsItAcademyGe.MVC.Infrastructure.Models;

namespace EventsItAcademyGe.MVC.Models
{
    public class DetailedEventViewModel
    {
        public EventModel Event { get; set; }
        public string JWT { get; set; }
    }
}
