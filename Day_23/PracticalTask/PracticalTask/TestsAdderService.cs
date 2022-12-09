using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PracticalTask
{
    public static class TestsAdderService
    {
        public static void AddNewTest(Question question)
        {
            File.AppendAllText(TestProgram.TestsPath,question.InputLine + "\n");
        }
        public static void AddNewTestInRunTime(Question obj)
        {
            TestProgram.TestInstance.Questions.Add(obj);
        }
    }
}
