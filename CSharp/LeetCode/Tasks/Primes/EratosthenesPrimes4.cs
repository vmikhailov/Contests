namespace LeetCode.Tasks;

public class EratosthenesPrimes4
{
    public List<int>? Primes { get; private set; }

    public int CountPrimes(int n)
    {
        var estimatedCount = (int)(n / (Math.Log(n) - 1.5));
        Primes = new(estimatedCount) { 2 };

        if (n <= 2)
        {
            return 0;
        }

        var block = 15_000_000;
        
        var n2 = n / 2;
        //var marks = new BitArray(n2);
        var nb = (n2 - 1) / block + 1;
        var marks = new bool[nb][];

        for (var i = 0; i < nb; i++)
        {
            marks[i] = new bool[block];
        }

        var c = 1;

        for (var k = 1; k < n2; k++)
        {
            if (marks[k/block][k % block])
            {
                continue;
            }

            var k1 = 2 * k + 1;
            var k2 = 2 * k * k;

            for (var i = k + 1;; i++)
            {
                var v = i * k1 - k2;

                if (v < 0 || v >= n2)
                {
                    break;
                }

                //Console.WriteLine($"{v/block} {v % block}");
                marks[v/block][v % block] = true;
            }

            Primes.Add(2 * k + 1);
            c++;
        }

        return c;
    }
}
