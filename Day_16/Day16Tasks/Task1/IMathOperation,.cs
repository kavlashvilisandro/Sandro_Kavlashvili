using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface IMathOperation_<T>
    {
        T Plus(T data1, T data2);
        T Minus(T data1, T data2);
        T Multiply(T data1, T data2);
    }
}
