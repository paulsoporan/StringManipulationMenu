using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    public class Program
    {
        public static string str;

        static void Main(string[] args)
        {
            var showMenu = Menu();

            while (showMenu)
            {
                showMenu = Menu();
            }
        }

        private static bool Menu()
        {
            Console.WriteLine("Hi! Please select and option from below:\n" +
                              "1. Write a string to be processed\n" +
                              "2. Enter menu\n" +
                              "3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Please enter yout string below: \n\n");
                    str = Console.ReadLine();
                    Console.Clear();

                    return true;
                case "2":
                    if (String.IsNullOrEmpty(str))
                    {
                        Console.Clear();
                        Console.WriteLine("\nPlease write a string before proceeding\n");
                        return true;
                    }
                    return ShowMenu();
                case "3":
                    Console.Clear();
                    Console.WriteLine("\nGood bye! Have a nice day!\n");
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("\nPlease choose a valid option!\n");
                    return true;
            }
        }

        private static bool ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Reverse a string\n" +
                "2. Count the number of vowels in a string\n" +
                "3. Count the number of words in a string\n" +
                "4. Convert a string to title case\n" +
                "5. Convert a string to uppercase\n" +
                "6. Back");

            switch (Console.ReadLine())
            {
                case "1":
                    ReverseString();
                    return true;
                case "2":
                    CountVowels();
                    return true;
                case "3":
                    CountWords();
                    return true;
                case "4":
                    ConvertToTitleCase();
                    return true;
                case "5":
                    ConvertToUppercase();
                    return true;
                case "6":
                    Console.Clear();
                    return true;
                default :
                    Console.Clear();
                    Console.WriteLine("\nPlease choose a valid option!\n");
                    return true;
            }
        }

        private static void ConvertToTitleCase()
        {
            var textInfo = new CultureInfo("en-us", false).TextInfo;

            str = str.ToLower();
            str = textInfo.ToTitleCase(str);

            Console.Clear();
            Console.WriteLine("\n" + str + "\n");
        }

        private static void CountWords()
        {
            var words = Regex.Matches(str, @"(^|\s+)\w+", RegexOptions.IgnoreCase);
            var finalWord = words.Count() > 1 ? "words" : "word";
            Console.Clear();
            Console.WriteLine($"\nYour string has {words.Count()} {finalWord}\n");
        }

        private static void CountVowels()
        {
            var vowels = Regex.Matches(str, @"[aeioua]", RegexOptions.IgnoreCase);

            Console.Clear();
            Console.WriteLine($"\nYou string has {vowels.Count()} vowels\n");
        }

        private static void ReverseString()
        {
            var stringAsCharArray = str.ToCharArray();
            Array.Reverse(stringAsCharArray);
            str = new string(stringAsCharArray);

            Console.Clear();
            Console.WriteLine("\nYou string reversed is: " + str + "\n");
        }
        private static void ConvertToUppercase()
        {
            Console.Clear();
            Console.WriteLine("\nYour string to Uppercase is: " + str.ToUpper() + "\n");
        }
    }

}