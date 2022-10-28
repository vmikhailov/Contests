using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class RailFenceCipher
    {
        public static string Encode(string s, int n)
        {
            return new string(EncodeImpl(s.ToCharArray(), n));
        }
        
        public static string Decode(string s, int n)
        {
            var encoded = EncodeImpl(Enumerable.Range(0, s.Length).ToArray(), n);
            var map = encoded.Select((x, i) => new { x, i }).ToDictionary(x => x.x, x => x.i);
            var decoded = Enumerable.Range(0, s.Length).Select(i => s[map[i]]).ToArray();
            return new string(decoded);
        }
        
        private static T[] EncodeImpl<T>(T[] items, int n)
        {
            var indices = Enumerable.Range(0, n).Concat(Enumerable.Range(2, n - 2).Select(x => n - x)).ToArray();
            var m = indices.Length;
            var list = new List<T>[n];
            for (var i = 0; i < n; i++) list[i] = new List<T>();
            for (var i = 0; i < items.Length; i++)
            {
                var p = indices[i % m];
                list[p].Add(items[i]);
            }

            return list.SelectMany(x => x).ToArray();
        }
        

    }
}