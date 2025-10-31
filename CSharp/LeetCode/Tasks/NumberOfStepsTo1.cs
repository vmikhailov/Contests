namespace LeetCode.Tasks;

public class NumberOfStepsTo1
{
    public int NumSteps(string s)
    {
        var o = 0;
        var c = 0;

        for (var i = s.Length - 1; i > 0; i--)
        {
            var v = s[i] - '0' + o;

            switch (v)
            {
                case 0:
                    c++;
                    o = 0;
                    continue;
                case 1:
                    c += 2;
                    o = 1;
                    continue;
                case 2:
                    o = 1;
                    c += 2;
                    continue;
            }
        }

        return c;
    }
}