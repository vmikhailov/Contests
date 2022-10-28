using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class LongestConsecutives 
    {
        public static string LongestConsec(string[] strarr, int k)
        {
            var l = strarr?.Length ?? 0;
            var max = 0;
            var r = "";
            for (var i = 0; i <= l - k; i++)
            {
                var s = strarr.Skip(i).Take(k).Aggregate((x,r)=>$"{x}{r}");
                var m = s.Length;
                if (m > max)
                {
                    r = s;
                    max = m;
                }
            }

            return r;
        }
    }
}