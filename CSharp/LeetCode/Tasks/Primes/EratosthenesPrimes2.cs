namespace LeetCode.Tasks;

public class EratosthenesPrimes2
{
    public List<int> Primes { get; private set; }

    public int CountPrimes(int n)
    {
        var estimatedCount = (int)(n / (Math.Log(n) - 1.5));
        Primes = new(estimatedCount);

        if (n <= 2)
        {
            return 0;
        }

        var marks = new bool[n];

        var c = 1;

        for (var k = 2; k < n; k++)
        {
            if (marks[k])
            {
                continue;
            }

            for (var m = 2 * k ; m < n; m += k)
            {
                marks[m] = true;
            }

            Primes.Add(k);
            c++;
        }

        return c;
    }
}