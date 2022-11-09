using System;

namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cat catInstance = new Cat();
            Console.Write("Enter name: ");
            catInstance.Name = Console.ReadLine();
            Console.Write("Enter breed: ");
            catInstance.Breed = Console.ReadLine();
            Console.Write("Enter age: ");
            catInstance.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter sex: ");
            catInstance.Sex = Console.ReadLine();
            Console.WriteLine("Cat Object Created");
            Console.WriteLine($"Name: {catInstance.Name} | Breed: {catInstance.Breed} | Age: {catInstance.Age} | Sex: {catInstance.Sex}");
            Console.Write("Enter food wight in grams: ");
            catInstance.Eat(int.Parse(Console.ReadLine()));
            Console.Write("Enter meowing amount: ");
            catInstance.Meow(int.Parse(Console.ReadLine()));
        }
        
    }
}
