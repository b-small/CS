using System;
using System.Linq;

namespace _7._97_CountWord
{
    class CountWord
    {
        static void Main(string[] args)
        {
            try
            {
                
               // Console.WriteLine("Enter your text: ");
               // string input = Console.ReadLine();
               
                string input = "Hidden networks say “Hi” only to Hitachi devices. Hi, said Matuhi. HI!";
                string[] wordsArr = input.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '/', '@', '(', ')', '#', '”',
                '“'}, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("Enter the word: ");
                string myWord = Console.ReadLine();

                var matchQuery = from word in wordsArr
                                 where word.ToLowerInvariant() == myWord.ToLowerInvariant()
                                 select word;
                int counter = matchQuery.Count();

                Console.WriteLine("{0} \t {1} times", myWord, counter);
            }

            catch (Exception)
            {
                Console.WriteLine("Wrong input! Try again.");
            }
        }
    }
}
