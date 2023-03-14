using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserResponseModel : IUserResponseModel
    {
        private int UserID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private int PhoneNumber { get; set; }
        public UserResponseModel(int userID, string firstName, string lastName, string email, int phoneNumber)
        {
            this.Email = email;
            this.UserID = userID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        public int GetID()
        {
            return this.UserID;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public int GetMobileNumber()
        {
            return this.PhoneNumber;
        }

        public string GetEmail()
        {
            return this.Email;
        }
    }
}
