using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public static class Report
    {
        public static IEnumerable<Order> OrdersData;
        public static IEnumerable<Customer> CustomersData;


        //This method gets all Customers info from Customers.txt 
        public static void GetCustomerData()
        {
            CustomersData =  File.ReadAllLines(Program.CustomerPath).Select((x) =>
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
            IEnumerable<IGrouping<int,Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.Green;
            for(int i = 0;i < GroupedOrders.Count(); i++)
            {
                Console.Write($"UserID: {GroupedOrders.ElementAt(i).Key}| ");
                Console.Write($"OrdersAmount: {GroupedOrders.ElementAt(i).Count()} \n");
            }
            Console.ForegroundColor= ConsoleColor.Gray;
        }


        //Report 2
        public static void SumAmount()
        {
            IEnumerable<IGrouping<int, Order>> GroupedOrders = OrdersData.GroupBy((x) =>
            {
                return x.CustomerID;
            });
            Console.ForegroundColor = ConsoleColor.Yellow;
            for(int i = 0; i < GroupedOrders.Count(); i++)
            {
                
                Console.Write($"CustomerID: {GroupedOrders.ElementAt(i).Key}| ");
                Console.Write($"PriceSum: {GroupedOrders.ElementAt(i).Sum((x) => x.Price)} \n");
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
            for (int i = 0; i < GroupedOrders.Count(); i++)
            {
                Console.Write($"CustomerID: {GroupedOrders.ElementAt(i).Key}| ");
Console.Write($"MinPrice: {GroupedOrders.ElementAt(i).Min((x) => x.Price )} \n");
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
            for(int i = 0; i < GroupedOrders.Count(); i++)
            {
                if(GroupedOrders.ElementAt(i).Count() > 1)
                {
                    Console.Write($"Customer key: {GroupedOrders.ElementAt(i).Key}| ");
                    Console.Write($"Order Count: {GroupedOrders.ElementAt(i).Count()} \n");
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
            for(int i = 0; i < GroupedOrders.Count(); i++)
            {
                if(GroupedOrders.ElementAt(i).Average((x) => x.Price) > ParamX)
                {
                    Console.Write($"CustomerKey: {GroupedOrders.ElementAt(i).Key}| ");
                    Console.Write($"AvgPrice: {GroupedOrders.ElementAt(i).Average((x) => x.Price)} \n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
