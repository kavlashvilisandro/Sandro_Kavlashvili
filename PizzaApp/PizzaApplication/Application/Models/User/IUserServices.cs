using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IUserServices
    {
        public Task<int> AddUser(IUserRequestModel user);
        public Task<IUserResponseModel> GetUser(int id);
    }
}
