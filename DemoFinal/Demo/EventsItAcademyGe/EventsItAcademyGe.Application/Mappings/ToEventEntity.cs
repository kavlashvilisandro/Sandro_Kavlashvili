using Mapster;
using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.Application.Mappings
{
    public static class ToEventEntity
    {
        public static TypeAdapterConfig EventRequestModelToEventEntity;

        static ToEventEntity()
        {
            EventRequestModelToEventEntity = new TypeAdapterConfig();
            EventRequestModelToEventEntity.NewConfig<IEventRequestModel, Event>()
                .Map(dest => dest.OwnerID, src => src.GetOwnerID())
                .Map(dest => dest.EventName, src => src.GetEventName())
                .Map(dest => dest.EventDescription, src => src.GetEventDescription())
                .Map(dest => dest.TicketAmount, src => src.GetTicketsAmount())
                .Map(dest => dest.StartDate, src => src.GetStartDate())
                .Map(dest => dest.EndData, src => src.GetEndDate());

        }


    }
}
