using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public class Rectangle : IShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public Rectangle(Point A, Point B, Point C, Point D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }
        public double Perimeter()
        {
            Vector side1 = new Vector(A, B);
            Vector side2 = new Vector(B, C);
            Vector side3 = new Vector(C, D);
            Vector side4 = new Vector(D, A);
            return side1.Length() + side2.Length() + side3.Length() + side4.Length();
        }
        public double Area()
        {
            Triangle triangle1 = new Triangle(A, B, C);
            Triangle triangle2 = new Triangle(B, C, D);
            return triangle1.Area() + triangle2.Area();
        }
    }
}
