using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PracticalTask
{
    public class Tests
    {
        public static Question LastAddedTest;

        public delegate void QuestionSignature(Question obj);
        //NewTestsSubscribers is subscribed by TestsAdderService
        public event QuestionSignature NewTestsSubscribers;

        public List<Question> Questions;
        public Tests()
        {
            this.Questions = new List<Question>();
            StreamReader reader = new StreamReader(TestProgram.TestsPath);
            string line = reader.ReadLine();
            while(line != null)
            {
                this.Questions.Add(new Question(line,int.Parse(line.Split('|')[line.Split('|').Length - 1])));
                line = reader.ReadLine();
            }
            reader.Close();
        }
        public void AddNewQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Question: ");
            string Question = Console.ReadLine();
            string savaraudoAnswers = "";
            for(int i = 0; i < 4; i++)
            {
                Console.Write($"Enter savaraudo answer {i + 1}: ");
                savaraudoAnswers = savaraudoAnswers + Console.ReadLine() + "|";
            }
            int CorrectIndex = 0;
            try
            {
                Console.Write("Enter index of correct answer: ");
                CorrectIndex = int.Parse(Console.ReadLine());
                if(CorrectIndex <= 0 || CorrectIndex > 4)
                {
                    throw new Exception("Correct Index is out of range");
                }
                savaraudoAnswers += CorrectIndex;
            }catch(Exception ex)
            {
                TestProgram.ColorPrinter(ex.Message, ConsoleColor.Red);
                return;
            }
            LastAddedTest = new Question(Question + "|" + savaraudoAnswers,CorrectIndex);
            Console.ForegroundColor= ConsoleColor.Gray;  
            OnAddedNewQuestion(LastAddedTest);
        }

        public void OnAddedNewQuestion(Question questionObj)
        {
            this.NewTestsSubscribers.Invoke(questionObj);
            TestProgram.ColorPrinter("TestAdded Successfully", ConsoleColor.Green);
        }
    }
}
