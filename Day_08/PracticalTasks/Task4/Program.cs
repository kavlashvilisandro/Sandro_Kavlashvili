using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MathPow(2,10));
        }



        //This method calls Pow method in correct way
        public static int MathPow(int number, int Pow)
        {
            return Power(number, Pow);
        }

        public static int Power(int number, int Pow, int result = 1, int tempPower = 0)
        {
            if(Pow == 0)
            {
                return 1;
            }
            if(tempPower == Pow)
            {
                return result;
            }
            else
            {
                return Power(number, Pow, result * number, tempPower + 1);
            }
        }
    }
}
