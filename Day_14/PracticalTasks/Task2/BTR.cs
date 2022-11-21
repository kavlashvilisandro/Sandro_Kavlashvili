using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{

    public class BTR : Fighter
    {
        private const int _maxSpeed = 30;
        private const string _name = "BTR";
        private double _price = 20;
        public BTR(double armour, double amountOfBullets) : base(armour, amountOfBullets)
        {
            base.MaxSpeed = _maxSpeed;
            base.FighterPrice = _price;
            base.CalculatePrice();
        }
        public override void Move(int amountOfMoves)
        {
            base.MileAge = base.MileAge + amountOfMoves * _maxSpeed;
        }

        public override void PrintAllData()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Armour: {base.Armour}|Bullets: {base.AmounOfBullets}");
            Console.WriteLine($"Price: {base.GetPrice()}");
            Console.WriteLine($"MaxSpeed: {base.MaxSpeed}|MileAge: {base.MileAge}");
            Console.WriteLine("=======");

        }
    }
}
