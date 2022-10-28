using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Codewars.Passed
{
    public class DirReduction {
  
        public static string[] dirReduc(String[] arr)
        {
            var d = new Dictionary<string, int>()
            {
                { "NORTH", 0 },
                { "SOUTH", 180 },
                { "EAST", 90 },
                { "WEST", 270 }
            };

            var turns = arr.Select(x => d[x.ToUpper()]).ToList();
            for (var reduced = true; reduced; )
            {
                reduced = false;
                for (var i = 0; i < turns.Count - 1; i++)
                {
                    if ((turns[i] + turns[i + 1]) % 180 == 0 & (turns[i] != turns[i + 1]) )
                    {
                        turns.RemoveAt(i + 1);
                        turns.RemoveAt(i);
                        reduced = true;

                        break;
                    }
                }
            }

            var result = turns.Select(x => d.First(y => y.Value == x).Key).ToArray();

            return result;
        }
    }
}