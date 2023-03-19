using Mapster;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using EventsItAcademyGe.Application.Services.Models;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Mappings
{
    public static class ToEventRequestModel
    {
        public static TypeAdapterConfig EventDTOWithOwnerIDToEventRequestModel;
        static ToEventRequestModel()
        {
            EventDTOWithOwnerIDToEventRequestModel = new TypeAdapterConfig();

            EventDTOWithOwnerIDToEventRequestModel.NewConfig<EventDTOWithOwnerID, EventRequestModel>()
                .Map(dest => dest.OwnerID, src => src.ownerID)
                .Map(dest => dest.EventName, src => src.eventName)
                .Map(dest => dest.EventDescription, src => src.eventDescription)
                .Map(dest => dest.TicketAmount, src => src.ticketAmount)
                .Map(dest => dest.EndDate, src => src.endDate)
                .Map(dest => dest.StartDate, src => src.startDate);

        }

        public static List<IEventRequestModel> GetEventRequestModels(this List<EventDTOWithOwnerID> Events)
        {
            List<IEventRequestModel> Res = new List<IEventRequestModel>();
            for(int i = 0; i < Events.Count; i++)
            {
                Res.Add(Events[i].Adapt<EventRequestModel>(EventDTOWithOwnerIDToEventRequestModel));
            }
            return Res;
        }
    }
}
