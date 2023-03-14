using System;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Infrastructure.Repos
{
    public class UserRepo : BaseRepo<User>
    {
        public UserRepo(IServiceProvider provider) : base(provider)
        {

        }


        //აბრუნებს ID-ს, თუ გვაქვს ასეთი user
        //აბრუნებს 0-ს თუ არ გვაქვს ასეთი user
        //ისვრის exception-ს, თუ ერთზე მეტი ასეთი user გვაქვს
        public async Task<int> GetItemID(User item)
        {
            List<User> data = _dbSet.Where((User x) => x.UserName == item.UserName &&
            x.PasswordHash == item.PasswordHash).ToList();
            if (data.Count == 1)
            {
                return data[0].ID;
            }
            else if (data.Count > 1)
            {
                throw new Exception("there are more than 1 item  like this in the database");
            }
            else
            {
                return 0;
            }
        }


    }
}
