using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //First Task (solution with third variable)

            int a1 = 5;
            int a2 = 7;
            Console.WriteLine(a1);
            Console.WriteLine(a2);
            int temp = a1;
            a1 = a2;
            a2 = temp;
            Console.WriteLine(a1);
            Console.WriteLine(a2);

            //======================

            Console.WriteLine("=========");

            //Solution without third variable

            int b1 = 5;
            int b2 = 7;
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            b1 = b1 + b2;
            b2 = b1 - b2;
            b1 = b1 - b2;
            Console.WriteLine(b1);
            Console.WriteLine(b2);

            //======================

            Console.WriteLine("=========");

            //Second Task
            int year = 2020;
            bool isLeapYear = year % 4 == 0;
            Console.WriteLine(isLeapYear);

            //======================

            Console.WriteLine("=========");

            //Theoritical 2:

            //h >= 180 & hc == 'b' უნდა ჩანვწეროთ ლოგიკური 'არა' და 'ან' ოპერატორებით
            int h = 180;
            char hc = 'b';
            bool ConditionA = h >= 180;
            bool ConditionB = hc == 'b';
            bool isOk = !(!ConditionA | !ConditionB);//ეს იგივეა, რაც ConditionA & ConditionB
            Console.WriteLine($"{isOk} <= ConditionA = {ConditionA} , ConditionB = {ConditionB}");

            //======================

            Console.WriteLine("=========");

            //Theoritical 3:
            /*
             ამ ამოცანის მიხედვით ისეთ ოპერატორს ვწერთ, რომელიც მცდარია მხოლოდ მაშინ, როცა
             ConditionA და ConditionB ორივე ჭეშმარიტია.
             მხოლოდ or და not ოპერატორებით.
            ანუ:
            A   B    Result = !(A & B) = !(!(!A | !B)) = !!(!A | !B) = (!A | !B)
            1   0      1
            0   1      1
            0   0      1
            1   1      0
             */
            bool Theoritical3 = !ConditionA | !ConditionB;
            Console.WriteLine($"{Theoritical3} <= ConditionA = {ConditionA} , ConditionB = {ConditionB}");
            //========================

            Console.WriteLine("=========");

            //Theoritical 1:
            //negative xor:
            bool A = true;
            bool B = true;
            Console.WriteLine($"Negative Xor: {A ^ B}");
            //=======================



            Console.ReadKey();
        }
    }
}
