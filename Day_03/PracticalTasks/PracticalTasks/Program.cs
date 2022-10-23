using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //First Task
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            if(number % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Entered number {number} is odd");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Entered number {number} is even");
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.WriteLine();
            Console.WriteLine("===");
            Console.WriteLine();


            //Second Task
            Console.Write("Enter First Number: ");
            double number1 = double.Parse(Console.ReadLine());
            Console.Write("Enter Second Number: ");
            double number2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Third Number: ");
            double number3 = double.Parse(Console.ReadLine());
            if((number1 + number2 >= number3) && (number2 + number3 >= number1) && (number1 + number3 >= number2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This should be triangle");
                Console.ForegroundColor= ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This cannot be triangle");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
            Console.WriteLine("===");
            Console.WriteLine();

            //Third Task
            Console.Write("Enter the number: ");
            double NumberForTask3 = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The pow of the entered number is {Math.Pow(NumberForTask3,2)}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("===");
            Console.WriteLine();

            //Fourth Task


            //First Solution Task 4

            //string[] Chineese12Signs = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey", "Rooster", "Dog", "Pig" };

            //Console.Write("Enter your birth year: ");
            //int EnteredYear = int.Parse(Console.ReadLine());
            //if ((EnteredYear % 12 + 8) > 12)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"Your Birth year is {Chineese12Signs[EnteredYear % 12 - 4]}");
            //    Console.ForegroundColor = ConsoleColor.White;
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"{EnteredYear} was {Chineese12Signs[EnteredYear % 12 + 8]} year");
            //    Console.ForegroundColor = ConsoleColor.White;
            //}




            //Second Solution Task 4

            Console.Write("Enter your birth year: ");
            int EnteredYear = int.Parse(Console.ReadLine());
            int YearIndex;
            if ((EnteredYear % 12 + 8) >= 12)
            {
                YearIndex = EnteredYear % 12 - 4;
            }
            else
            {
                YearIndex = EnteredYear % 12 + 8;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            switch (YearIndex)
            {
                case 0:
                    Console.WriteLine($"{EnteredYear} was Rat Year");
                    break;
                case 1:
                    Console.WriteLine($"{EnteredYear} was Ox Year");
                    break;
                case 2:
                    Console.WriteLine($"{EnteredYear} was Tiger Year");
                    break;
                case 3:
                    Console.WriteLine($"{EnteredYear} was Rabbit Year");
                    break;
                case 4:
                    Console.WriteLine($"{EnteredYear} was Dragon Year");
                    break;
                case 5:
                    Console.WriteLine($"{EnteredYear} was Snake Year");
                    break;
                case 6:
                    Console.WriteLine($"{EnteredYear} was Horse Year");
                    break;
                case 7:
                    Console.WriteLine($"{EnteredYear} was Sheep Year");
                    break;
                case 8:
                    Console.WriteLine($"{EnteredYear} was Monkey Year");
                    break;
                case 9:
                    Console.WriteLine($"{EnteredYear} was Rooster Year");
                    break;
                case 10:
                    Console.WriteLine($"{EnteredYear} was Dog Year");
                    break;
                case 11:
                    Console.WriteLine($"{EnteredYear} was Pig Year");
                    break;
                default:
                    Console.WriteLine(YearIndex);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            //=======================


            Console.WriteLine();
            Console.WriteLine("===");
            Console.WriteLine();

            //Fifth Task
            //აქ შეიძლება აცდენილი იყოს ზოდიაქოს პერიოდები. ვიკიპედიიდან ამოვწერე.
            Console.Write("Enter your day of birth: ");
            int Day = int.Parse(Console.ReadLine());
            Console.Write("Enter your month of birth: ");
            string month = Console.ReadLine();
            string result = string.Empty;
            if( (Day >= 19 && month == "April") || (Day <= 13 && month == "May") )
            {
                result = "Aries";
            }
            else if( (Day >= 14 && month == "May") || (Day <= 19 && month == "June"))
            {
                result = "Taurus";
            }
            else if ( (Day >= 20 && month == "June") || (Day <= 20 && month == "July" ))
            {
                result = "Gemini";
            }
            else if( (Day >= 21 && month == "July") || (Day <= 9 && month == "August" ))
            {
                result = "Cancer";
            }
            else if( (Day >= 10 && month == "August") || (Day <= 15 && month == "September"))
            {
                result = "Leo";
            }
            else if( (Day >= 16 && month == "September") || (Day <= 30 && month == "October"))
            {
                result = "Virgo";
            }
            else if( (Day >= 31 && month == "October") || (Day <= 22 && month == "November"))
            {
                result = "Libra";
            }
            else if( (Day >= 23  && Day <= 29 ) && month == "November" ){
                result = "Scorpius";
            }
            else if( (Day >= 30 && month == "November") || (Day <= 17 && month == "December"))
            {
                result = "aq ver gavige ra zodiaqoa";
            }
            else if ( (Day >= 18 && month == "December") || (Day <= 18 && month == "January"))
            {
                result = "Sagittarius";
            }
            else if( (Day >= 19 && month == "January") || (Day <= 15 && month == "February"))
            {
                result = "Capricornus";
            }
            else if( (Day>= 16 && month == "February") || (Day <= 11 && month == "March"))
            {
                result = "Aquarius";
            }
            else if( (Day >= 12 && month == "March") || (Day<=18 && month == "April"))
            {
                result = "Pisces";
            }
            else
            {
                result = "Not defined";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Day} {month} is {result}");
            Console.ForegroundColor = ConsoleColor.White;

            //==============================================


            Console.ReadKey();
        }
    }
}
