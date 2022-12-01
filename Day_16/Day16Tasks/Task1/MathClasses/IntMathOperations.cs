using System;
using System.Collections.Generic;
using System.Text;
using Task1;

namespace Task1.MathClasses
{
    public class IntMathOperations : IMathOperation_<int>
    {
        public int Plus(int data1, int data2)
        {
            return data1 + data2;
        }

        public int Minus(int data1, int data2)
        {
            return data1 - data2;
        }

        public int Multiply(int data1, int data2)
        {
            return data1 * data2;
        }
    }
}
