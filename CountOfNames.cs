using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._93_CountOfNames
{
    class CountOfNames
    {
        static void Main(string[] args)
        {
            try
            {

                List<string> names = new List<string>();
                int counter = 1;

                Console.WriteLine("Enter the names, separated by a space: ");
                string input = Console.ReadLine();
                string[] namesArr = input.Split(' '.ToString().ToCharArray(),
                                                StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < namesArr.Length; i++)
                {
                    names.Add(namesArr[i]);
                }

                names.Sort();

                for (int i = 1; i < names.Count; i++)
                {
                    if (names[i].Equals(names[i - 1]))
                    {
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine("{0}\t{1}", names[i - 1], counter);
                        counter = 1;
                    }

                    if (i == names.Count - 1)
                    {
                        Console.WriteLine("{0}\t{1}", names[i], counter);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
            }
        }
    }
}
