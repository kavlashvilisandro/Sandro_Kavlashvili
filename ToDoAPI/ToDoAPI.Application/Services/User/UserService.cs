using ToDoAPI.Application.Services.Models;
using ToDoAPI.Infrastructure.Repos;
using ToDoAPI.Persistence.Models;
using ToDoAPI.Application.Infrastructure.Mapping;
using Mapster;


namespace ToDoAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IServiceProvider _provider;
        private readonly UserRepo _userRepo;
        public UserService(IServiceProvider provider)
        {
            this._provider = provider;
            this._userRepo = new UserRepo(provider);
        }
        public async Task<int> AddUserAsync(IUserRequestModel user)
        {
            return await _userRepo.AddAsync(user.Adapt<User>(UserMapping.UserToEntity));
        }

        public async Task<bool> AuthenticateUserAsync(IUserRequestModel user)
        {
            int userID = await _userRepo.GetItemID(user.Adapt<User>(UserMapping.UserToEntity));
            if(userID == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<int> GetUserID(IUserRequestModel user)
        {
            return await _userRepo.GetItemID(user.Adapt<User>(UserMapping.UserToEntity));
        }
    }
}
