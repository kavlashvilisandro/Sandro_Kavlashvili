namespace EventsItAcademyGe.Domain.Models
{
    public class EventStatus
    {
        public int ID { get; set; }
        public int EventStatusCode { get; set; }
        public string EventStatusDescription { get; set; }

        public List<Event> ReleatedEvents { get; set; }

    }
}
