namespace EventsItAcademyGe.Domain.Exceptions
{
    public class UpdateTimeExpiredException : CustomException
    {
        public UpdateTimeExpiredException()
            :base("Event update time has been expired", 400)
        {

        }
    }
}
