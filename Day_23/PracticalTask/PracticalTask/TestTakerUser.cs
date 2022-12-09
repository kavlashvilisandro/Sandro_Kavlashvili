using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTask
{
    public class TestTakerUser
    {
        public int CorrectAnswersCounter = 0;
        public string Name { get; private set; }
        public TestTakerUser(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name + " - " + this.CorrectAnswersCounter;
        }
    }
}
