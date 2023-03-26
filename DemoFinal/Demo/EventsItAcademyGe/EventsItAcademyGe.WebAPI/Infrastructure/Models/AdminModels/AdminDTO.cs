using EventsItAcademyGe.WebAPI.Infrastructure.Extensions;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Models
{
    public class AdminDTO
    {
        private string _password;
        public string AdminName { get; set; }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value.HashString();
            }
        }
    }
}
