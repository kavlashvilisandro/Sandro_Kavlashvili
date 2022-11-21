using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public static class MATH
    {
        public static double CosTheorem(double side1, double side2, double side3)
        {
            double cos = (-side3 * side3 + side1 * side1 + side2 * side2) / (2 * side1 * side2);
            return cos;
        }
        public static double SinFromCos(double cos)
        {
            return Math.Sqrt(1 - cos * cos);
        }
    }
}
