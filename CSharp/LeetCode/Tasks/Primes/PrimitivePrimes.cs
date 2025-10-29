namespace LeetCode.Tasks;

public class PrimitivePrimes
{
    public List<int> Primes { get; private set; }

    public static bool IsPrime(int num)
    {
        if (num <= 1) return false; 
        if (num == 2) return true;
        
        for (var i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }

        return true; 
    }

    public int CountPrimes(int n)
    {
        Primes = new() { 2 };
        if (n <= 1) return 0;

        for (var i = 3; i < n; i++)
        {
            if (IsPrime(i)) Primes.Add(i);
        }

        return Primes.Count;
    }
}