using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public abstract class Vehicle
    {
        //Fields
        private double _maxSpeed;
        private double _mileage;
        //Properties
        public double MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                if(value > 0)
                {
                    _maxSpeed = value;
                }
            }
        }
        public double MileAge
        {
            get
            {
                return _mileage;
            }
            set
            {
                if (value >= 0)
                {
                    _mileage = value;
                }
            }
        }
        //Methods
        public abstract void PrintAllData();
        public abstract void Move(int amountOfMoves);
        
    }
}
