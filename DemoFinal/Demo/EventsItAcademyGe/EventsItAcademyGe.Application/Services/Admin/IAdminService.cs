using EventsItAcademyGe.Application.Services.Models;

namespace EventsItAcademyGe.Application.Services
{
    public interface IAdminService
    {
        public Task<int> LoginAdmin(IAdminRequestModel adminCredentials,CancellationToken token);
        public Task SetAsModerator(int UserID, CancellationToken token);
    }
}
