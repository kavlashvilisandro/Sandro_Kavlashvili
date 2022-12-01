using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.MathClasses
{
    public class VectorMathOperations : IMathOperation_<Vector>
    {
        public Vector Minus(Vector data1, Vector data2)
        {
            Vector Result = new Vector();
            for(int i = 0; i < data1.Size; i++)
            {
                Result[i] = data1[i] - data2[i];
            }
            return Result;
        }

        //Cross product
        public Vector Multiply(Vector data1, Vector data2)
        {
            Vector Result = new Vector();
            Result[0] = data1[1] * data2[2] - data1[2] * data2[1];
            Result[1] =-(data1[0] * data2[2] - data2[0] * data1[2]);
            Result[2] = data1[0] * data2[1] - data1[1] * data2[0];
            return Result;
        }

        public Vector Plus(Vector data1, Vector data2)
        {
            Vector result = new Vector();
            for(int i = 0; i < result.Size; i++)
            {
                result[i] = data1[i] + data2[i];
            }
            return result;
        }
    }
}
