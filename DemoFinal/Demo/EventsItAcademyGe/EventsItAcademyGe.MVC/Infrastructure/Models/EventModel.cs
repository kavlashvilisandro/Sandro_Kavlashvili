namespace EventsItAcademyGe.MVC.Infrastructure.Models
{
    public class EventModel
    {
        public int ownerID { get; set; }
        public int EventID { get; set; }
        public string eventName { get; set; } = "";
        public string eventDescription { get; set; } = "";
        public int ticketAmount { get; set; }
        public DateTime startDate { get; set; } = DateTime.Now;
        public DateTime endDate { get; set; } = DateTime.Now;
    }
}
