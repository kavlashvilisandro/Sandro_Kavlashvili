using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public static class MATH
    {
        private enum Statuses
        {
            PowMustBeaPositiveOrZero,
            Success,
            MaxReturned,
            MinReturned,
            TheyAreEqual,
        }

        /*
         This method returns -1 if power is less then zero
         */
        public static double Power(double number, int power, out string status)
        {
            if(power < 0)
            {
                status = Statuses.PowMustBeaPositiveOrZero.ToString();
                return -1;
            }
            status = Statuses.Success.ToString();
            if(power == 0)
            {
                return 1;
            }
            return number * Power(number, power - 1, out status);
        }
        public static double Min(double number1, double number2, out string status)
        {
            if(number1 == number2)
            {
                status = Statuses.TheyAreEqual.ToString();
                return number1;
            }else if(number1 > number2)
            {
                status = Statuses.MinReturned.ToString();
                return number2;
            }
            else
            {
                status = Statuses.MinReturned.ToString();
                return number1;
            }
        }

        public static double Max(double number1, double number2,out string status)
        {
            if (number1 == number2)
            {
                status = Statuses.TheyAreEqual.ToString();
                return number1;
            }
            else if (number1 > number2)
            {
                status = Statuses.MaxReturned.ToString();
                return number1;
            }
            else
            {
                status = Statuses.MaxReturned.ToString();
                return number2;
            }
        }
    }
}
