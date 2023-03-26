
namespace EventsItAcademyGe.Application.Services.Models
{
    public class UserRequestModel : IUserRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string GetPassword()
        {
            return this.Password;
        }
        public string GetUserName()
        {
            return this.UserName;
        }
    }
}
