namespace EventsItAcademyGe.Application.Services.Models
{
    public interface IEventRequestModel
    {
        public int GetOwnerID();
        public string GetEventName();
        public string GetEventDescription();
        public int GetTicketsAmount();
        public DateTime GetStartDate();
        public DateTime GetEndDate();
    }
}
