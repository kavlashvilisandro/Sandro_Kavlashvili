namespace EventsItAcademyGe.WebAPI.Infrastructure.Models
{
    public class EventDTO
    {
        public string eventName { get; set; } = "";
        public string eventDescription { get; set; } = "";
        public int ticketAmount { get; set; }
        public DateTime startDate { get; set; } = DateTime.Now;
        public DateTime endDate { get; set; } = DateTime.Now;
    }
}
