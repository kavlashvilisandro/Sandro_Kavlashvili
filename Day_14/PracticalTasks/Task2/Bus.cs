using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Bus : PublicTransport
    {
        private const int _maxSpeed = 30;
        public Bus(int capacity) : base(PTransport.Bus, capacity)
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
