using System;


namespace ToDoAPI.Application.Services.Models
{
    public interface IUserRequestModel
    {
        public int GetID();
        public string GetUserName();
        public string GetPassword();
    }
}
