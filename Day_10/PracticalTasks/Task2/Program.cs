using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangleInstance = new Triangle();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter length of side {i + 1}: ");
                triangleInstance[i] = int.Parse(Console.ReadLine());
            }
            triangleInstance.PrintSides();
            Console.WriteLine($"Perimeter of the triangle is: {triangleInstance.getPerimeter()}");
            Console.WriteLine($"Area of triangle is {triangleInstance.getArea()}");
        }
    }
}
