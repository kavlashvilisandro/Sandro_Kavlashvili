using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTask
{
    public class Question
    {
        public int CorrectAnswer { get; set; }
        private string _inputedLine;
        public string InputLine
        {
            get
            {
                return _inputedLine;
            }
        }
        public Question(string line,int CorrectAnswer)
        {
            this._inputedLine = line;
            this.CorrectAnswer = CorrectAnswer;
        }

    }
}
