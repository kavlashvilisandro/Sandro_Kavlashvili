using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTasks
{
    public class Cat
    {
        //Fields
        private int age;
        private int eatingLimit = 10;
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        
        //Properties
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }
        public void Meow(int meowingAmount)
        {
            for(int i = 0; i < meowingAmount; i++)
            {
                Console.WriteLine("Meowing ....");
            }
        }

        public void Eat(double Grams)
        {
            for(int i = 0; i < (int)Grams/10; i++)
            {
                Console.WriteLine("Eating...");
            }
            if(Grams % 10 != 0)
            {
                Console.WriteLine("Eating...");
            }
        }

    }
}
