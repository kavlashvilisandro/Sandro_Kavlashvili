using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace TestConsoleApplication
{
    /*
     სულ ბოლო ლექციის გარჩევა სამწუხაროდ კარგად ვერ მოვახერხე და აქედან
    გამომდინარე მოცემულ დავალებაში ბევრი რამ ჩემი იმპროვიზაციით მიწერია და 
    არა იმ best practice-ებით რაც გავარჩიეთ, ამიტომ უკაცრავად :)).
     */
    public class ElectricCar
    {
        public int BatteryLevel = 0;
        public string Model { get; set; }
        public int Year { get; set; }
        public ElectricCar(string model, int year)
        {
            this.Model = model;
            this.Year = year;
        }
        public void Charge()
        {
            while (BatteryLevel != 100)
            {
                BatteryLevel += 5;
                Thread.Sleep(10000);
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            List<ElectricCar> list = new List<ElectricCar>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new ElectricCar($"model{i}", 2000 + i));
            }
            IEnumerable<ElectricCar> collection = list.AsEnumerable();
            Thread thread = null;
            ThreadStart threadStartDelegate;
            DateTime time1 = DateTime.Now;
            Console.WriteLine("Start time: " + time1);
            foreach (ElectricCar car in collection)
            {
                threadStartDelegate = new ThreadStart(car.Charge);
                thread = new Thread(threadStartDelegate);
                thread.Start();
            }
            thread.Join();
            DateTime time2 = DateTime.Now;
            Console.WriteLine("End time: " + time2);
            Console.WriteLine("End time: " + (time1 - time2));
        }
    }
}