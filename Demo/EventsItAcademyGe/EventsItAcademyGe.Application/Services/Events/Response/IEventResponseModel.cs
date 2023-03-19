namespace EventsItAcademyGe.Application.Services.Models
{
    public interface IEventResponseModel
    {
        public int GetOwnerID();
        public string GetEventName();
        public int GetEventStatus();
        public int GetTicketAmount();
        public string GetEventDescription();
        public DateTime GetEndDate();
        public DateTime GetStartDate();
        public int GetEventID();
    }
}
