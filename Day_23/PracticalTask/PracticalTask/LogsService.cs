using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace PracticalTask
{
    public class LogsService
    {
        public static void LogResult(TestTakerUser user)
        {
            File.AppendAllText(TestProgram.LoggsPath, user.ToString() + "\n");
        }
    }
}
