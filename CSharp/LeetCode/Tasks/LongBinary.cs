using System.Numerics;

namespace LeetCode.Tasks;

public class LongBinary
{
    public int ConcatenatedBinary(int n)
    {
        BigInteger b = 0;
        for (var i = 1; i <= n; i++)
        {
            var c = (int)Math.Log2(i) + 1; 
            b <<= c;
            b += i;
        }
        
        var r = b % 1000000007;
        return (int)r;
    }
}