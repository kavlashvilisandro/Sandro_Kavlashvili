namespace EventsItAcademyGe.MVC.Infrastructure.Clients.Models
{
    public class EventResponseModel
    {
        public int EventID { get; set; }
        public int ownerID { get; set; }
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public int ticketAmount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
