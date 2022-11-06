using System;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            isPalindrome("aaaaabbaaaa");
        }

        public static void isPalindrome(string text)
        {
            bool answer = Palindrome(text,0,text.Length-1);
            if (answer)
            {
                Console.WriteLine($"\"{text}\" is Palindrome");
            }
            else
            {

                Console.WriteLine($"\"{text}\" is not Palindrome");
            }
        }

        public static bool Palindrome(string text, int startIndex, int endIndex)
        {
            if(text[startIndex] != text[endIndex])
            {
                return false;
            }
            else
            {
                if (startIndex > endIndex)
                {
                    return true;
                }
                else
                {
                    return Palindrome(text, startIndex + 1, endIndex - 1);
                }
            } 
        }
    }
}
