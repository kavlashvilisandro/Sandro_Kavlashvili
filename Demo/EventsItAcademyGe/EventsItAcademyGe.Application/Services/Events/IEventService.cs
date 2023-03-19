using EventsItAcademyGe.Application.Services.Models;
using Microsoft.AspNetCore.JsonPatch;
using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.Application.Services
{
    public interface IEventService
    {
        public Task<List<int>> AddNewEvents(List<IEventRequestModel> events, CancellationToken token);
        public Task<int> AddNewEvent(IEventRequestModel Event,CancellationToken token);
        public Task<List<IEventResponseModel>> GetAllActiveEvents(CancellationToken token);

        public Task<int> ReserveTicket(int UserID,int EventID, CancellationToken token);

        public Task DeleteLateReservations(int minutes,CancellationToken token);

        public Task BuyTicket(int userID, int reservationID, CancellationToken token);

        public Task DeleteFinishedEvent(CancellationToken token);


        public Task UpdatePartialEvent(int TimeLimit, int UserID, int EventID,JsonPatchDocument<Event> updateInstructions,CancellationToken token);
    }
}
