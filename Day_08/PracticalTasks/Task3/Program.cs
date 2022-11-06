using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrintNumberLength(1000));
        }

        /*
         this method calls NumberLength method in correct way
         */
        public static int PrintNumberLength(int number)
        {
            return NumberLength(number);
        }
        public static int NumberLength(int number, int Power = 1)
        {
            if (Math.Pow(10, Power) > number)
            {
                return Power;
            }
            else
            {
                return NumberLength(number, Power + 1);
            }
        }
    }
}
