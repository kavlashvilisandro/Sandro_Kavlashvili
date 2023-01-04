using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static string OrdersPath = @"D:\Repo\Day_25\ConsoleApp1\ConsoleApp1\Orders.txt";
        public static string CustomerPath = @"D:\Repo\Day_25\ConsoleApp1\ConsoleApp1\Customers.txt";
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
