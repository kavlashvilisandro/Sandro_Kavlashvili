namespace EventsItAcademyGe.Domain.Models
{
    public class Status
    {
        public int ID { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<User> UsersWithThisStatusCode { get; set; }

        public List<Event> EventsWithThisStatusCode { get; set; }
    }
}
