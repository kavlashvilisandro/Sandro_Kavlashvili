using System;


namespace Application.Models
{
    public interface IUserRequestModel
    {
        public string GetFirstName();
        public string GetLastName();
        public int GetPhoneNumber();
        public string GetEmail();
    }
}
