using EventsItAcademyGe.WebAPI.Infrastructure.Extensions;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Models
{
    public class UserLoginRegistrationDTO
    {
        public string userName { get; set; } = "";
        public string password { get; set; } = "";

        public void HashObject()
        {
            this.password = password.HashString();
        }
    }
}
