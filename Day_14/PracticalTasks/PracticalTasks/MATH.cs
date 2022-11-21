using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public static class MATH
    {
        public static double Distance(Point A, Point B)
        {
            double LengthSquared = (double)((A[0]-B[0])* (A[0] - B[0]) + (A[1]-B[1])* (A[1] - B[1]));
            return Math.Sqrt(LengthSquared);
        }
        public static double CosBetweenTwoVector(Vector a, Vector b)
        {
            return (a.X * b.X + a.Y * b.Y)/(a.Length() * b.Length());
        }
    }
}
