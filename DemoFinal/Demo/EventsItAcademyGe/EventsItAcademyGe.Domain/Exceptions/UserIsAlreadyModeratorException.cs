namespace EventsItAcademyGe.Domain.Exceptions
{
    public class UserIsAlreadyModeratorException : CustomException
    {
        public UserIsAlreadyModeratorException() : 
            base("User is already moderator", 400)
        {

        }
    }
}
