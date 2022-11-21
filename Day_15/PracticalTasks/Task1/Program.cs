using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //======
            Console.ForegroundColor = ConsoleColor.Green;
            Matrix matrix = new Matrix();
            matrix.FillMatrix();
            Console.ForegroundColor= ConsoleColor.Red;
            Matrix matrix2 = new Matrix();
            matrix2.FillMatrix();
            double determinant = matrix;
            double determinant2 = matrix2;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("determimant of first matrix: " + determinant);
            Console.WriteLine("determimant of second matrix: " + determinant2);
            
            Console.WriteLine();
            
            Console.WriteLine("First matrix: ");
            Console.WriteLine(matrix.ToString());

            Console.WriteLine();
            
            Console.WriteLine("Second matrix: ");
            Console.WriteLine(matrix2.ToString());
            Console.WriteLine($"This to matrices are same: {matrix.Equals(matrix2)}");
            Console.WriteLine();
            Matrix result = matrix + matrix2;


            //Sum
            Console.WriteLine("Sum matrix: ");
            Console.WriteLine(result.ToString());

            Console.WriteLine("Determinant of sum matrix: " + result.Det);
            //====================
            
            
            //Substract
            Console.WriteLine("Substract matrix: ");
            Matrix substract = matrix - matrix2;
            Console.WriteLine(substract.ToString());
            Console.WriteLine("Determinant of substract matrix: ");
            Console.WriteLine(substract.Det);

            Console.WriteLine();
            //Multiplication
            //=====================
            Console.WriteLine("Multiplication Matrix");
            Matrix multiplication = matrix * matrix2;
            Console.WriteLine(multiplication.ToString());
            Console.WriteLine("Determinant of multiplication matrix: ");
            Console.WriteLine(multiplication.Det);

            //================
            //Inverse matrix
            Matrix Inverse = -matrix;
            Console.WriteLine("Inverse matrix: ");
            Console.WriteLine(Inverse.ToString());
            Console.WriteLine("inverse determinant: ");
            Console.WriteLine(Inverse.Det);
            Matrix Check = Inverse * matrix;
            Console.WriteLine();
            Console.WriteLine(Check.ToString());

            Console.WriteLine();

            //===================
        }
    }
}
