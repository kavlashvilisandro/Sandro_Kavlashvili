using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Matrix
    {
        private int[,] _matrix;
        public int Size { get; private set; }
        public Matrix(int size)
        {
            _matrix = new int[size, size];
            this.Size = size;
        }

        public int this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }

        public override string ToString()
        {
            string SomeData = string.Empty;
            for(int i = 0; i < this.Size; i++)
            {
                for(int j = 0; j < this.Size; j++)
                {
                    SomeData = SomeData + this[i, j] + " ";
                }
                SomeData = SomeData + "\n";
            }
            return SomeData;
        }

        public static void Initializator(Matrix matrix)
        {
            for(int i = 0; i < matrix.Size; i++)
            {
                for(int j = 0; j < matrix.Size; j++)
                {
                    Console.Write($"Enter element for index ({i},{j}): ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public static bool operator ==(Matrix left, Matrix right)
        {
            return left.Size == right.Size;
        }
        public static bool operator !=(Matrix left, Matrix right)
        {
            return left.Size != right.Size;
        }
    }
}
