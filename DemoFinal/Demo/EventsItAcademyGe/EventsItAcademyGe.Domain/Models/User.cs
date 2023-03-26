namespace EventsItAcademyGe.Domain.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsModerator { get; set; } = false;

        public List<Event> ReleatedEvents { get; set; }
    }
}
