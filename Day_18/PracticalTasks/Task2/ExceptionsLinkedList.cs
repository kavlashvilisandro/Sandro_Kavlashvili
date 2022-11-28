using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class ExceptionsLinkedList : Exception
    {
        public ExceptionsLinkedList(string messagee,Exception ex) : base(messagee,ex)
        {

        }
        public string GetLastInnerExMessage()
        {
            Exception ex = InnerException;
            while(ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }
        public string GetAllInnerExMessageTogether()
        {
            string result = "";
            Exception ex2 = this;
            while(ex2 != null)
            {
                result = result + ex2.Message + "\n";
                ex2 = ex2.InnerException;
            }
            return result;
        }
    }
}
