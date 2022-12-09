using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTask
{
    public class TestProgram
    {
        public static string TestsPath = @"D:\Repo\Day_23\PracticalTask\PracticalTask\Tests.txt";
        public static string LoggsPath = @"D:\Repo\Day_23\PracticalTask\PracticalTask\Logs.txt";
        public static Tests TestInstance = new Tests();
        public static bool ProgramIsOn = true;
        public static void TestsApplication()
        {
            //Subscribing new tests events
            TestInstance.NewTestsSubscribers += TestsAdderService.AddNewTest;
            TestInstance.NewTestsSubscribers += TestsAdderService.AddNewTestInRunTime;
            //Subscribin new loggers
            TakeTests.LoggerSubscribers += LogsService.LogResult;



            Console.Write("1) Start test| 2) Add Questions| 3) exit: ");
            try
            {
                int option = int.Parse(Console.ReadLine());
                if(option == 1)
                {
                    TakeTests.StartTest();
                }else if(option == 2)
                {
                    TestInstance.AddNewQuestion();
                }else if(option == 3)
                {
                    ColorPrinter("Program finished", ConsoleColor.Red);
                    ProgramIsOn = false;
                }
                else
                {
                    ColorPrinter("invalid input",ConsoleColor.Red);
                    return;
                }
            }
            catch (Exception ex)
            {
                ColorPrinter(ex.Message,ConsoleColor.Red);
                return;
            }
        }

        public static void ColorPrinter(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
