using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.User
{
    public static class UserRepository
    {
        public async static Task<int> AddUserAsync(UserModel user)
        {
            user.ID = DBContext.UserIDCounter++;
            DBContext.users.Add(user);
            return user.ID;
        }

        public async static Task<UserModel> GetUserAsync(int id)
        {
            
            if(DBContext.users.Count((x) => x.ID == id) == 1)
            {
                return DBContext.users.Single((x) => x.ID == id);
            }
            else
            {
                return null;
            }
        }
    }
}
