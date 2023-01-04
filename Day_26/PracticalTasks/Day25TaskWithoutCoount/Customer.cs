using System;
using System.Collections.Generic;
using System.Text;

namespace Day25TaskWithoutCoount
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerID { get; set; }

        public Customer(string Data)
        {
            this.CustomerID = Convert.ToInt32(Data.Split('|')[0]);
            this.Name = Data.Split('|')[1];
        }
        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                return ((Customer)obj).CustomerID == this.CustomerID;
            }
            else
            {
                return false;
            }
        }
    }
}