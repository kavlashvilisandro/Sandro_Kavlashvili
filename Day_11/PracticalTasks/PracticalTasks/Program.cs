using System;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] Persons = new Person[3];
            Home GeneralHomeInstance;
            for(int i = 0; i < Persons.Length; i++)
            {
                GeneralHomeInstance = new Home();
                Persons[i] = new Person();
                Console.Write("Enter Address: ");
                GeneralHomeInstance.Address = Console.ReadLine();//inputt 1i
                Console.Write("Enter City: ");
                GeneralHomeInstance.City = Console.ReadLine();//input 2i
                Console.Write("Enter Name: ");
                Persons[i].Name = Console.ReadLine();//input 3i
                Console.Write("Enter Age: ");
                Persons[i].Age = int.Parse(Console.ReadLine());//input 4i
                Console.Write("Enter personal id number: ");
                Persons[i].PersonalIdNumber = Console.ReadLine();//input 5i
                Persons[i].Home = GeneralHomeInstance;
            }


            for(int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Persons at index " + i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Name: {Persons[i].Name}");
                Console.WriteLine($"Age: {Persons[i].Age}");
                Console.WriteLine($"Personal Id: {Persons[i].PersonalIdNumber}");
                Console.WriteLine($"Address {Persons[i].Home.Address}");
                Console.WriteLine($"City: {Persons[i].Home.City}");
                Console.WriteLine();
            }
        }

    }
}
