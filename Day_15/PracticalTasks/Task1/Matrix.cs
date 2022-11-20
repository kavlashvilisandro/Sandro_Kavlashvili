using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Matrix
    {
        private double[,] _matrix;
        public double Det { get; private set; }
        public double[,] GetMatrix
        {
            get
            {
                return _matrix;
            }
            private set
            {
                _matrix = value;
                this.Det = MATH.GetDeterminant(value);
            }
        }

        public double? this[int index1, int index2]
        {
            //Returns null if index is out of range
            get
            {
                if(index1 < _matrix.GetLength(0) && index2 < _matrix.GetLength(1))
                {
                    return _matrix[index1, index2];
                }
                return null;
            }
        }

        /*
         this method fills _matrix from console
         */
        public void FillMatrix()
        {
            Console.WriteLine("Enter dimensions of square matrix: ");
            Console.Write("Enter amount of rows and columns: ");
            int n = int.Parse(Console.ReadLine());
            this._matrix = new double[n, n];
            double numberForMatrix;
            for(int i = 0; i < _matrix.GetLength(0); i++)
            {
                for(int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write($"Enter number for index({i},{j})");
                    numberForMatrix = double.Parse(Console.ReadLine());
                    this._matrix[i,j] = numberForMatrix;
                }
            }
            this.Det = MATH.GetDeterminant(this._matrix);
        }

        //This method returns matrix into string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < _matrix.GetLength(0); i++)
            {
                for(int j = 0; j < _matrix.GetLength(1); j++)
                {
                    sb.Append(this._matrix[i, j] + ", ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        //implicitly casts matrix into double and returns determinant
        public static implicit operator double(Matrix matrix)
        {
            return matrix.Det;
        }
        public static Matrix operator +(Matrix left, Matrix right)
        {
            Matrix result = new Matrix();
            result.GetMatrix = MATH.SumOfMatrices(left.GetMatrix, right.GetMatrix);
            return result;
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            Matrix result = new Matrix();
            result.GetMatrix = MATH.SubstractOfMatrices(left.GetMatrix, right.GetMatrix);
            return result;
        }
        public static Matrix operator *(Matrix left, Matrix right)
        {
            Matrix result = new Matrix();
            result.GetMatrix = MATH.MatrixMultiplication(left.GetMatrix, right.GetMatrix);
            return result;
        }

        public static Matrix operator -(Matrix right)
        {
            Matrix result = new Matrix();
            result.GetMatrix = MATH.Inverse(right.GetMatrix);
            return result;
        }
        public override bool Equals(object obj)
        {
            if(this.ToString() == obj.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
