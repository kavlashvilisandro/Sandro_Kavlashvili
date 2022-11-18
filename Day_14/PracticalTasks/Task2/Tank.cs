using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Tank : Fighter
    {
        private const int _maxSpeed = 25;
        private const string _name = "Tank";
        private double _price = 40;
        public Tank(double armour, double amountOfBullets) : base(armour, amountOfBullets)
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
