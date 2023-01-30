using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.User;
using Repository.Models;

namespace Application.Models
{
    public class UserServices : IUserServices
    {
        public async Task<int> AddUser(IUserRequestModel user)
        {
            return await UserRepository.AddUserAsync(new UserModel()
            {
                FirstName = user.GetFirstName(),
                LastName = user.GetLastName(),
                Email = user.GetEmail(),
                PhoneNumber = user.GetPhoneNumber(),
            });
        }
        public async Task<IUserResponseModel> GetUser(int id)
        {
            Task<UserModel> res = UserRepository.GetUserAsync(id);
            UserModel ans = await res;
            if(ans == null)
            {
                return null;
            }
            return new UserResponseModel(ans.ID, ans.FirstName, ans.LastName, ans.Email, ans.PhoneNumber);
        }
        
    }
}
