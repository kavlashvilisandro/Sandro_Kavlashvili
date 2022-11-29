using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class CountryMustHaveSingleCapital : Exception
    {
        public CountryMustHaveSingleCapital() : base("CountryMustHaveSingleCapital")
        {

        }
    }
}
