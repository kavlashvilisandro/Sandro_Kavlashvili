using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string status = string.Empty;
            double number;
            int power;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TASK1 | to navigate to the next task, write \"yes\" is last input");
            Console.ForegroundColor= ConsoleColor.White;
            while (true)
            {
                Console.Write("Enter number: ");
                number = double.Parse(Console.ReadLine());
                Console.Write("Enter Power: ");
                power= int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{number} to the power of {power} is: {MATH.Power(number,power,out status)}");
                Console.WriteLine($"Status: {status}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("continue with next task(yes|no): ");
                if(Console.ReadLine() == "yes")
                {
                    break;
                }
            }



            Console.WriteLine();
            Console.WriteLine();



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TASK2 | to navigate to the next task, write \"yes\" is last input");
            Console.ForegroundColor = ConsoleColor.White;
            double number1,number2;
            while (true)
            {
                Console.Write("Enter number1: ");
                number1 = double.Parse(Console.ReadLine());
                Console.Write("Enter number2: ");
                number2 = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Smaller is {MATH.Min(number1,number2,out status)}");
                Console.WriteLine("Status: " + status);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("continue with next task(yes|no): ");
                if (Console.ReadLine() == "yes")
                {
                    break;
                }
            }



            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TASK3 | to navigate to the next task, write \"yes\" is last input");
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.Write("Enter number1: ");
                number1 = double.Parse(Console.ReadLine());
                Console.Write("Enter number2: ");
                number2 = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Bigger is {MATH.Max(number1, number2, out status)}");
                Console.WriteLine("Status: " + status);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("continue with next task(yes|no): ");
                if (Console.ReadLine() == "yes")
                {
                    break;
                }
            }
        }
    }
}
