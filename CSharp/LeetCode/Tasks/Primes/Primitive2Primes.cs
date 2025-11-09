namespace LeetCode.Tasks;

public class Primitive2Primes
{
    public List<int> Primes { get; private set; } = [];

    public bool IsPrime(int num)
    {
        if (num <= 1)
        {
            return false;
        }

        if (num == 2)
        {
            return true;
        }

        foreach (var p in Primes)
        {
            if (num % p == 0)
            {
                return false;
            }

            if(p * p > num)
            {
                break;
            }
        }

        return true; 
    }

    public int CountPrimes(int n)
    {
        Primes = [2];
        if (n <= 1)
        {
            return 0;
        }

        for (var i = 3; i < n; i++)
        {
            if (IsPrime(i))
            {
                Primes.Add(i);
            }
        }

        return Primes.Count;
    }
}
