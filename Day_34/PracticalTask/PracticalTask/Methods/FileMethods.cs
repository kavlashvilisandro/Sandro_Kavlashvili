namespace PracticalTask.Methods
{
    public static class FileMethods
    {
        public static void CreateTextFiles()
        {
            if (!File.Exists("Errors.txt"))
            {
                File.Create("Errors.txt").Close();
            }
        }
    }
}
