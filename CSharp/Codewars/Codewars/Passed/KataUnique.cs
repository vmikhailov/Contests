using System.Collections.Generic;

namespace Codewars.Codewars.Passed
{
    public static class KataUnique
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) 
        {
            T y = default;
            foreach (var x in iterable)
            {
                if (x.Equals(y)) continue;
                y = x;

                yield return x;
            }
        }
    }
}