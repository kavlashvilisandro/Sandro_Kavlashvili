using EventsItAcademyGe.Domain.Attributes;

namespace EventsItAcademyGe.Domain.Models
{
    public enum EventStatusses
    {
        Pending = 1,//Waiting for accept from adming
        Active = 2,
        Finished = 3
    }
    public class Event : BaseEntity
    {
        public int OwnerID { get; set; }

        [PatchUpdateAllowed]
        public string EventName { get; set; }

        [PatchUpdateAllowed]
        public string EventDescription { get; set; }
        
        [PatchUpdateAllowed]
        public int TicketAmount { get; set; }

        [PatchUpdateAllowed]
        public DateTime StartDate { get; set; }

        [PatchUpdateAllowed]
        public DateTime EndData { get; set; }

        public int EventStatus { get; set; } = (int)EventStatusses.Pending;
    }
}
