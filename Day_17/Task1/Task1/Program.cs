using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Task1
{
    public class CompareKeys : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length)
            {
                return 0;
            }
            else if (x.Length > y.Length)
            {
                return 1;
            }
            else 
            {
                return -1;
            }
        }
    }
    public class Program
    { 
        static void Main(string[] args)
        {
            Random rg = new Random();
            List<int> Data = new List<int>();   
            for(int i = 0; i < 10; i++)
            {
                Data.Add(rg.Next(0,100));
            }
            for(int i = 0; i < Data.Count; i++)
            {
                Console.Write(Data[i] + " | ");
            }
            Console.WriteLine();
            Data.Sort();
            for (int i = 0; i < Data.Count; i++)
            {
                Console.Write(Data[i] + " | ");
            }
            Console.WriteLine();
            Data.Reverse();
            for (int i = 0; i < Data.Count; i++)
            {
                Console.Write(Data[i] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine(Data.Max());
            Console.WriteLine(Data.Min());
            Data.RemoveAt(0);
            for (int i = 0; i < Data.Count; i++)
            {
                Console.Write(Data[i] + " | ");
            }
            Console.WriteLine();
            Data.Sort();
            Console.WriteLine(Data.BinarySearch(3));
            int[] Array = Data.ToArray();
            Data.Clear();
            Console.WriteLine(Data.Count);

            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i] + " | ");
            }
            Console.WriteLine();
            IEnumerable<int> Raghac2 = Array;
            for(int i  = 0; i < Raghac2.Count(); i++)
            {
                Console.Write(Raghac2.ElementAt(i) + " | ");
            }
            Console.WriteLine();

            List<int> SomeData = Raghac2.ToList();
            for (int i = 0; i < SomeData.Count; i++)
            {
                Console.Write(SomeData[i] + " | ");
            }
            Console.WriteLine();
            Dictionary<int,string> keyValuePairs = new Dictionary<int,string>();
            KeyValuePair<int, string> Added;
            for(int i = 0; i < 10; i++)
            {
                Added = new KeyValuePair<int, string>(i, $"text{i}");
                keyValuePairs.Add(Added.Key,Added.Value);
            }
            for(int i = 0; i < keyValuePairs.Count; i++)
            {
                Console.WriteLine(keyValuePairs.ElementAt(i));
            }
            int key;
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                key = i;
                Console.WriteLine(keyValuePairs[key]);
            }
            
            string data = "";
            Console.WriteLine(keyValuePairs.TryGetValue(2, out data));
            Console.WriteLine(data);
            Console.WriteLine(keyValuePairs.TryGetValue(20, out data));
            Console.WriteLine(data);
            IEnumerable<KeyValuePair<int, string>> IDict = keyValuePairs;
            for(int i = 0; i < IDict.Count(); i++)
            {
                Console.WriteLine(IDict.ElementAt(i));
            }
            Stack<int> stackData = new Stack<int>();

            for(int i = 0; i < 10; i++)
            {
                stackData.Push(rg.Next(0, 100));
            }
            stackData.Push(1);
            for(int i = 0; i < stackData.Count; i++)
            {
                Console.Write(stackData.ElementAt(i) + " | ");
            }
            Console.WriteLine();
            int popped = 0;
            Console.WriteLine(stackData.TryPop(out popped));
            Console.WriteLine(popped);
            for (int i = 0; i < stackData.Count; i++)
            {
                Console.Write(stackData.Pop() + " | ");
            }
            Console.WriteLine();
            popped = 0;
            Console.WriteLine(stackData.TryPop(out popped));
            Console.WriteLine(popped);

            Tuple<int, int, string> dataT = new Tuple<int, int, string>(1,1,":");

            (int, int, string) dataT2 = (1, 1, ":");
            dataT2.Item1 = 12;

            IComparer<string> Comparer = new CompareKeys();
            SortedList<string, string> SortedData = new SortedList<string, string>(Comparer);
            SortedData.Add("AEEEEEE", "text1");
            SortedData.Add("AEEE", "text2");
            SortedData.Add("AEE", "text3");
            SortedData.Add("AEEEE", "text4");
            for(int i = 0; i < SortedData.Count; i++)
            {
                Console.WriteLine(SortedData.ElementAt(i));
            }


        }
    }
}
