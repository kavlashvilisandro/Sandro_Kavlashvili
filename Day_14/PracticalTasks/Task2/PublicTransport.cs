using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public enum WorkingOn
    {
        Gasoline = 1,
        Electricity,
    }
    public enum PTransport
    {
        Bus = 1,
        Traumay,
    }
    public abstract class PublicTransport : Vehicle, IPrice
    {
        private readonly int _peopleCapacity;
        private const int oneCustomerPrice = 10;
        private readonly WorkingOn _material;
        private double _transportPrice;
        private double _fullPrice;
        public double TransportPrice
        {
            set
            {
                _transportPrice = value;
            }
        }
        public PublicTransport(PTransport transport,int capacity)
        {
            this._material = (WorkingOn)((int)transport);
            this._peopleCapacity = capacity;
            this._transportPrice = (int)transport * 2000;
        }

        public void CalculatePrice()
        {
            _fullPrice = _peopleCapacity * oneCustomerPrice + _transportPrice;
        }

        public double GetPrice()
        {
            return this._fullPrice;
        }
        public sealed override void PrintAllData()
        {
            Console.WriteLine($"Category: {(PTransport)((int)_material)}");
            Console.WriteLine($"MaxSpeed: {base.MaxSpeed}");
            Console.WriteLine($"Capacity: {this._peopleCapacity}");
            Console.WriteLine($"Full Price: {this._fullPrice}");
            Console.WriteLine($"Works on {_material}");
            Console.WriteLine($"MileAge: {base.MileAge}");
            Console.WriteLine("=========");
        }
    }
}
