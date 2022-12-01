using System;
using System.Collections.Generic;
using System.Text;
using Task1;

namespace Task1.MathClasses
{
    public class MatrixMathOperations : IMathOperation_<Matrix>
    {
        public Matrix Minus(Matrix data1, Matrix data2)
        {
            if(data1 != data2)
            {
                return null;
            }
            Matrix ResultMatrix = new Matrix(data1.Size);
            for(int i = 0; i < data1.Size; i++)
            {
                for(int j = 0; j < data1.Size; j++)
                {
                    ResultMatrix[i, j] = data1[i, j] - data2[i, j];
                }
            }
            return ResultMatrix;
        }

        public Matrix Multiply(Matrix data1, Matrix data2)
        {
            if (data1 != data2)
            {
                return null;
            }
            int[] Vector1 = new int[data1.Size];//For row
            int[] Vector2 = new int[data1.Size];//For column
            Matrix result = new Matrix(data1.Size);
            for(int i = 0; i < result.Size; i++)
            {
                for(int j = 0; j < result.Size; j++)
                {
                    for(int k = 0; k < Vector1.Length; k++)
                    {
                        Vector1[k] = data1[i, k];
                    }
                    for (int k = 0; k < Vector2.Length; k++)
                    {
                        Vector2[k] = data2[k,j];
                    }
                    result[i, j] = MultiplyArray(Vector1, Vector2);
                }
            }
            return result;

        }
        public static int MultiplyArray(int[] array1, int[] array2)
        {
            int number = 0;
            for(int i = 0; i < array1.Length; i++)
            {
                number = number + array1[i] * array2[i];
            }
            return number;
        }

        public Matrix Plus(Matrix data1, Matrix data2)
        {
            if(data1 != data2)
            {
                return null;
            }
            Matrix matrix = new Matrix(data1.Size);
            for(int i = 0; i < matrix.Size; i++)
            {
                for(int j = 0; j < matrix.Size; j++)
                {
                    matrix[i, j] = data1[i, j] + data2[i, j];
                }
            }
            return matrix;
        }
    }
}
