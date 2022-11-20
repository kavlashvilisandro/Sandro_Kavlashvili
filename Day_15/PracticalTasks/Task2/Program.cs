using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] sidesArray = new double[3];
            Console.WriteLine("Triangle 2");
            for(int i = 0; i < 3; i++)
            {
                Console.Write($"Enter side{i+1}: ");
                sidesArray[i] = double.Parse(Console.ReadLine());
            }
            Triangle triangle1 = new Triangle(sidesArray[0], sidesArray[1], sidesArray[2]);
            Console.WriteLine("Triangle 1");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter side{i + 1}: ");
                sidesArray[i] = double.Parse(Console.ReadLine());
            }
            Triangle triangle2 = new Triangle(sidesArray[0], sidesArray[1], sidesArray[2]);
            
            
            Console.WriteLine(triangle1.Area());
            Console.WriteLine(triangle2.Area());
            Console.WriteLine(triangle1 == triangle2);
            Console.WriteLine(triangle1 != triangle2);
            Console.WriteLine(triangle1 > triangle2);
            Console.WriteLine(triangle1 < triangle2);
            Console.WriteLine("Sum operator: ");
            Triangle Sumed = triangle1 + triangle2;
            Console.WriteLine($"Area of summed triangle: {Sumed.Area()}");
            Console.WriteLine(Sumed.Side1);
            Console.WriteLine(Sumed.Side2);
            Console.WriteLine(Sumed.Side3);
            Console.WriteLine();
            Triangle triangle = (Triangle)1;
            Console.WriteLine(triangle.Side1);
            Console.WriteLine(triangle.Side2);
            Console.WriteLine(triangle.Side3);
            Console.WriteLine(triangle.Area());
        }
    }
}
