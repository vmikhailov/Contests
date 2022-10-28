using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public class RangeExtraction
    {
        public static string Extract(int[] args)
        {
            var items = new List<string>();
            var gap = 0;
            var start = args[0];
            for(var i = 1; i < args.Length; i++)
            {
                if (args[i] != start + gap + 1)
                {
                    items.Add(ToString(start, gap));
                    start = args[i];
                    gap = 0;
                }
                else
                {
                    gap++;
                }
            }

            items.Add(ToString(start, gap));
            
            return string.Join(",", items);
        }

        private static string ToString(int start, int gap)
        {
            return gap switch
            {
                0 => $"{start}",
                1 => $"{start},{start + gap}",
                _ => $"{start}-{start + gap}"
            };
        }
    }
}