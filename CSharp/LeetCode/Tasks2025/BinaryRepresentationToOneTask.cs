using System.Numerics;

namespace LeetCode.Tasks2025;

public class BinaryRepresentationToOneTask
{
    // 1404. Number of Steps to Reduce a Number in Binary Representation to One
    public int NumSteps(string s)
    {
        var result = 0;
        var overflow = false;

        for (var i = s.Length - 1; i > 0; i--)
        {
            if (s[i]=='0')
            {
                result += overflow ? 2 : 1;
            }
            else
            {
                if (overflow)
                {
                    result++;
                }
                else
                {
                    result += 2;
                    overflow = true;
                }
            }
        }

        return overflow ? result + 1 : result;
    }
}
