namespace LeetCode.Tasks;

public class Sq2
{
    public int countTriples(int n)
    {
        int count = 0;
        for (var a = 1; a <= n; a++)
        {
            for (var b = 1; b <= n; b++)
            {
                var c2 = a * a + b * b;
                var c = (int)Math.Sqrt(c2);
                if (c2 == c * c)
                {
                    Console.WriteLine($"{a}^2 + {b}^2 = {c}^2");
                    count++;
                }
            }
        }

        return count;
    }
}