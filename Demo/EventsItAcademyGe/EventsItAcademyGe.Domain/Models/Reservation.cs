namespace EventsItAcademyGe.Domain.Models
{
    public class Reservation : BaseEntity
    {
        public int UserID { get; set; }
        public int EventID { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
