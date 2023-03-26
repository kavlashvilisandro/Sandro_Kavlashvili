namespace EventsItAcademyGe.MVC.Infrastructure.Models
{
    public class RegisterEventDTO
    {
        public string eventName { get; set; }
        public string eventDescription { get; set; }
        public int ticketAmount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
