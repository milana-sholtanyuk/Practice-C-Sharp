using System;
using System.Text.RegularExpressions;

namespace z9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "apple, banana, apricot, cherry, avocado";
            char letter = 'a';
            var matches = Regex.Matches(text, $@"\b{letter}\w+", RegexOptions.IgnoreCase);
            foreach (Match m in matches)
                Console.WriteLine(m.Value);
        }
    }
}
