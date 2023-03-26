namespace EventsItAcademyGe.Domain.Exceptions
{
    public class NotAuthorizedEvent : CustomException
    {
        public NotAuthorizedEvent()
            : base("Not Authorized Event", 401)
        {

        }
    }
}
