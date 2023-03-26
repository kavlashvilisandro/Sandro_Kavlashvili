using FluentValidation;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Validations
{
    public class EventDTOValidation : AbstractValidator<EventDTO>
    {
        public EventDTOValidation()
        {
            RuleFor((EventDTO Event) => Event.eventDescription)
                .NotEmpty()
                .WithMessage("eventDescription cannot be empty")
                .MaximumLength(300)
                .WithMessage("eventDescription's max length is 300");

            RuleFor(e => e.eventName)
                .NotEmpty()
                .WithMessage("eventName cannot be empty")
                .MaximumLength(30)
                .WithMessage("eventName's max length is 30");

            RuleFor(e => e.ticketAmount)
                .Must((int amount) => amount > 0)
                .WithMessage("Ticket amount must be more than 0");

            RuleFor(e => e.startDate)
                .Must((DateTime date) => date.Date > DateTime.Now.Date);

            RuleFor(e => e)
                .Must(e => e.startDate.Date <= e.endDate.Date);
        }
    }
}
