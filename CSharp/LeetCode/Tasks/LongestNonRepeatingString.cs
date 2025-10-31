namespace LeetCode.Tasks;

public class LongestNonRepeatingString {
    public int LengthOfLongestSubstring(string s) {
        var h = new HashSet<char>();
        var i = 0;
        var j = 0;
        var t = 0;
        var m = 0;
        while(j < s.Length)
        {
            var c = s[j];
            if(h.Add(c))
            {
                j++;
                t++;
            }
            else
            {
                while(s[i] != c)
                {
                    h.Remove(s[i]);
                    i++;
                    t--;
                }

                i++;
                j++;
            }
            m = Math.Max(m, t);
        }
        return m;
    }

    public static void Test()
    {
        var solution = new LongestNonRepeatingString();
        var r1 = solution.LengthOfLongestSubstring("abcabcbb");
        Console.WriteLine(r1); // Expected output: 3

        var r2 = solution.LengthOfLongestSubstring("aabaab!bb");
        Console.WriteLine(r2); // Expected output: 3
    }
}
