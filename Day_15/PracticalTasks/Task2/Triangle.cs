using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Triangle
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }
        public Triangle(double side1, double side2, double side3)
        {
            if(side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
            {
                this.Side1 = side1;
                this.Side2 = side2;
                this.Side3 = side3;
            }
        }
        public double Area()
        {
            return Side1 * Side2 * MATH.SinFromCos(MATH.CosTheorem(Side1, Side2, Side3)) * 0.5;
        }
        public double Perimeter()
        {
            return this.Side1 + this.Side2 + this.Side3;
        }
        public static bool operator <(Triangle left, Triangle right)
        {
            return left.Area() < right.Area();
        }
        public static bool operator >(Triangle left, Triangle right)
        {
            return left.Area() > right.Area();
        }
        public static bool operator ==(Triangle left, Triangle right)
        {
            return left.Area() == right.Area();
        }
        public static bool operator !=(Triangle left, Triangle right)
        {
            return left.Area() != right.Area();
        }
        public static Triangle operator +(Triangle left, Triangle right)
        {
            //returns right triangle where one side equals to 1
            double SumOfArea = left.Area() + right.Area();
            return new Triangle(1, 2 * SumOfArea, Math.Sqrt(1 + 4 * SumOfArea * SumOfArea));
        }
        public static explicit operator Triangle(double number)
        {
            return new Triangle(number, number, number);
        }
    }
}
