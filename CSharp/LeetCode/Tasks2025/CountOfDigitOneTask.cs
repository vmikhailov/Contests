namespace LeetCode.Tasks2025;

public class CountOfDigitOneTask
{
    public int CountDigitOne(int n)
    {
        var totalCount = 0;
        for (var i = 1; i <= n; i++)
        {
            totalCount += CountDigitOneInNumber(i);
        }
        return totalCount;
    }

    private int CountDigitOneInNumber(int num)
    {
        var count = 0;
        while (num > 0)
        {
            if (num % 10 == 1)
            {
                count++;
            }

            num /= 10;
        }
        return count;
    }
}

