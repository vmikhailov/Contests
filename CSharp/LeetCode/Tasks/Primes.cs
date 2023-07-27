using System.Collections;

namespace LeetCode.Tasks;

public class Primes
{
    public int CountPrimes(int n)
    {
        if (n <= 2) return 0;
        var n2 = n / 2;
        var marks = new BitArray(n2);

        var c = 1;

        for (var k = 1; k < n2; k++)
        {
            if (marks[k]) continue;
            
            var k1 = 2 * k + 1;
            var k2 = 2 * k * k;

            for (var i = k + 1;; i++)
            {
                var v = i * k1 - k2;

                if (v >= n2) break;
                marks[v] = true;
            }

            c++;
        }

        return c;
    }
}