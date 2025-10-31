namespace LeetCode.Tasks;

public class ReverseIntTask
{
    public int Reverse(int x)
    {
        var y = 0;
        while (x != 0)
        {
            var d = x % 10;

            if (x > 0 && y > (int.MaxValue - d) / 10)
            {
                return 0;
            }

            x /= 10;
            y = y * 10 + d;
        }

        return y;
    }


    public static void Test()
    {
        var task = new ReverseIntTask();

        Console.WriteLine($"{task.Reverse(123)} {321}");
        Console.WriteLine($"{task.Reverse(1534236469)} {0}");

    }
}
