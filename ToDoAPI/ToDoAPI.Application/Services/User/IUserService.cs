using System;
using ToDoAPI.Application.Services.Models;

namespace ToDoAPI.Application.Services
{
    public interface IUserService
    {
        public Task<int> AddUserAsync(IUserRequestModel user);

        public Task<bool> AuthenticateUserAsync(IUserRequestModel user);

        public Task<int> GetUserID(IUserRequestModel user);
    }
}
