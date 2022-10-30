using System;

namespace PracticalTasks
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Task1
            numberOnIndex(new int[] { 1, 2, 3, 4, 12, 1, 341, 41 }, 1);

            //Task2
            int[] Array2 = { 1, 2, 3, 4, 112, 3, 41, 2, 423, 412321 };
            int index2 = 9;
            Console.WriteLine($"The sum of digits of a number at index {index2} is {sumOfDigits(Array2,index2)}");
            redBorderPrinter();

            //Task3
            Console.Write("Enter size of array: ");
            int size3 = int.Parse(Console.ReadLine());
            MinAndMax(ArrayFiller(size: size3));
            redBorderPrinter();

            //Task4
            Console.Write("Enter size of array: ");
            int size4 = int.Parse(Console.ReadLine());
            avgCounter(ArrayFiller(size: size4));

            //Task5
            Console.Write("Enter size of the array: ");
            int size5 = int.Parse(Console.ReadLine());
            Console.Write("Enter whole number: ");
            int number5 = int.Parse(Console.ReadLine());
            Task5(ArrayFiller(size: size5), number5);
            redBorderPrinter();

            //Task6
            Console.Write("Enter your char array size: ");
            int size6 = int.Parse(Console.ReadLine());
            Console.Write("Enter your symbol: ");
            char symbol = char.Parse(Console.ReadLine());
            Task6(ArrayFiller(charSize: size6), symbol);
            redBorderPrinter();


            //Task7
            Console.Write("Enter amount of rows: ");
            int rows7 = int.Parse(Console.ReadLine());
            Console.Write("Enter amount of Columns: ");
            int Columns7 = int.Parse(Console.ReadLine());
            int[,] Matrix1 = ArrayFiller(RowSize: rows7, ColumnSize: Columns7);
            Console.WriteLine();
            Console.WriteLine("Second Matrix:");
            Console.WriteLine();
            int[,] Matrix2 = ArrayFiller(RowSize: rows7, ColumnSize: Columns7);
            MatrixPrinter(MatrixSum(Matrix1, Matrix2));
            redBorderPrinter();


            //Task8
            Task8();

            //Task9
            ProductOfArrayElements(1, 2, 3, 4, 5, 5, 6, 7);
        }

        public static void ProductOfArrayElements(params int[] array)
        {
            int product = 1;
            for(int i = 0; i < array.Length; i++)
            {
                product = product * array[i];
            }
            Console.WriteLine($"the product of array elements is: {product}");
        }
        public static void Task8()
        {
            Console.Write("Enter a positive number: ");
            int number8 = int.Parse(Console.ReadLine());
            unfoldNumber(number8);
        }

        /*
         this method prints decimal number into powers of 10
         */
        public static void unfoldNumber(int number)
        {
            string numberInString = Convert.ToString(number);
            for(int i = 0; i < numberInString.Length; i++)
            {
                if(i == numberInString.Length - 1)
                {
                    Console.Write($"{numberInString[i]} * 10^{numberInString.Length - i - 1} \n");
                }
                else
                {
                    Console.Write($"{numberInString[i]} * 10^{numberInString.Length - i - 1} + ");
                }
            }
        }


        /*
         this metho returns sum of 2 matrixes
         */
        public static int[,] MatrixSum(int[,] Matrix1, int[,] Matrix2)
        {
            int[,] SumMatrix = new int[Matrix1.GetLength(0),Matrix1.GetLength(1)];
            for(int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for(int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    SumMatrix[i, j] = Matrix1[i, j] + Matrix2[i, j];
                }
            }
            return SumMatrix;
        }
        public static void MatrixPrinter(int[,] Matrix)
        {
            string row = string.Empty;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    row = row + Matrix[i, j] + ", ";
                }
                Console.WriteLine(row);
                row = string.Empty;
            }
        }

        /*
         this method takes char array and symbol as arguments and if this symbol
        is in array, prints amount, how many this symbol is in this array
         */
        public static void Task6(char[] array, char symbol)
        {
            Console.WriteLine($"amount of symbol: '{symbol}' in this array is {isIn(array,symbol)}");
        }


        /*
         this method prints number's factorial if number is in array
        and if number is not in array, it prints that this number is not
        in this array
         */
        public static void Task5(int[] array, int number)
        {
            if (isIn(array, number))
            {
                Console.WriteLine($"Factorial of {number} is {Factorial(number)}");
                return;
            }
            Console.WriteLine(number + " is not in this array");
        }

        public static int Factorial(int number)
        {
            if (number == 0) return 1;
            if(number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }

        /*
         this method returns true if number is in array and returns
        false if number is not in array
         */
        public static bool isIn(int[] array,int number)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == number)
                {
                    return true;
                }
            }
            return false;
        }
        public static int isIn(char[] array, char symbol)
        {
            int counter = 0;//symbol amount counter in array
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == symbol)
                {
                    counter++;
                }
            }
            return counter;
        }
        /*
         this method prints avarage value of elements of argument array
         */
        public static void avgCounter(int[] array)
        {
            int sum = 0; 
            for(int i = 0; i < array.Length; i++)
            {
                sum = sum + array[i];
            }
            Console.WriteLine("avg value of this array is: " + (double)sum / array.Length);
            
            redBorderPrinter();
        }
        /*
         this method prints min and max from argument array
         */
        public static void MinAndMax(int[] array)
        {
            int min = array[0];
            int max = array[0];
            for(int i = 1; i < array.Length; i++)
            {
                if(array[i] < min)
                {
                    min = array[i];
                }else if(array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine("the smalles element in this array is: " + min);
            Console.WriteLine("the biggest element in this array is: " + max);
        }

        /*
         this method creates, fills and returns array
         */
        public static int[] ArrayFiller(int size)
        {
            int[] Array = new int[size];    
            for(int i = 0; i < Array.Length; i++)
            {
                Console.Write($"Enter element for index {i}: ");
                Array[i] = int.Parse(Console.ReadLine());
            }
            return Array;
        }
        public static char[] ArrayFiller(int charSize , char data = 'd')
        {
            char[] array = new char[charSize];
            for(int i = 0; i < charSize; i++)
            {
                Console.Write($"Enter character for index {i}: ");
                array[i] = char.Parse(Console.ReadLine());
            }
            return array;
        }

        public static int[,] ArrayFiller(int RowSize, int ColumnSize)
        {
            int[,] Matrix = new int[RowSize, ColumnSize];
            for(int i = 0; i < Matrix.GetLength(0); i++)
            {
                for(int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write($"Enter your matrix element on ({i},{j}) index: ");
                    Matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return Matrix;
        }
        public static int sumOfDigits(int[] Array, int index)
        {
            /*
             if index is out of range, it returns -1
             */
            if (index < 0 || index > Array.Length - 1) return -1;

            string specificNumber = Convert.ToString(Array[index]);
            
            int digitsSum = 0;

            for(int i = 0; i < specificNumber.Length; i++)
            {
                digitsSum = digitsSum + Convert.ToInt32(Convert.ToString(specificNumber[i]));
            }

            return digitsSum;
        }

        public static void numberOnIndex(int[] Array, int index)
        {
            /*
             if index is out of range, it prints custom message
             */
            if (index < 0 || index > Array.Length - 1)
            {
                Console.WriteLine("index out of range");
                redBorderPrinter();
                return;
            }
            Console.WriteLine($"Number at index {index} in the array is {Array[index]}");
            
            redBorderPrinter();
        }


        /*
         this method makes red border between tasks
         */
        public static void redBorderPrinter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("=====");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
