using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Program
    {
        public static IEnumerable<Country> Countries = CountriesGetter();
        public static void Main(string[] args)
        {
            if (!File.Exists("Logs.txt"))
            {
                File.Create("Logs.txt").Close();
            }
            Task1();
            
        }

        public static void Task1()
        {
            int option;
            string city;
            City CityObj;
            Country countryObj;
            string country;
            while (true)
            {
                try
                {
                    Console.Write("1)Search country | 2)Search city |: ");
                    option = int.Parse(Console.ReadLine());
                    if(option == 2)
                    {
                        Console.Write("Enter city name: ");
                        city = Console.ReadLine();
                        CityObj = CitySearcher(city);
                        if(CityObj != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(CityObj);
                            Console.ForegroundColor= ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid name");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }else if(option == 1)
                    {
                        Console.Write("Enter country name: ");
                        country = Console.ReadLine();
                        countryObj = CountrySearcher(country);
                        if(countryObj != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(countryObj);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid name");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }catch(CountryMustHaveSingleCapital ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    File.AppendAllText("Logs.txt", ex.Message + "\n");
                    File.AppendAllText("Logs.txt", ex.StackTrace + "\n");
                    File.AppendAllText("Logs.txt", "==================== \n");
                    throw new CountryMustHaveSingleCapital();
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    File.AppendAllText("Logs.txt",ex.Message + "\n");
                    File.AppendAllText("Logs.txt", ex.StackTrace + "\n");
                    File.AppendAllText("Logs.txt","==================== \n");
                }

            }
        }
        public static Country CountrySearcher(string name)
        {
            for(int i = 0; i < Countries.Count(); i++)
            {
                if (Countries.ElementAt(i).Name.Equals(name))
                {
                    return Countries.ElementAt(i);
                }
            }
            return null;
        }
        public static City CitySearcher(string name)
        {
            for(int i = 0; i < Countries.Count(); i++)
            {
                for(int j = 0; j < Countries.ElementAt(i)._cities.Count(); j++)
                {
                    if (Countries.ElementAt(i)._cities.ElementAt(j).Name.Equals(name))
                    {
                        return Countries.ElementAt(i)._cities.ElementAt(j);
                    }
                }
            }
            return null;
        }
        public static IEnumerable<Country> CountriesGetter()
        {
            string[] lines = File.ReadAllLines("Cities.txt");
            List<string> AlreadyCreatedCountries = new List<string>();
            string temp;
            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Split('|').Length == 5 && !AlreadyCreatedCountries.Contains(lines[i].Split('|')[4]))
                {
                    temp = lines[i].Split('|')[4];
                    AlreadyCreatedCountries.Add(temp);
                    yield return new Country(temp);
                }
            }
        }
    }
}
