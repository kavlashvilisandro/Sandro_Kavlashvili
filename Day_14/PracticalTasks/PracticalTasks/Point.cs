using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public class Point
    {
        private double _x;
        private double _y;
        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }
        /*
         if users requests none valid index, it returns null
         */
        public double? this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return this._x;
                }else if(index == 1)
                {
                    return this._y;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
