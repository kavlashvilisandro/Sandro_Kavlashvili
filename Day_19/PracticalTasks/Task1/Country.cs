using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Task1
{
    public class Country : GeographicEntity
    {
        public string Name { get; private set; }
        public IEnumerable<City> _cities;
        public readonly int CitiesAmount;
        private int? _population;
        private double? _totalArea;
        //private bool _capitalIsIn = false;

        public Country(string name)
        {
            this.Name = name;
            if (!SingleCapitalChecker(name))
            {
                throw new CountryMustHaveSingleCapital();
            }
            this.CitiesAmount = CityAmountCounter(this);
            this._cities = MyCities(this);
        }


        public override int GetPopulation()
        {
            if(_population == null)
            {
                _population = 0;
                for(int i = 0; i< this._cities.Count(); i++)
                {
                    _population = _population + this._cities.ElementAt(i).GetPopulation();
                }
                return Convert.ToInt32(_population);
            }
            else
            {
                return Convert.ToInt32(_population);
            }
        }

        public override double GetTotalArea()
        {
            if(_totalArea == null)
            {
                _totalArea = 0;
                for(int i = 0; i < _cities.Count(); i++)
                {
                    _totalArea = _totalArea + _cities.ElementAt(i).GetTotalArea();
                }
                return Convert.ToDouble(_totalArea);
            }
            else
            {
                return Convert.ToDouble(_totalArea);
            }
        }
        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < _cities.Count(); i++)
            {
                result = result + this._cities.ElementAt(i).ToString() + "\n ==== \n";
            }
            return result;
        }
        public static IEnumerable<City> MyCities(Country country)
        {
            StreamReader reader = new StreamReader("Cities.txt");
            string line = "AE";
            string[] words;
            string name;
            double Area;
            int population;
            bool isCapital;
            while(line != null)
            {
                line = reader.ReadLine();
                if(line != null && line.Split('|').Length == 5 && line.Split('|')[4].Equals(country.Name))
                {
                    words = line.Split('|');
                    name = words[0];
                    Area = double.Parse(words[1]);
                    population = int.Parse(words[2]);
                    isCapital = bool.Parse(words[3]);
                    //country._capitalIsIn = true;
                    yield return new City(name, Area, population, isCapital);
                }
            }
            reader.Close();
        }
        public static int CityAmountCounter(Country country)
        {
            int counter = 0;
            StreamReader reader = new StreamReader("Cities.txt");
            string line = reader.ReadLine();
            while(line != null)
            {
                if (line.Contains(country.Name))
                {
                    counter++;
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return counter;
        }
        public static bool SingleCapitalChecker(string name)
        {
            int counter = 0;
            string[] lines = File.ReadAllLines("Cities.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Split('|').Length == 5 && lines[i].Split('|')[4].Equals(name))
                {
                    if(bool.Parse(lines[i].Split('|')[3]) == true)
                    {
                        counter++;
                        if(counter > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
