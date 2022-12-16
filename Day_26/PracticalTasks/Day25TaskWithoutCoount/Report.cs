using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Day25TaskWithoutCoount
{
    public static class Report
    {
        public static IEnumerable<Order> OrdersData;
        public static IEnumerable<Customer> CustomersData;


        //This method gets all Customers info from Customers.txt 
        public static void GetCustomerData()
        {
            CustomersData = File.ReadAllLines(Program.CustomerPath).Select((x) =>
            {
                return new Customer(x);
            });
        }


        //This method Gets All Orders info from Orders.txt
        public static void GetOrdersData()
        {
            OrdersData = File.ReadAllLines(Program.OrdersPath).Select((x) =>
            {
                return new Order(x);
            });
        }


        //Report 1
        public static void OrderAmountReports()
        {
            IEnumerable<IGrouping<int, Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(IGrouping<int,Order> group in GroupedOrders)
            {
                Console.Write($"UserID: {group.Key}| ");
                Console.Write($"OrdersAmount: {group.Count()} \n");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        //Report 2
        public static void SumAmount()
        {
            IEnumerable<IGrouping<int, Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (IGrouping<int, Order> group in GroupedOrders)
            {
                Console.Write($"UserID: {group.Key}| ");
                Console.Write($"OrdersAmount: {group.Sum((x) => x.Price)} \n");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        //Report 3
        public static void MinPirceAmount()
        {
            IEnumerable<IGrouping<int, Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (IGrouping<int, Order> group in GroupedOrders)
            {
                Console.Write($"UserID: {group.Key}| ");
                Console.Write($"OrdersAmount: {group.Min((x) => x.Price)} \n");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        //Report 4
        public static void MoreThanOne()
        {
            IEnumerable<IGrouping<int, Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (IGrouping<int, Order> group in GroupedOrders)
            {
                if(group.Count() > 1)
                {
                    Console.Write($"UserID: {group.Key}| ");
                    Console.Write($"OrdersAmount: {group.Count()} \n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        //Report 5
        public static void AvgPriceMoreThan(int ParamX)
        {
            IEnumerable<IGrouping<int, Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach(IGrouping<int,Order> group in GroupedOrders)
            {
                if(group.Average((x) => x.Price) > ParamX)
                {
                    Console.Write($"CustomerKey: {group.Key}| ");
                    Console.Write($"AvgPrice: {group.Average((x) => x.Price)} \n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}