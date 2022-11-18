using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public class Triangle : IShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B; 
            this.C = C;
        }

        public double Perimeter()
        {
            return MATH.Distance(A, B) + MATH.Distance(B,C) + MATH.Distance(A,C);
        }
        public double Area()
        {
            Vector side1 = new Vector(this.A, this.B);
            Vector side2 = new Vector(this.A, this.C);
            double sin = Math.Sqrt(1 - MATH.CosBetweenTwoVector(side1, side2) * MATH.CosBetweenTwoVector(side1, side2));
            return side1.Length() * side2.Length() * sin * 0.5;
        }

    }
}
