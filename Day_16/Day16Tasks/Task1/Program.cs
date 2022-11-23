using System;
using Task1.MathClasses;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of your matrix: ");
            int matrixSize = int.Parse(Console.ReadLine());
            MatrixMathOperations MOP = new MatrixMathOperations();
            Matrix matrix1 = new Matrix(matrixSize);
            Matrix matrix2 = new Matrix(matrixSize);
            Console.WriteLine("Initialize matrix1: ");
            Matrix.Initializator(matrix1);
            Console.WriteLine("Initialize matrix2: ");
            Matrix.Initializator(matrix2);
            Matrix SumOfMatrix = MOP.Plus(matrix1, matrix2);
            Matrix MinusOfMatrix = MOP.Minus(matrix1, matrix2);
            Matrix MultiplyOfMatrix = MOP.Multiply(matrix1, matrix2);
            Console.WriteLine("SUM");
            Console.WriteLine(SumOfMatrix.ToString());
            Console.WriteLine("Minus");
            Console.WriteLine(MinusOfMatrix.ToString());
            Console.WriteLine("Multiply");
            Console.WriteLine(MultiplyOfMatrix.ToString());
            Console.WriteLine("=======================");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Vectors: ");
            VectorMathOperations VOP = new VectorMathOperations();
            Vector vector1 = new Vector();
            Vector vector2 = new Vector();
            Console.WriteLine("Initialize vectro1: ");
            Vector.Initializator(vector1);
            Console.WriteLine("Initialize vectro2: ");
            Vector.Initializator(vector2);
            Console.WriteLine("Plus");
            Console.WriteLine(VOP.Plus(vector1,vector2).ToString());
            Console.WriteLine("Minus");
            Console.WriteLine(VOP.Minus(vector1,vector2).ToString());
            Console.WriteLine("Multiply");
            Console.WriteLine(VOP.Multiply(vector1,vector2).ToString());
            Console.WriteLine("===================");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            IntMathOperations IOP = new IntMathOperations();
            Console.Write("Number1: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write("Number2: ");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Multiply");
            Console.WriteLine(IOP.Multiply(number1,number2));
            Console.WriteLine("Plus");
            Console.WriteLine(IOP.Plus(number1,number2));
            Console.WriteLine("Minus");
            Console.WriteLine(IOP.Minus(number1,number2));
        }
    }
}
