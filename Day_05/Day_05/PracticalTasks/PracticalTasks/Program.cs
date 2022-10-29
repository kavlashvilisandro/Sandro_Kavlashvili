using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1
            Console.Write("Enter your array size: ");
            int LengthOfArray = int.Parse(Console.ReadLine());
            int[] Array1 = new int[LengthOfArray];
            for (int i = 0; i < LengthOfArray; i++)
            {
                Console.Write("Enter number of index " + i + " : ");
                Array1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Here is your array");
            for (int i = 0; i < Array1.Length; i++)
            {
                Console.WriteLine(Array1[i]);
            }
            //===========

            Console.WriteLine();

            //Task2 Solution 1
            Console.Write("Enter your array size: ");
            int LengthOfArray2 = int.Parse(Console.ReadLine());
            int[] Array2 = new int[LengthOfArray2];
            for (int i = LengthOfArray2 - 1; i >= 0; i--)
            {
                Console.Write("Enter number of index " + (LengthOfArray2 - i - 1) + " : ");
                Array2[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < LengthOfArray2; i++)
            {
                Console.WriteLine(Array2[i]);
            }
            ////============
            ////Solution 2
            //Console.WriteLine("Solution 2  <------------------->");
            //for(int i = 0; i < LengthOfArray2; i++)
            //{
            //    Console.Write("Enter number of index " + i + " : ");
            //    Array2[i] = int.Parse(Console.ReadLine());
            //}
            //Array.Reverse(Array2);
            //for(int i = 0; i< LengthOfArray2; i++)
            //{
            //    Console.WriteLine(Array2[i]);
            //}
            ////Solution 3
            //Console.WriteLine("Solution 3  <------------------->");
            //for(int i = 0; i < LengthOfArray2; i++)
            //{
            //    Console.Write("Enter number of index " + i + " : ");
            //    Array2[i] = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Reversed: ");
            //for(int i = Array2.Length - 1; i >= 0; i--)
            //{
            //    Console.WriteLine(Array2[i]);
            //}
            ////====================

            Console.WriteLine();
            Console.WriteLine();

            //Task 3
            Console.Write("Enter array size: ");
            int LengthOfArray3 = int.Parse(Console.ReadLine());
            int[] Array3 = new int[LengthOfArray3];
            for (int i = 0; i < LengthOfArray3; i++)
            {
                Console.Write("enter element on index " + i + " :");
                Array3[i] = int.Parse(Console.ReadLine());
            }
            int Sum = 0;
            for (int i = 0; i < Array3.Length; i++)
            {
                Sum = Sum + Array3[i];
            }
            Console.WriteLine("Sum of your array elements is: " + Sum);
            //=============

            Console.WriteLine();
            Console.WriteLine();

            //==============

            //Task 4
            Console.Write("Enter your array size: ");
            int Array4Size = int.Parse(Console.ReadLine());
            int[] Array4 = new int[Array4Size];
            for (int i = 0; i < Array4Size; i++)
            {
                Console.Write("Enter your elment for index " + i + ": ");
                Array4[i] = int.Parse(Console.ReadLine());
            }
            int MultiplicationOfAllElements = 1;
            if (Array4Size == 0)
            {
                MultiplicationOfAllElements = 0;
            }
            for (int i = 0; i < Array4.Length; i++)
            {
                MultiplicationOfAllElements = MultiplicationOfAllElements * Array4[i];
            }
            Console.WriteLine("Product of all elements is: " + MultiplicationOfAllElements);
            //=================

            Console.WriteLine();
            Console.WriteLine();

            //Task 5
            Console.Write("Enter your array size: ");
            int Array5Size = int.Parse(Console.ReadLine());
            int[] Array5 = new int[Array5Size];
            for (int i = 0; i < Array5Size; i++)
            {
                Console.Write("Enter your element for index " + i + ": ");
                Array5[i] = int.Parse(Console.ReadLine());
            }
            int[] UniqueElements = new int[Array5Size];
            int counter = 0; // i-th element counter (amount)
            int indexer = 0;//indexer for unique elements array
            for (int i = 0; i < Array5.Length; i++)
            {
                for (int j = 0; j < Array5.Length; j++)
                {
                    if (Array5[i] == Array5[j])
                    {
                        counter++;
                        if (counter > 1)
                        {
                            break;
                        }
                    }
                }
                if (counter == 1)
                {
                    UniqueElements[indexer++] = Array5[i];
                }
                counter = 0;
            }
            Console.WriteLine("Unique Elements: ");
            for (int i = 0; i < indexer; i++)
            {
                Console.WriteLine(UniqueElements[i]);
            }

            //=====================================

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Task 6
            Console.Write("amount of rows: ");
            int Rows = int.Parse(Console.ReadLine());
            Console.Write("amount of columns: ");
            int Columns = int.Parse(Console.ReadLine());
            int[,] Matrix = new int[Rows, Columns];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write("Element for index: " + i + "," + j + ": ");
                    Matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Elements: ");
            string RowString = string.Empty;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    RowString = RowString + Matrix[i, j] + ", ";
                }
                Console.WriteLine(RowString);
                RowString = string.Empty;
            }
            //====================

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Task 7
            //Matrix sum
            Console.Write("Amount of Raws: ");
            int Rows2 = int.Parse(Console.ReadLine());
            Console.Write("Amound of Columns: ");
            int Columns2 = int.Parse(Console.ReadLine());
            int[,] Array2d1 = new int[Rows2, Columns2];
            int[,] Array2d2 = new int[Rows2, Columns2];
            Console.WriteLine("Enter elements for first matrix");
            for (int i = 0; i < Array2d1.GetLength(0); i++)
            {
                for (int j = 0; j < Array2d1.GetLength(1); j++)
                {
                    Console.Write($"Write element for index({i},{j}): ");
                    Array2d1[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter elements for second matrix");
            for (int i = 0; i < Array2d2.GetLength(0); i++)
            {
                for (int j = 0; j < Array2d2.GetLength(1); j++)
                {
                    Console.Write($"Write element for index({i},{j}): ");
                    Array2d2[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Here is sum of two matrix");
            string SumInString = string.Empty;
            for (int i = 0; i < Rows2; i++)
            {
                for (int j = 0; j < Columns2; j++)
                {
                    SumInString = SumInString + (Array2d1[i, j] + Array2d2[i, j]) + ", ";
                }
                Console.WriteLine(SumInString);
                SumInString = string.Empty;
            }
            //=================

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Task 8
            Console.Write("Task 8 amount of Rows: ");
            int Rows8 = int.Parse(Console.ReadLine());
            int Columns8 = Rows8;
            int[,] Matrix8 = new int[Rows8, Columns8];
            int RowIndex8 = 1;
            for (int i = 0; i < Matrix8.GetLength(0); i++)
            {
                for (int j = RowIndex8; j < Matrix8.GetLength(1); j++)
                {
                    Matrix8[i, j] = 1;
                }
                RowIndex8++;
            }
            Console.WriteLine("Matrix 8x8: ");
            string Matrix8String = string.Empty;
            for (int i = 0; i < Matrix8.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix8.GetLength(1); j++)
                {
                    Matrix8String = Matrix8String + Matrix8[i, j] + ", ";
                }
                Console.WriteLine(Matrix8String);
                Matrix8String = string.Empty;
            }
            int[,] PermutationMatrix = new int[Rows8, Columns8];//ეს არის მარჯვენა პერმუტაციის მატრიცა, რომელსაც ზემოხსენებული მატრიცა გადაჰყავს სასურველ მატრიცაში.

            for (int i = 0, j = Columns8 - 1; i < Rows8 && j >= 0; i++, j--)
            {
                PermutationMatrix[i, j] = 1;
            }
            Matrix8String = string.Empty;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Permutation matrix: ");
            for (int i = 0; i < Rows8; i++)
            {
                for (int j = 0; j < Columns8; j++)
                {
                    Matrix8String = Matrix8String + PermutationMatrix[i, j] + ", ";
                }
                Console.WriteLine(Matrix8String);
                Matrix8String = string.Empty;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Changed");
            int[] VectorRow = new int[Rows8];
            int[] VectorColumn = new int[Columns8];
            int[,] Result = new int[Rows8, Columns8];
            for (int i = 0; i < Rows8; i++)
            {
                for (int j = 0; j < Columns8; j++)
                {
                    for (int k = 0; k < Rows8; k++)//Rows Vector
                    {
                        VectorRow[k] = Matrix8[k, i];
                    }
                    for (int a = 0; a < Columns8; a++)//Column Vector
                    {
                        VectorColumn[a] = PermutationMatrix[j, a];
                    }
                    int Product8 = 0;
                    for (int c = 0; c < VectorRow.Length; c++)
                    {
                        Product8 = Product8 + VectorRow[c] * VectorColumn[c];
                    }
                    Result[i, j] = Product8;
                }
            }
            string data8 = string.Empty;
            for (int i = 0; i < Rows8; i++)
            {
                for (int j = 0; j < Columns8; j++)
                {
                    data8 = data8 + Result[i, j] + ", ";
                }
                Console.WriteLine(data8);
                data8 = string.Empty;
            }
            //==================================

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Jagged Array solution");

            Console.Write("Enter number of rows: ");
            int RowsX = int.Parse(Console.ReadLine());
            int[][] Jagged2D = new int[RowsX][];
            for (int i = 0; i < Jagged2D.Length; i++)
            {
                Jagged2D[i] = new int[RowsX];
            }
            int CounterX = 1;
            for (int i = 0; i < Jagged2D.Length; i++)
            {
                for (int j = CounterX; j < RowsX; j++)
                {
                    Jagged2D[i][j] = 1;
                }
                CounterX++;
            }
            string Data = string.Empty;
            for (int i = 0; i < Jagged2D.Length; i++)
            {
                for (int j = 0; j < Jagged2D[i].Length; j++)
                {
                    Data = Data + Jagged2D[i][j] + ", ";
                }
                Console.WriteLine(Data);
                Data = string.Empty;
            }

            int limit = RowsX / 2;
            int[] TempArray = new int[RowsX];
            for (int i = 0; i < limit; i++)
            {
                TempArray = Jagged2D[i];
                Jagged2D[i] = Jagged2D[RowsX - i - 1];
                Jagged2D[RowsX - i - 1] = TempArray;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Changed");
            for (int i = 0; i < Jagged2D.Length; i++)
            {
                for (int j = 0; j < Jagged2D[i].Length; j++)
                {
                    Data = Data + Jagged2D[i][j] + ", ";
                }
                Console.WriteLine(Data);
                Data = string.Empty;
            }
        }
    }
}