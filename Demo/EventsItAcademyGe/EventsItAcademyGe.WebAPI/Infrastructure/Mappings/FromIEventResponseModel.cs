using Mapster;
using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Mappings
{
    public static class FromIEventResponseModel
    {
        public static TypeAdapterConfig FromIEventResponseModelToEventResponseModel;

        static FromIEventResponseModel()
        {
            FromIEventResponseModelToEventResponseModel = new TypeAdapterConfig();

            FromIEventResponseModelToEventResponseModel.ForType<IEventResponseModel, EventResponseDTO>()
                .Map(dest => dest.EventID, src => src.GetEventID())
                .Map(dest => dest.ownerID, src => src.GetOwnerID())
                .Map(dest => dest.eventName, src => src.GetEventName())
                .Map(dest => dest.eventDescription, src => src.GetEventDescription())
                .Map(dest => dest.ticketAmount, src => src.GetTicketAmount())
                .Map(dest => dest.startDate, src => src.GetStartDate())
                .Map(dest => dest.endDate, src => src.GetEndDate());

        }
    }
}
