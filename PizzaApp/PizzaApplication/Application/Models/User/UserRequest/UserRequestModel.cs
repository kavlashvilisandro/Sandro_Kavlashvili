using System;


namespace Application.Models
{
    public class UserRequestModel : IUserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
       
        public string GetFirstName()
        {
            return this.FirstName;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public int GetPhoneNumber()
        {
            return this.PhoneNumber;
        }

        public string GetEmail()
        {
            return this.Email;
        }
    }
}
