using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int CustomerID { get; set; }

        public Order(string Data)
        {
            string[] ParamData = Data.Split('|');
            OrderID = int.Parse(ParamData[0]);
            OrderDate = ParamData[1];
            Product = ParamData[2];
            Price = decimal.Parse(ParamData[3]);
            CustomerID = int.Parse(ParamData[4]);
        }
        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                return ((Order)obj).OrderID == this.OrderID;
            }
            else
            {
                return false;
            }
        }
    }
}
