using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public class Vector
    {
        private double _x { get; set; }
        private double _y { get; set; }
        public Vector(Point A, Point B)
        {
            this._x = (double)(B[0] - A[0]);
            this._y = (double)(B[1] - A[1]);
        }
        public double X
        {
            get { return this._x; }
        }
        public double Y
        {
            get { return this._y; }
        }
        public double Length() 
        { 
            return Math.Sqrt(_x * _x + _y * _y);
        }
    }
}
