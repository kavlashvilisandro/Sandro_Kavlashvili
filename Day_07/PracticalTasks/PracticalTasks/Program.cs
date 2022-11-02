using System;
using System.Text;

namespace PracticalTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.WriteLine($"amount of vowels: {VowelCounter(word)} | amount of consonants: {VowelCounter(word,'s')}");
            Console.WriteLine($"Vowels: {vowelPrinter(word)} | Consonants: {vowelPrinter(word,'s')}");
            //===

            RedBorderPrinter();

            //Task2
            Console.Write("Enter word to reverse it: ");
            string word2 = Console.ReadLine();
            Console.WriteLine($"Reversed word is: {Reverser(word2)}");
            //===

            RedBorderPrinter();

            //Task3 (მაგალითში upperCase ში იყო დაბეჭდილი, ამიტომ აქაც აფერქეისში წერია)
            Console.Write("Enter word to print with spaces: ");
            string word3 = Console.ReadLine();
            Console.WriteLine($"Spaced word: {SpaceAdder(word3)}");
            //===

            RedBorderPrinter();

            //Task4
            Console.Write("Enter sentence to count amount of words: ");
            string text4 = Console.ReadLine();
            AmountPrinter(WordsCounter(text4));
            //===

            RedBorderPrinter();

            //Task5
            Console.Write("Enter sentence: ");
            string text5 = Console.ReadLine();
            int amountOfLetters = 0;
            int amountOfNumbers = 0;
            int otherSymbols = TextAnalizer(text5, out amountOfLetters, out amountOfNumbers);
            Task5Resultprinter(text5, amountOfLetters, amountOfNumbers, otherSymbols);
            //===


        }
        public static void Task5Resultprinter(string text,int amountOfLetters, int amountOfNumbers, int otherSymbols)
        {
            Console.WriteLine($"{text} -> letters: {amountOfLetters}, numbers: {amountOfNumbers}, other symbols: {otherSymbols}");
        }
        /*
         this method counts amount of letters, amount of numbers and amount 
        of other symbols in the string 
         */
        public static int TextAnalizer(string text, out int lettersAmount, out int numbersAmount)
        {
            int ParsedInteger = 0;
            numbersAmount = 0;
            lettersAmount = VowelCounter(text) + VowelCounter(text, 's');//this is sum of vowels and consonants
            for(int i = 0; i < text.Length; i++)
            {
                if(int.TryParse(text[i].ToString(), out ParsedInteger))
                {
                    numbersAmount++;
                }
            }
            return text.Length - numbersAmount - lettersAmount;//returns other symbols amount
        }
        public static void AmountPrinter(int number)
        {
            Console.WriteLine($"amount of words is: {number}");
        }
        /*
         returns amount of words in the text
         */
        public static int WordsCounter(string text)
        {
            return text.Split(' ').Length;
        }

        /*
         This method prints text in upper case and with extra spaces
         */
        public static string SpaceAdder(string text)
        {
            string result = string.Empty;
            for(int i = 0; i < text.Length; i++)
            {
                result = result + text[i].ToString().ToUpper() + ' ';
            }
            return result;
        }
        public static string Reverser(string text)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = text.Length-1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }
            return sb.ToString();
        }
        /*
         this method returns amount of vowels in Text if baseChar is vowel and
        if baseChar is not vowel, it returns amount of consonant in Text
        default value of baseChar is vowel
         */
        public static int VowelCounter(string Text, char baseChar = 'a')
        {
            int counter = 0;
            string Vowels = "aeiouy";
            if (Vowels.Contains(baseChar))
            {
                for(int i = 0; i < Text.Length; i++)
                {
                    if (Vowels.Contains(Text[i])) counter++;
                }
                return counter;
            }
            for(int i = 0; i < Text.Length; i++)
            {
                //ascii codes are checked here if character is from alphabet table
                if (!Vowels.Contains(Text[i]) && (((int)Text[i] >= 97 && (int)Text[i] <= 122) ||((int)Text[i] >= 65 && (int)Text[i] <= 90))) 
                    counter++;
            }
            return counter;
        }
        /*
         this method prints Vowels from text if baseChar is vowel and if it
        is no vowel, it prints all consonants,  default value of baseChar is Vowel
         */
        public static string vowelPrinter(string text, char baseChar = 'a')
        {
            StringBuilder result = new StringBuilder();
            string Vowels = "aeiouy";
            if (Vowels.Contains(baseChar))
            {
                for(int i = 0; i < text.Length; i++)
                {
                    if (Vowels.Contains(text[i]))
                    {
                        result.Append(text[i]);
                        result.Append(' ');
                    }
                }
                return result.ToString();
            }
            for(int i = 0; i < text.Length; i++)
            {
                if (!Vowels.Contains(text[i]) && (((int)text[i] >= 97 && (int)text[i] <= 122) || ((int)text[i] >= 65 && (int)text[i] <= 90)))
                {
                    result.Append(text[i]);
                    result.Append(' ');
                }
            }
            return result.ToString();
        }

        //This method prints red border between tasks
        public static void RedBorderPrinter()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
