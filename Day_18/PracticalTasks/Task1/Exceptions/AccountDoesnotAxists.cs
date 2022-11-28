using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Exceptions
{
    public class AccountDoesnotAxists : Exception
    {
        public AccountDoesnotAxists() : base("Account not found")
        {

        }
    }
}
