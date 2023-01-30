using Application.Models;

namespace PizzaApplication.WebAPI.Infrastrucutre.Models
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public UserDTO(IUserResponseModel response)
        {
            this.UserID = response.GetID();
            this.FirstName = response.GetFirstName();
            this.LastName = response.GetLastName();
            this.PhoneNumber = response.GetMobileNumber();
            this.Email = response.GetEmail();
        }
    }
}
