using EventsItAcademyGe.Domain.Models;
using FluentValidation;

namespace EventsItAcademyGe.Domain.Validations
{
    public class EventValidation : AbstractValidator<Event>
    {
        public EventValidation()
        {
            RuleFor((Event Event) => Event.EventDescription)
                .NotEmpty()
                .WithMessage("eventDescription cannot be empty")
                .MaximumLength(300)
                .WithMessage("eventDescription's max length is 300");

            RuleFor(e => e.EventName)
                .NotEmpty()
                .WithMessage("eventName cannot be empty")
                .MaximumLength(30)
                .WithMessage("eventName's max length is 30");

            RuleFor(e => e.TicketAmount)
                .Must((int amount) => amount > 0)
                .WithMessage("Ticket amount must be more than 0");

            RuleFor(e => e.StartDate)
                .Must((DateTime date) => date.Date > DateTime.Now.Date);

            RuleFor(e => e)
                .Must(e => e.StartDate.Date <= e.EndData.Date);

        }
    }
}
