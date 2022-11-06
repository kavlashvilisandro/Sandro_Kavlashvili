using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1
            PrintFrom0ToN(135);
        }

        public static void PrintFrom0ToN(int number)
        {
            if(number == 1)
            {
                Console.Write(1 + " ");
                return;
            }
            PrintFrom0ToN(number - 1);
            Console.Write(number + " ");

        }

    }
}
