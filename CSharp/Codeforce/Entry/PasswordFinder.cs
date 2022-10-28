using System;

namespace Codewars.Entry
{
    public static class PasswordFinder
    {
        public static string FindPassword(string chars, string allowedChars, int maxLen)
        {
            string password = null;
            var minLen = allowedChars.Length;
            var i = chars.Length - 1;
            var j = i;
            var allowed = new bool[26];
            var used = new int[26];

            foreach (var c in allowedChars) allowed[c - 'a'] = true;
            
            while(i >= 0)
            {
                var c = chars[i] - 'a';
                if (!allowed[c])
                {
                    i--;
                    j = i;
                    Array.Clear(used, 0, 26);
                    continue;
                }

                used[c]++;

                var l = j - i + 1;
                
                if (l > maxLen)
                {
                    c = chars[j] - 'a';
                    used[c]--;
                    j--;
                    l--;
                }
                
                if (l >= minLen && AllUsed(allowed, used, minLen))
                {
                    return chars.Substring(i, l);
                }
                i--;
            }

            return password ?? "-1";        
        }

        private static bool AllUsed(bool[] allowed, int[] used, int len)
        {
            for (var i = 0; i < 26 && len > 0; i++)
            {
                if (allowed[i] ^ (used[i] > 0))
                {
                    return false;
                }

                if (allowed[i]) len--;
            }

            return true;
        }

        public static void Main1()
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());
            
            Console.WriteLine(FindPassword(s1, s2, n));
        }
    }
}