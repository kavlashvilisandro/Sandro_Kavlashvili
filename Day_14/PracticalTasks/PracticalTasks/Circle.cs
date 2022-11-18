using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public class Circle : Shape
    {
        public Point Center { get; set; }

        public double Radius { get; set; }

        public Circle(Point center,Point CirclePoint)
        {
            this.Center = center;
            this.Radius = new Vector(center,CirclePoint).Length();
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double Area()
        {
            return Math.PI * this.Radius * this.Radius;
        }

    }
}
