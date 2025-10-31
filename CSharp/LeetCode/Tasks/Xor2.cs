namespace LeetCode.Tasks;

public class Xor2
{
    public static (int, int) FindUniqueNumbers(int[] arr)
    {
        var xor = 0;
        foreach (var num in arr)
        {
            xor ^= num;
        }

        var diff = xor & -xor;

        var n1 = 0;
        var n2 = 0;
        foreach (var num in arr)
        {
            if ((num & diff) != 0)
            {
                n1 ^= num;
            }
            else
            {
                n2 ^= num;
            }
        }

        return (n1, n2);
    }
}