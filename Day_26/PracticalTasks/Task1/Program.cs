using System;
using System.Linq;
using System.Collections.Generic;

namespace Task1
{
    public static class CustomMethods
    {
        public static bool CustomAny<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                return false;
            }
            return true;
        }
        public static bool CustomAny<T>(this IEnumerable<T> Collection,Func<T,bool> del)
        {
            foreach(T item in Collection)
            {
                if(del.Invoke(item) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CustomAll<T>(this IEnumerable<T> Collection,Func<T,bool> del)
        {
            foreach(T item in Collection)
            {
                if(del.Invoke(item) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //All და Any-ს გამოყენებები
            List<string> texts = new List<string>()
            {
                "awdas","awaWDWWDSA","awdads","Wdas",
            };
            List<int> numbers = new List<int>()
            {
                3,5,6,21,235,6,2,36,12,6,
            };
            List<int> numbersEmpty = new List<int>();
            Console.WriteLine(numbersEmpty.Any());//false
            Console.WriteLine(texts.Any());//true
            Console.WriteLine(texts.Any((x) => x.Length > 15));//false
            Console.WriteLine(texts.Any((x) => x.Length > 9));//true
            //=====
            Console.WriteLine(numbers.All((x) => x > 9));//false
            Console.WriteLine(texts.All((x) => x.Length > 9));//false
            Console.WriteLine(texts.All((x) => x.Length >= 4));//true
            //Custom All and any
            Console.WriteLine("=====================");
            Console.WriteLine(numbersEmpty.CustomAny());//false
            Console.WriteLine(texts.CustomAny());//true
            Console.WriteLine(texts.CustomAny((x) => x.Length > 15));//false
            Console.WriteLine(texts.CustomAny((x) => x.Length > 9));//true
            //=====
            Console.WriteLine(numbers.CustomAll((x) => x > 9));//false
            Console.WriteLine(texts.CustomAll((x) => x.Length > 9));//false
            Console.WriteLine(texts.CustomAll((x) => x.Length >= 4));//true

            Console.WriteLine("==========");
            //Any-ის ჩანაცვლება All-ით
            //1)
            Console.WriteLine(numbers.All((x) => x > 3));//ეს იგივეა,რაც:
            Console.WriteLine(!numbers.Any((x) => x <= 3));
            //All-ის ჩანაცვლება Any-ით
            //1)
            Console.WriteLine(numbers.Any((x) => x > 3));//ეს იგივეა,რაც:
            Console.WriteLine(!numbers.All((x) => x <= 3));
        }

    }
}
