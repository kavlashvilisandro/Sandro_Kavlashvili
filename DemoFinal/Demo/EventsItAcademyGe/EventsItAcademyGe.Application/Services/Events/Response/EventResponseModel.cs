
namespace EventsItAcademyGe.Application.Services.Models
{
    public class EventResponseModel : IEventResponseModel
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int TicketAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndData { get; set; }
        public int EventStatus { get; set; }

        public DateTime GetEndDate()
        {
            return this.EndData;
        }

        public string GetEventDescription()
        {
            return this.EventDescription;
        }

        public int GetEventID()
        {
            return this.ID;
        }

        public string GetEventName()
        {
            return this.EventName;
        }

        public int GetEventStatus()
        {
            return this.EventStatus;
        }

        public int GetOwnerID()
        {
            return this.OwnerID;
        }

        public DateTime GetStartDate()
        {
            return this.StartDate;
        }

        public int GetTicketAmount()
        {
            return this.TicketAmount;
        }
    }
}
