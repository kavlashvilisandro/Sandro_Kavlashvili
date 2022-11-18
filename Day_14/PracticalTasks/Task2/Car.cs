using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public enum Cars
    {
        MERCEDES,
        BMW,
        NISAN,
        OPEL,
    }
    public enum CarMark//Marks And Prices
    {
        MERCEDES = 3000,
        BMW,//3001
        NISAN = 2500,
        OPEL = 2000,
    }
    public class Car : CustomerTransport
    {
        private const int _amountOfWheels = 4;
        private const double _maxSpeed = 60;
        public Car(bool hasWinterTire, CarMark mark) : base(hasWinterTire, mark, _amountOfWheels,nameof(Car))
        {
            base.MaxSpeed = _maxSpeed;
        }
        public override void Move(int amountOfMoves)
        {
            base.MileAge = base.MileAge + amountOfMoves * base.MaxSpeed;
        }

        
    }
}
