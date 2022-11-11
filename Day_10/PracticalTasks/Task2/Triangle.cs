using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Triangle
    {
        private double[] sides = new double[3];

        public double this[int index]
        {
            set
            {
                if(index != 2)
                {
                    if (value < 0)
                    {
                        Console.WriteLine($"Value is negative so we set -1 * {value}");
                        sides[index] = -1 * value;
                    }
                    else
                    {
                        sides[index] = value;
                    }
                }
                else
                {
                    if(value <= sides[0] + sides[1] && sides[0] <= value + sides[1] && sides[1] <= value + sides[0])
                    { 
                        sides[2] = value;
                    }
                    else
                    {
                        Console.WriteLine($"Value is incorrect so we set sum of other 2 sides: {sides[0] + sides[1]}");
                        sides[2] = sides[0] + sides[1];
                    }
                }
            }
            get
            {
                if(index > 2 && index < 0)
                {
                    Console.WriteLine("incorrect index");
                    return -1;
                }
                else
                {
                    return sides[index];
                }
            }
        }

        public void PrintSides()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Side {i+1} : {sides[i]}");
            }
        }


        public double getPerimeter()
        {
            double sum = 0;
            for(int i = 0; i < 3; i++)
            {
                sum = sum + sides[i];
            }
            return sum;
        }

        public double getArea()
        {
            return sides[0] * sides[1] * SinBetweenSides() * 0.5;
        }

        private double SinBetweenSides()
        {
            //c^2 = a^2 + b^2 - 2abcos
            double squareSum = 0;
            double temp = sides[2] * sides[2] - sides[0] * sides[0] - sides[1] * sides[1];
            double cos = temp / (sides[0] * sides[1] * (-2));
            return Math.Sqrt(1 - cos * cos);
        }
    }
}
