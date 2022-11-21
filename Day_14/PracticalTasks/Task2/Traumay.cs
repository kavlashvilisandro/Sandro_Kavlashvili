using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Traumay : PublicTransport
    {
        private const int _maxSpeed = 10;
        public Traumay(int capacity) : base(PTransport.Traumay, capacity)
        {
            base.MaxSpeed = _maxSpeed;
            base.CalculatePrice();
        }
        public override void Move(int amountOfMoves)
        {
            base.MileAge = base.MileAge + amountOfMoves * _maxSpeed;
        }
    }
}
