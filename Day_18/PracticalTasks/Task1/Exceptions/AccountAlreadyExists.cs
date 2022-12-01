using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Exceptions
{
    public class AccountAlreadyExists : Exception
    {
        public AccountAlreadyExists() : base("Account Already Exists")
        {

        }
    }
}
