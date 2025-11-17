namespace LeetCode.Tasks2025;

public class RomanToIntTask
{
    public int RomanToInt(string s)
    {
        const string roman = "IVXLCDM";
        int[] arabic = [1, 5, 10, 50, 100, 500, 1000];

        var result = 0;
        var y = -1;

        for(var i = s.Length - 1; i >= 0; i--)
        {
            var x = arabic[roman.IndexOf(s[i])];

            if (x < y)
            {
                result -= x;
            }
            else
            {
                result += x;
                y = x;
            }
        }

        return result;
    }
}
