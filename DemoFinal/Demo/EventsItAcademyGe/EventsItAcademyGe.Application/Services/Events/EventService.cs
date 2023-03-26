using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.Application.Mappings;
using EventsItAcademyGe.Infrastructure.Repositories;
using Mapster;
using EventsItAcademyGe.Domain.Models;
using EventsItAcademyGe.Domain.Attributes;
using EventsItAcademyGe.Domain.Exceptions;
using EventsItAcademyGe.Domain.Validations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using System.Reflection;
using FluentValidation;
using FluentValidation.Results;
using System.Text.Json;

namespace EventsItAcademyGe.Application.Services
{
    public class EventService : IEventService
    {
        private readonly EventsRepository _eventRepo;
        private readonly ReservationRepository _reservationRepo;
        public EventService(IServiceProvider provider)
        {
            this._eventRepo = new EventsRepository(provider);
            this._reservationRepo = new ReservationRepository(provider);
        }
        public async Task<List<int>> AddNewEvents(List<IEventRequestModel> events,CancellationToken token)
        {
            List<int> res = await _eventRepo.AddRangeAsync(events.Adapt<List<Event>>(ToEventEntity.EventRequestModelToEventEntity), token);
            return res;
        }

        public async Task<int> AddNewEvent(IEventRequestModel Event,CancellationToken token)
        {
            return await _eventRepo.AddAsync(Event.Adapt<Event>(ToEventEntity.EventRequestModelToEventEntity), token);
        }

        public async Task<List<IEventResponseModel>> GetAllActiveEvents(CancellationToken token)
        {
            IEnumerable<IEventResponseModel> events = (await _eventRepo.SelectAsync(x => x.EventStatus == (int)EventStatusses.Active && x.Status == (int)Statusses.Active, token))
                .Select((Event x) => x.Adapt<EventResponseModel>());
            return events.ToList();
        }
        public async Task<List<IEventResponseModel>> GetAllPendingEvents(CancellationToken token)
        {
            IEnumerable<IEventResponseModel> events = (await _eventRepo.SelectAsync(x => x.EventStatus == (int)EventStatusses.Pending && x.Status == (int)Statusses.Active, token))
                .Select((Event x) => x.Adapt<EventResponseModel>());
            return events.ToList();
        }
        public async Task<int> ReserveTicket(int UserID, int EventID,CancellationToken token)
        {
            (bool exists, Event? entity) = await _eventRepo.Exists(e => e.ID == EventID && 
                                                                        e.EventStatus == (int)EventStatusses.Active && 
                                                                        e.Status == (int)Statusses.Active
                                                                        ,token);
            if (exists)
            {
                if(entity.TicketAmount <= 0)
                {
                    throw new NotEnoughTicket();
                }
                await _eventRepo.UpdateAsync(EventID,(Event e) =>
                {
                    e.TicketAmount = entity.TicketAmount - 1;
                }, token);

                return await _reservationRepo.AddAsync(r =>
                {
                    r.UserID = UserID;
                    r.EventID = EventID;
                }, token);
            }
            throw new EventNotFoundException();
        }

        public async Task DeleteLateReservations(int minutes,CancellationToken token)
        {
            List<Reservation> Reservations = await _reservationRepo.SelectAsync(r => r.Status == (int)Statusses.Active, token);
            for(int i = 0; i < Reservations.Count; i++)
            {
                if(Reservations[i].CreationDate.AddMinutes(minutes) < DateTime.Now)
                {
                    await _reservationRepo.SoftDeleteAsync(Reservations[i].ID, token);
                    Event? @event = await _eventRepo.GetByID(Reservations[i].EventID,token);
                    if(@event != null)
                    {
                        @event.TicketAmount++;
                        await _eventRepo.SaveChangesAsync(token);
                    }
                }
            }
        }
    
        public async Task BuyTicket(int userID,int EventID, CancellationToken token)
        {
            Reservation? reservation = (await _reservationRepo.SelectAsync(x => x.EventID == EventID &&
                                                                               x.UserID == userID &&
                                                                               x.Status == (int)Statusses.Active
                                                                               , token)).FirstOrDefault();

            //if there is not event with this id, we will throw EventNotFound exception
            if (reservation == null)//it means that there was not reservation,
                                   //because first or default returns null when there is
                                   //not element in the collection and customer wants to buy ticket without reservation
            {
                Event @event = await _eventRepo.GetByID(EventID, token);
                if (@event != null)//if @event != null, that means that there was event with this id
                {
                    if (@event.TicketAmount > 0)
                    {
                        @event.TicketAmount--;
                        await _eventRepo.SaveChangesAsync(token);
                    }
                    else
                    {
                        throw new NotEnoughTicket();
                    }
                }
                else
                {
                    throw new EventNotFoundException();
                }
            }
            else//if reservation != null, that means that customer has reservation on this event and wants to buy
            //ticket with this reservation
            {
                await _reservationRepo.SoftDeleteAsync(reservation.ID, token);
            }
        }
    
        public async Task DeleteFinishedEvent(CancellationToken token)
        {
            await _eventRepo.UpdateWhere((Event e) =>
            {
                e.EventStatus = (int)EventStatusses.Finished;
                e.ModifiedDate = DateTime.Now;
                e.Status = (int)Statusses.Deleted;
            }, (Event e) => e.EventStatus == (int)EventStatusses.Active &&
                            e.Status == (int)Statusses.Active &&
                            e.EndData < DateTime.Now.Date
            , token);

        }

        public async Task UpdatePartialEvent(int TimeLimitInDays,int UserID, int EventID, JsonPatchDocument<Event> updateInstructions, CancellationToken token)
        {
            Event Event = await _eventRepo.GetByID(EventID, token);
            if(Event == null) throw new EventNotFoundException();
            
            if(Event.Status == (int)Statusses.Deleted || Event.EventStatus != (int)EventStatusses.Active)
            {
                throw new EventNotFoundException();
            }
            
            if(Event.OwnerID != UserID) throw new NotAuthorizedEvent();
            
            if (Event.CreationDate.AddDays(TimeLimitInDays) < DateTime.Now) throw new UpdateTimeExpiredException();
            
            try
            {
                updateInstructions.ApplyTo(Event);//if this will be passed, that means 
                //that all of the property names are mapped to the object
                Type EventType = typeof(Event);
                Type UpdateAllower = typeof(PatchUpdateAllowedAttribute);
                //updateInstructions.Operations is type of: List<Operation<Event>>
                for(int i = 0; i < updateInstructions.Operations.Count; i++)
                {
                    //if property does't have allower attribute, that means that update of this
                    //property is't allowed, and we will throw exception
                    if(!Attribute.IsDefined(EventType.GetProperty(updateInstructions.Operations[i].path), UpdateAllower))
                    {
                        _eventRepo.Detach(Event);//Detaching Event
                        throw new UnAuthorizedUpdateException(updateInstructions.Operations[i].path);
                    }
                }
                IValidator<Event> Validator = new EventValidation();
                ValidationResult res = Validator.Validate(Event);
                if (!res.IsValid)
                {
                    _eventRepo.Detach(Event);//Detaching Event
                    throw new DataValidationException(JsonSerializer.Serialize(res.Errors));
                }

            }
            catch(JsonPatchException ex)
            {
                /*
                 if incorrect value types will be mapped, there will be this type of error,
                 also if there will be incorrect operation or incorrect data name requested
                 */
                throw new IncorrectPatchRequestException(ex.Message);
            }
            await _eventRepo.SaveChangesAsync(token);


        }
    
        public async Task ActivatePendingEvent(int EventID, CancellationToken token)
        {
            (bool exists, Event? Event) = await _eventRepo.Exists((Event) => Event.EventStatus == (int)EventStatusses.Pending &&
                                                             Event.Status == (int)Statusses.Active &&
                                                             Event.ID == EventID, token);

            if (exists)
            {
                this._eventRepo.Attach(Event);
                Event.EventStatus = (int)EventStatusses.Active;
                await this._eventRepo.SaveChangesAsync(token);
            }
            else
            {
                throw new EventNotFoundException();
            }
        }

        public async Task<IEventResponseModel> GetEventByID(int EventID, CancellationToken token)
        {
            Event @event = await _eventRepo.GetByID(EventID, token);
            if(@event == null)
            {
                throw new EventNotFoundException();
            }
            else
            {
                _eventRepo.Detach(@event);
                if(@event.EventStatus == (int)EventStatusses.Active 
                    && @event.Status == (int)Statusses.Active)
                {
                    return @event.Adapt<EventResponseModel>();
                }
                else
                {
                    throw new EventNotFoundException();
                }
            }
        }
    }
}
