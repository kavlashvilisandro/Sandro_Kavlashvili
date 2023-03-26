using FluentValidation;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using EventsItAcademyGe.WebAPI.Infrastructure.Validations;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Validations
{
    public class EventDTOsValidation : AbstractValidator<List<EventDTO>>
    {
        public EventDTOsValidation()
        {
            RuleForEach(x => x).SetValidator(new EventDTOValidation());
        }
    }
}
