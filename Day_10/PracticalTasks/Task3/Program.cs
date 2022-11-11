using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Console.Write("Enter hours: ");
            clock.Hour = int.Parse(Console.ReadLine());
            Console.Write("Enter minutes: ");
            clock.Minute = int.Parse(Console.ReadLine());
            Console.Write("Enter seconds: ");
            clock.Second = int.Parse(Console.ReadLine());

            clock.getCurrentTime();

            clock.AddHour();
            clock.AddMinute();
            clock.AddSecond();
           

            clock.getCurrentTime();

        }
    }
}
