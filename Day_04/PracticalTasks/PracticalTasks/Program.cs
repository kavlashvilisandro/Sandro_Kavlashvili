using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Sum = 0;


            //Task 1
            for (int i = 1; i <= 10; i++)
            {
                Sum = Sum + i;
            }
            Console.WriteLine($"Sum from 1 to 10 is {Sum}");// 1-დან 10-ის ჩათვლით
            Sum = 0;
            //===========

            Console.WriteLine();

            //Task 2
            Console.Write("Enter number to print sum from 1 to this number: ");
            int NumberForTask2 = int.Parse(Console.ReadLine());
            for(int i = 1; i <= NumberForTask2; i++)
            {
                Sum = Sum + i;
            }
            Console.WriteLine($"Sum from 0 to {NumberForTask2} is {Sum}");
            Sum = 0;
            //===========

            Console.WriteLine();


            //Task 3
            Console.Write("Enter number to print all cubes from 1 to this number: ");
            int numberForTask3 = int.Parse(Console.ReadLine());
            for(int i = 1; i<= numberForTask3; i++)
            {
                Console.WriteLine($"{i} cubed is {i*i*i}");
            }
            //=============

            Console.WriteLine();

            //Task 4
            Console.Write("Enter number to print sum of odd number from 1 to this number: ");
            int numberForTask4 = int.Parse(Console.ReadLine());
            for(int i = 1; i <= numberForTask4; i++)
            {
                if(i % 2 == 0)
                {
                    continue;
                }
                Sum = Sum + i;
            }
            Console.WriteLine($"sum of odd numbers from 1 to {numberForTask4} is {Sum}");
            Sum = 0;
            //==============

            Console.WriteLine();

            //Task 5
            Console.Write("rows of floid triangle: ");
            bool Starter = true;//if Starter is False, row starts with 0, if starter is true, raw starts with 1
            int numberForTask5 = int.Parse(Console.ReadLine());
            string onesAndZeros = string.Empty;
            for (int i = 1; i <= numberForTask5; i++)
            {
                if(Starter == true)
                {
                    for(int j = 1; j <= i; j++)
                    {
                        onesAndZeros = onesAndZeros + j % 2 + " ";
                    }
                    Console.WriteLine(onesAndZeros);
                    onesAndZeros = String.Empty;
                    Starter = !Starter;
                    continue;
                }
                for (int j = 0; j < i; j++)
                {
                    onesAndZeros = onesAndZeros + j % 2 + " ";
                }
                Console.WriteLine(onesAndZeros);
                Starter = !Starter;
                onesAndZeros = String.Empty;
            }
            //============

            Console.WriteLine();

            //Task 6
            Console.Write("Enter number and prints devisors of this number: ");
            int numberForTask6 = int.Parse(Console.ReadLine());
            string devisions = string.Empty;
            for(int i = 1; i <= numberForTask6/2; i++)
            {
                if(numberForTask6 % i == 0)
                {
                    devisions = devisions + i + ", ";
                }
            }
            devisions = devisions + numberForTask6;
            Console.WriteLine(devisions);
            //=============

            Console.WriteLine();

            //Task 7 Fibonaci
            Console.Write("Fibonaci index: ");
            int FibonaciIndex = int.Parse(Console.ReadLine());
            int m_1 = 0;
            int m = 1;
            string Sequence = "0, 1, ";
            int FibonaciSum;
            for(int i = 0; i< FibonaciIndex - 1; i++)
            {
                FibonaciSum = m_1 + m;
                Sequence = Sequence + FibonaciSum + ", ";
                m_1 = m;
                m = FibonaciSum;
            }
            Console.WriteLine(Sequence);
            //===============

            Console.WriteLine();

            //Task 8
            Console.Write("Positive whole number is binary: ");
            int number = int.Parse(Console.ReadLine());
            string numberInBinary = string.Empty;
            if(number == 0)
            {
                numberInBinary = "0";
            }
            else
            {
                for (int i = number; i > 0; i = i / 2)
                {
                    numberInBinary = i % 2 + numberInBinary;
                }
            }
            Console.WriteLine(numberInBinary);
            //====================
        }
    }
}
