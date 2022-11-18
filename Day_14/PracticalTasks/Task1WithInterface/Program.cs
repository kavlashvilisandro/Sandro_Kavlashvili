using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape[] shape = new IShape[3];

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Circle");
            Console.ForegroundColor = ConsoleColor.White;
            //Circle
            Console.Write("Enter circle center X: ");
            double CenterX = double.Parse(Console.ReadLine());
            Console.Write("Enter circle center Y: ");
            double CenterY = double.Parse(Console.ReadLine());
            Console.Write("Enter one Circle point X: ");
            double CirclePointX = double.Parse(Console.ReadLine());
            Console.Write("Enter one Circle point Y: ");
            double CirclePointY = double.Parse(Console.ReadLine());
            shape[0] = new Circle(new Point(CenterX, CenterY), new Point(CirclePointX, CirclePointY));
            //===
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rectangle");
            Console.ForegroundColor = ConsoleColor.White;
            //Rectange
            Console.Write("Enter pointA x: ");
            double Ax = double.Parse(Console.ReadLine());
            Console.Write("Enter pointA y: ");
            double Ay = double.Parse(Console.ReadLine());
            Console.Write("Enter pointB x: ");
            double Bx = double.Parse(Console.ReadLine());
            Console.Write("Enter pointB y: ");
            double By = double.Parse(Console.ReadLine());
            Console.Write("Enter pointC x: ");
            double Cx = double.Parse(Console.ReadLine());
            Console.Write("Enter pointC y: ");
            double Cy = double.Parse(Console.ReadLine());
            Console.Write("Enter pointD x: ");
            double Dx = double.Parse(Console.ReadLine());
            Console.Write("Enter pointD y: ");
            double Dy = double.Parse(Console.ReadLine());
            shape[1] = new Rectangle(new Point(Ax, Ay), new Point(Bx, By), new Point(Cx, Cy), new Point(Dx, Dy));
            //===

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Triangle");
            Console.ForegroundColor = ConsoleColor.White;
            //Triangle
            Console.Write("Enter Ax: ");
            Ax = double.Parse(Console.ReadLine());
            Console.Write("Enter Ay: ");
            Ay = double.Parse(Console.ReadLine());
            Console.Write("Enter Bx: ");
            Bx = double.Parse(Console.ReadLine());
            Console.Write("Enter By: ");
            By = double.Parse(Console.ReadLine());
            Console.Write("Enter Cx: ");
            Cx = double.Parse(Console.ReadLine());
            Console.Write("Enter Cy: ");
            Cy = double.Parse(Console.ReadLine());
            shape[2] = new Triangle(new Point(Ax, Ay), new Point(Bx, By), new Point(Cx, Cy));

            for(int i = 0; i < shape.Length; i++)
            {
                Console.WriteLine($"Element at {i} index -> Area: {shape[i].Area()}, Perimeter {shape[i].Perimeter()}");
            }

        }
    }
}
