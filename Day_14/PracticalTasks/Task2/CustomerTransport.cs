using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public abstract class CustomerTransport : Vehicle, IPrice
    {
        private readonly string _category;
        private const double _winterTirePrice = 30;
        private bool _hasWinterTire;
        private double _fullPrice;
        private CarMark _mark;
        private readonly int _amountOfWheels;
        
        public CustomerTransport(bool hasWinterTire, CarMark mark, int amountOfWheels,string category)
        {
            this._category = category;
            this._amountOfWheels = amountOfWheels;
            this._hasWinterTire = hasWinterTire;
            this._mark = mark;
            this.CalculatePrice(); 
        }
        public void CalculatePrice()
        {
            _fullPrice = Convert.ToInt32(_hasWinterTire) * _amountOfWheels * _winterTirePrice + (int)_mark;
        }

        public double GetPrice()
        {
            return _fullPrice;
        }
        public sealed override void PrintAllData()
        {
            Console.WriteLine($"Category: {this._category}");
            Console.WriteLine($"Mark: {_mark.ToString()}");
            Console.WriteLine($"Winter tire has: {this._hasWinterTire}");
            Console.WriteLine($"Price: {_fullPrice}");
            Console.WriteLine($"MileAge: {base.MileAge}");
            Console.WriteLine("=======");
        }
    }
}
