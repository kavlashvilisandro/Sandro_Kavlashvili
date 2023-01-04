using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTask
{
    public static class TakeTests
    {
        public delegate void LogginTestResults(TestTakerUser user);
        //Test logging subscribers
        public static event LogginTestResults LoggerSubscribers;
        
        public static void StartTest()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            TestTakerUser User = new TestTakerUser(name);
            StartTest(User);
        }
        public static void StartTest(TestTakerUser user)
        {
            TestProgram.ColorPrinter("=====================", ConsoleColor.Cyan);
            string[] test;
            for(int i = 0; i < TestProgram.TestInstance.Questions.Count; i++)
            {
                test = TestProgram.TestInstance.Questions[i].InputLine.Split('|');
                Console.WriteLine(test[0]);
                for(int j = 0; j < 4; j++)
                {
                    Console.Write(j+1 + ") " + test[j + 1] + "  ");
                }
                Console.Write("\n");
                Console.Write("Enter correct index: ");
                try
                {
                    int option = int.Parse(Console.ReadLine());
                    if(option == TestProgram.TestInstance.Questions[i].CorrectAnswer)
                    {
                        user.CorrectAnswersCounter++;
                        TestProgram.ColorPrinter($"your point: {user.CorrectAnswersCounter}",ConsoleColor.Green);
                    }
                    else
                    {

                        TestProgram.ColorPrinter($"your point: {user.CorrectAnswersCounter}", ConsoleColor.Red);
                    }
                }catch(Exception e)
                {
                    TestProgram.ColorPrinter(e.Message, ConsoleColor.Red);
                    return;
                }
            }
            OnTestFinished(user);
            TestProgram.ColorPrinter("=====================", ConsoleColor.Cyan);
        }

        public static void OnTestFinished(TestTakerUser user)
        {
            LoggerSubscribers.Invoke(user);
        }
    }
}
