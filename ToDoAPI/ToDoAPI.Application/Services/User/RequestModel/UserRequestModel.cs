using System;


namespace ToDoAPI.Application.Services.Models
{
    public class UserRequestModel : IUserRequestModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int GetID()
        {
            return this.UserID;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public string GetUserName()
        {
            return this.UserName;
        }
    }
}
