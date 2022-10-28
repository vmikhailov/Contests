using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codewars.Codewars.Passed
{
    public static partial class Kata
    {
        public static string Disemvowel(string str)
        {
            var customVowel = "AEIOU";
            var chars = str.Where(c => !customVowel.Contains(c, StringComparison.InvariantCultureIgnoreCase));

            return new string(chars.ToArray());
        }

        public static string DuplicateEncode(string word)
        {
            var map = word.ToLookup(char.ToUpper)
                          .ToDictionary(x => x.Key, x => x.Count() == 1 ? '(' : ')');

            return new string(word.Select(char.ToUpper).Select(x => map[x]).ToArray());
        }

        public static int CountSmileys(string[] smileys)
        {
            return smileys.Where(IsSmile).Count();
        }

        private static bool IsSmile(string str)
        {
            switch (str?.Length)
            {
                case 2:
                    return (str[0] == ':' || str[0] == ';') &&
                           (str[1] == ')' || str[1] == 'D');

                case 3:
                    return (str[0] == ':' || str[0] == ';') &&
                           (str[1] == '-' || str[1] == '~') &&
                           (str[2] == ')' || str[2] == 'D');
                default:
                    return false;
            }
        }

        public static string ExpandedForm(long num)
        {
            var sums = DigitsAndPower(num)
                       .Where(d => d.Item1 != 0)
                       .Select(d => (d.Item1 * d.Item2).ToString())
                       .ToList();
        
            return string.Join(" + ", sums);
        }

        private static IEnumerable<(long, long)> DigitsAndPower(long n)
        {
            var p = (long)Math.Pow(10, Math.Floor(Math.Log10(n)));
            while (p > 0)
            {
                var d = (n - n % p) / p;

                yield return (d, p);
                n = n - d * p;
                p = p / 10;
            }
        }
    
        
        public static string EncryptThis(string input)
        {
            return string.Join(" ", input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(Encrypt));
        }

        private static string Encrypt(string str)
        {
            var sb = new StringBuilder();
            sb.Append(((int)str[0]).ToString());
            sb.Append(str.Last());
            if(str.Length > 2)
            {
                sb.Append(str[2..^1]);
            }
            if(str.Length > 1)
            {
                sb.Append(str[1]);
            }

            return sb.ToString();
        }
    }
}