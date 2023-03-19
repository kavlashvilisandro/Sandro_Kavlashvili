
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class EventNotFoundException : CustomException
    {
        public EventNotFoundException() 
            : base("There is not event with this EventID",
                  400)
        {
        }

        public EventNotFoundException(string message)
            : base(message, 400)
        {

        }
    }
}
