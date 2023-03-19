namespace EventsItAcademyGe.Application.Services.Models
{
    public class EventRequestModel : IEventRequestModel
    {
        public int OwnerID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int TicketAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime GetEndDate()
        {
            return this.EndDate;
        }

        public string GetEventDescription()
        {
            return this.EventDescription;
        }

        public string GetEventName()
        {
            return this.EventName;
        }

        public int GetOwnerID()
        {
            return this.OwnerID;
        }

        public DateTime GetStartDate()
        {
            return this.StartDate;
        }

        public int GetTicketsAmount()
        {
            return this.TicketAmount;
        }
    }
}
