namespace EventsItAcademyGe.Domain.Models
{
    public enum Statusses
    {
        Active = 1,
        Deleted = 2,
    }
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)Statusses.Active;
    }
}
