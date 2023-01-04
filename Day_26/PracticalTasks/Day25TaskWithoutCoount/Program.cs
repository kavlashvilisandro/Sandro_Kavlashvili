using System;

namespace Day25TaskWithoutCoount
{
    public class Program
    {
        public static string OrdersPath = @"D:\Repo\Day_26\PracticalTasks\Day25TaskWithoutCoount\Orders.txt";
        public static string CustomerPath = @"D:\Repo\Day_26\PracticalTasks\Day25TaskWithoutCoount\Customers.txt";
        static void Main(string[] args)
        {
            //Get Data
            Report.GetCustomerData();
            Report.GetOrdersData();

            Report.AvgPriceMoreThan(10);
            Console.WriteLine("============");
            Report.SumAmount();
            Console.WriteLine("============");
            Report.OrderAmountReports();
            Console.WriteLine("============");
            Report.MinPirceAmount();
            Console.WriteLine("============");
            Report.MoreThanOne();
            Console.WriteLine("============");

        }


    }
}