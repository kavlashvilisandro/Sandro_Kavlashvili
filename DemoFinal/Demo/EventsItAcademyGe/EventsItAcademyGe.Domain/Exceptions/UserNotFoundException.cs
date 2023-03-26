
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class UserNotFoundException : CustomException
    {
        public UserNotFoundException() :
            base("User not found", 400)
        {

        }

    }
}
