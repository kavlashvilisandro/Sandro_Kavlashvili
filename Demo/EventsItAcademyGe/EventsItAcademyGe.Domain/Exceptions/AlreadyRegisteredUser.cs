
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class AlreadyRegisteredUser : CustomException
    {
        public AlreadyRegisteredUser() : 
            base("User with this name is already registered", 400)
        {

        }
    }
}
