using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;


namespace TestConsoleApplication
{
    public class HelperInstance
    {
        public int Index { get; set; }
        public HelperInstance(int index)
        {
            this.Index = index;
        }
    }
    class Program
    {
        public static Dictionary<int, bool> TableOfStartedThreads;
        public static void Threader(Object MyObj)
        {
            if (MyObj is HelperInstance)
            {
                HelperInstance x = (HelperInstance)MyObj;
                int index = x.Index;
                if (!File.Exists($"Task{index}.txt"))
                {
                    File.Create($"Task{index}.txt").Close();
                }
                while (TableOfStartedThreads[index])
                {
                    File.AppendAllText($"Task{index}.txt", $"Task{index}");
                    Thread.Sleep(index * 100);
                }
            }
        }
        public static void Main(string[] args)
        {
            TableOfStartedThreads = new Dictionary<int, bool>();
            ParameterizedThreadStart ThreadDelegate;
            Thread thread;
            for (int i = 0; i < 10; i++)
            {
                ThreadDelegate = new ParameterizedThreadStart(Threader);
                thread = new Thread(ThreadDelegate);
                thread.IsBackground = true;
                thread.Start(new HelperInstance(i));
                TableOfStartedThreads.Add(i, true);
            }


            string input;
            int index;
            while (true)
            {
                Console.Write("Which thread should be stopped: ");
                input = Console.ReadLine();
                if (input.Equals("exit"))
                {
                    break;
                }
                index = int.Parse(input);
                TableOfStartedThreads[index] = false;
            }
        }
    }
}