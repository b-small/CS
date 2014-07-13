using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._95_LongestWord
{
    class LongestWord
    {
        static void Main(string[] args)
        {
            try
            {
                string largest = " ";

                Console.WriteLine("Input: ");
                string input = Console.ReadLine();
                string[] wordsArr = input.Split(' '.ToString().ToCharArray(),
                                                StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < wordsArr.Length; i++)
                {
                    if (wordsArr[i].Length > largest.Length)
                    {
                        largest = wordsArr[i];
                    }
                }
                Console.WriteLine(largest);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input! Try again.");
            }
        }
    }
}
