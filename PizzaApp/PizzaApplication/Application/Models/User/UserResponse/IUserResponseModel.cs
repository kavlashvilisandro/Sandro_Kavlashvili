using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IUserResponseModel
    {
        public int GetID();
        public string GetFirstName();
        public string GetLastName();
        public int GetMobileNumber();
        public string GetEmail();
    }
}
