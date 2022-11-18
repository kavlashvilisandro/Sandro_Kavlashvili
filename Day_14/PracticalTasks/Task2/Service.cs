using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public static class Service
    {
        public static void BuyingOptions()
        {
            Vehicle vehicle = null;
            Console.WriteLine("Enter number(which type of transport do you want): ");
            Console.WriteLine("1) Fighter  2) Public transport");
            Console.WriteLine("3) Customer transport");
            Console.Write("Enter your option's number: ");
            int option1 = int.Parse(Console.ReadLine());
            vehicle = BuyingOptions(option1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your Data: ");
            Console.ForegroundColor= ConsoleColor.White;
            vehicle.PrintAllData();
            vehicle.Move(3);
            vehicle.PrintAllData();
        }
        public static Vehicle BuyingOptions(int option1)
        {
            int option2;
            switch (option1)
            {
                case 1:
                    Console.WriteLine("1)Tank  2)BTR");
                    option2 = int.Parse(Console.ReadLine());
                    return BuyingOptions(option1, option2);
                case 2:
                    Console.Write("1)Bus   2)Traumay");
                    option2 = int.Parse(Console.ReadLine());
                    return BuyingOptions(option1, option2);
                    
                case 3:
                    Console.WriteLine("1)Car   2)Moto");
                    option2 = int.Parse(Console.ReadLine());
                    return BuyingOptions(option1, option2);
                    
                default:
                    return null;
            }
        }
        public static Vehicle BuyingOptions(int option1, int option2)
        {
            switch(option1, option2)
            {
                case (1, 1):
                    Console.Write("amount of bullets: ");
                    int bullets = int.Parse(Console.ReadLine());
                    Console.Write("amount of armour: ");
                    int armour = int.Parse(Console.ReadLine());
                    return new Tank(armour, bullets);
                    
                case (1, 2):
                    Console.Write("amount of bullets: ");
                    bullets = int.Parse(Console.ReadLine());
                    Console.Write("amount of armour: ");
                    armour = int.Parse(Console.ReadLine());
                    return new BTR(armour, bullets);
                    
                case (2, 1):
                    Console.Write("Enter amount of people capacity: ");
                    int Capacity = int.Parse(Console.ReadLine());
                    return new Bus(Capacity);
                    
                case (2, 2):
                    Console.Write("Enter amount of people capacity: ");
                    Capacity = int.Parse(Console.ReadLine());
                    return new Traumay(Capacity);
                    
                case (3, 1):
                    CarMark mark = ChoseCarMark();
                    Console.Write("Enter true or false if car has winter tiers: ");
                    bool hasWinterTiers = bool.Parse(Console.ReadLine());
                    return new Car(hasWinterTiers,mark);
                    
                case (3, 2):
                    mark = ChoseCarMark();
                    Console.Write("Enter true or false if car has winter tiers: ");
                    hasWinterTiers = bool.Parse(Console.ReadLine());
                    return new Moto(hasWinterTiers, mark);
                default:
                    return null;
            }
        }
        public static CarMark ChoseCarMark()
        {
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}){(Cars)i} ");
            }
            Console.Write("Chose car mark's index: ");
            int index = int.Parse(Console.ReadLine());
            return (CarMark)((Cars)(index - 1));

        }

    }
}
