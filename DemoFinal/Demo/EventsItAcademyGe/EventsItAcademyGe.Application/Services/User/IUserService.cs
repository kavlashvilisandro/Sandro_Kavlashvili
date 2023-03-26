using EventsItAcademyGe.Application.Services.Models;

namespace EventsItAcademyGe.Application.Services
{
    public interface IUserService
    {
        public Task<int> AddUserAsync(IUserRequestModel model,CancellationToken token);
        public Task<(int UserID, bool IsModerator)> LoginUser(IUserRequestModel model,CancellationToken token);
    }
}
