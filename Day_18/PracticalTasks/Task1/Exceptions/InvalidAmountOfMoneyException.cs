using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.Exceptions
{
    public class InvalidAmountOfMoneyException : Exception
    {
        public InvalidAmountOfMoneyException() : base("Invalid amount of money")
        {

        }
    }
}
