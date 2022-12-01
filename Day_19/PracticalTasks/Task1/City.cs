using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class City : GeographicEntity
    {
        public readonly string Name;
        private readonly double Area;
        private readonly int Population;
        public readonly bool IsCapital;
        public City(string name,double area,int populaion,bool isCapital)
        {
            this.Name = name;
            this.Area = area;
            this.Population = populaion;
            this.IsCapital = isCapital;
        }
        public override int GetPopulation()
        {
            return this.Population;
        }

        public override double GetTotalArea()
        {
            return this.Area;
        }
        public override string ToString()
        {
            string result = $"City name: {this.Name} \n";
            result = result + $"City area: {this.Area} \n";
            result = result + $"City population: {this.Population}";
            if (this.IsCapital)
            {
                result = result + "\nCity is capital";
            }
            return result;
        }
    }
}
