using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.Infrastructure.Repositories;
using EventsItAcademyGe.Domain.Models;
using EventsItAcademyGe.Domain.Exceptions;

namespace EventsItAcademyGe.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly AdminRepository _adminRepo;
        private readonly UserRepository _userRepo;
        public AdminService(IServiceProvider provider)
        {
            this._adminRepo = new AdminRepository(provider);
            this._userRepo = new UserRepository(provider);
        }

        public async Task<int> LoginAdmin(IAdminRequestModel adminCredentials, CancellationToken token)
        {
            return await _adminRepo.GetAdminID((admin) => admin.AdminPassword == adminCredentials.GetPassword() &&
                                                          admin.AdminName == adminCredentials.GetAdminName()
                                                          ,token);
        }

        public async Task SetAsModerator(int UserID, CancellationToken token)
        {
            User user = await _userRepo.GetByID(UserID, token);
            if(user == null)
            {
                throw new UserNotFoundException();
            }
            if (user.IsModerator)
            {
                throw new UserIsAlreadyModeratorException();
            }
            user.IsModerator = true;
            await _userRepo.SaveChangesAsync(token);
        }
    }
}
