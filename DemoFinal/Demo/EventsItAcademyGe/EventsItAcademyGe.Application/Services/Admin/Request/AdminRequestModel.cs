

namespace EventsItAcademyGe.Application.Services.Models
{
    public class AdminRequestModel : IAdminRequestModel
    {
        public string AdminName { get; set; }
        public string Password { get; set; }

        public string GetAdminName()
        {
            return this.AdminName;
        }
        public string GetPassword()
        {
            return this.Password;
        }
    }
}
