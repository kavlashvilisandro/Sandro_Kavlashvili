using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception shida1 = new Exception("hello5");
            Exception shida2 = new Exception("hello4", shida1);
            Exception shida3 = new Exception("hello3", shida2);
            Exception shida4 = new Exception("hello2", shida3);
            ExceptionsLinkedList ex = new ExceptionsLinkedList("hello1", shida4);
            Console.WriteLine(ex.GetLastInnerExMessage());
            Console.WriteLine("===============");
            Console.WriteLine(ex.GetAllInnerExMessageTogether());
        }
    }
}
