using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(11));
        }

        public static int Sum(int lastNumber, int sum = 0)
        {
            if(lastNumber == 1)
            {
                return 1;
            }
            return lastNumber + Sum(lastNumber - 1);
        }
    }
}
