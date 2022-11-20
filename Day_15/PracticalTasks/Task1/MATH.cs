using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public static class MATH
    {
        //this method returns Minor matrix
        private static double[,] GetMinor(int i2, int j2, double[,] matrix)
        {
            double[,] MatrixRes = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int column = 0;
            int row = 0;
            bool PrintedRow = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != i2 && j != j2)
                    {
                        PrintedRow = true;
                        MatrixRes[row, column] = matrix[i, j];
                        column++;
                    }
                }
                column = 0;
                if (PrintedRow)
                {
                    row++;
                    PrintedRow = false;
                }
            }
            return MatrixRes;
        }

        //This method calculates determinant for nxn matrixes
        public static double GetDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double result = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result = result + matrix[0, j] * GetDeterminant(GetMinor(0, j, matrix)) * SignCalculatorForMinor(0, j);
                }
                return result;
            }
        }

        //This method calculates sign of Minor det times i,j element
        private static int SignCalculatorForMinor(int i, int j)
        {
            if ((i + j + 2) % 2 == 1)
            {
                return -1;
            }
            return 1;
        }

        //This method returns sum of 2 nxn matrixres
        public static double[,] SumOfMatrices(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for(int i = 0; i < matrix1.GetLength(0); i++)
            {
                for(int j = 0; j < matrix2.GetLength(1); j++)
                {
                    result[i,j] = matrix1[i,j] + matrix2[i,j];
                }
            }
            return result;
        }

        //This method returns substract of 2 nxn matrices
        public static double[,] SubstractOfMatrices(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }
        public static double VectorMultiplication(double[] vector1, double[] vector2)
        {
            double sum = 0;
            for(int i = 0; i < vector1.Length; i++)
            {
                sum = sum + vector1[i] * vector2[i];
            }
            return sum;
        }

        public static double[,] MatrixMultiplication(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            double[] vector1 = new double[matrix1.GetLength(0)];
            double[] vector2 = new double[matrix1.GetLength(0)];
            for(int i = 0; i < matrix1.GetLength(0); i++)
            {
                for(int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for(int k1 = 0; k1 < vector1.Length; k1++)
                    {
                        vector1[k1] = matrix1[i, k1];
                    }
                    for(int k2 = 0; k2 < vector2.Length; k2++)
                    {
                        vector2[k2] = matrix2[k2, j];
                    }
                    result[i, j] = VectorMultiplication(vector1, vector2);
                }
            }
            return result;
        }

        public static double[,] Inverse(double[,] matrix)
        {
            return ScalarTimesMatrix(1/GetDeterminant(matrix), matrixTranspose(CoFactorMatirx(matrix)));
        }


        //This method returns cofactor matrix
        private static double[,] CoFactorMatirx(double[,] matrix)
        {
            double[,] resultMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = SignCalculatorForMinor(i,j)*GetDeterminant(GetMinor(i, j, matrix));
                }
            }
            return resultMatrix;
        }

        //This method makes transpose of argument matrix
        private static double[,] matrixTranspose(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for(int i = 0; i < result.GetLength(0); i++)
            {
                for(int j = 0; j < result.GetLength(1); j++)
                {
                    result[j,i] = matrix[i,j];
                }
            }
            return result;
        }

       
        private static double[,] ScalarTimesMatrix(double scalar, double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j< matrix.GetLength(1); j++)
                {
                    result[i, j] = scalar * matrix[i, j];
                }
            }
            return result;
        }
        
    }
}
