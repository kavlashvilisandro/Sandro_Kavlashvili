using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Moto : CustomerTransport
    {
        private const double _maxSpeed = 120;
        private const int _amountOfWheels = 2;
        public Moto(bool hasWinterTire, CarMark mark) : base(hasWinterTire, mark, _amountOfWheels,nameof(Moto))
        {
            base.MaxSpeed = _maxSpeed;
        }
        public override void Move(int amountOfMoves)
        {
            base.MileAge = base.MileAge + amountOfMoves * base.MaxSpeed;
        }
    }
}
