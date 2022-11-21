using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public abstract class Fighter : Vehicle, IPrice
    {
        private double _fullPrice;
        private const double _oneBulletPrice = 10;
        private const double _armourPrice = 20;
        protected double Armour { get; set; }
        protected double AmounOfBullets { get; set; }
        protected double FighterPrice { get; set; }
        protected Fighter(double armour, double amountOfBullets)
        {
            this.Armour = armour;
            this.AmounOfBullets = amountOfBullets;
        }
        public void CalculatePrice()
        {
            _fullPrice =  AmounOfBullets * _oneBulletPrice + FighterPrice + Armour * _armourPrice;
        }

        public double GetPrice()
        {
            return this._fullPrice;
        }
    }
}
