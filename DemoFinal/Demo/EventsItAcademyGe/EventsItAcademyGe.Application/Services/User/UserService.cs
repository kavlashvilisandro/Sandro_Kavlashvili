using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.Application.Mappings;
using EventsItAcademyGe.Infrastructure.Repositories;
using Mapster;
using EventsItAcademyGe.Domain.Models;
using EventsItAcademyGe.Domain.Exceptions;

namespace EventsItAcademyGe.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepo;

        public UserService(IServiceProvider provider)
        {
            this._userRepo = new UserRepository(provider);
        }



        /**This method adds user in database and returns added user's ID. 
         * if there is already added user with this username, it throws 
         * exception**/
        public async Task<int> AddUserAsync(IUserRequestModel model,CancellationToken token)
        {
            (bool, User?) Res = await _userRepo.Exists(user => user.UserName == model.GetUserName() && user.Status == (int)Statusses.Active, token);
            if (Res.Item1)
            {
                throw new AlreadyRegisteredUser();
            }
            return await _userRepo.AddAsync(model.Adapt<User>(ToUserEntity.UserRequestToUser),token);
        }



        /**
         * if user which satisfies this predicate, exists, this method returns id,
         * but if it does't exists, it throws UserNotFoundException
         * **/
        public async Task<(int UserID, bool IsModerator)> LoginUser(IUserRequestModel model, CancellationToken token)
        {
            (bool, User?) Res = await _userRepo.Exists(user => user.UserName == model.GetUserName() && user.Password == model.GetPassword() && user.Status == (int)Statusses.Active, token);
            if (!Res.Item1)
            {
                throw new UserNotFoundException();
            }
            return (Res.Item2.ID,Res.Item2.IsModerator);
        }
    }
}
