using System;
using System.Text.RegularExpressions;

namespace _7._96_ExtractURLs
{
    class ExtractURL
    {
        static void Main(string[] args)
        {
            // I. way
            /*
            string rawString = "The site nakov.com can be access from http://nakov.com" +
            " or www.nakov.com. It has subdomains like mail.nakov.com and svetlin.nakov.com." +
                "Please check http://blog.nakov.com for more information.";
            var links = rawString.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s.StartsWith("http://") || s.StartsWith("www."));

            foreach (string url in links)
            {
                Console.WriteLine(url);
            }
             */

            // II. way

            Regex linkParser = new Regex(@"\b(?:http://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string rawString = "The site nakov.com can be access from http://nakov.com" +
            " or www.nakov.com. It has subdomains like mail.nakov.com and svetlin.nakov.com." +
                "Please check http://blog.nakov.com for more information.";

            foreach (Match m in linkParser.Matches(rawString))
            {
                Console.WriteLine(m.Value);
            }
        }
    }
}
