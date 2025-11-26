namespace LeetCode.Tasks2025;

public class MinimumWindowSubstringTask
{
    // 76. Minimum Window Substring
    public string MinWindow(string s, string t)
    {
        if (t == "") return "";

        var d = new Dictionary<char, int>();

        foreach (var c in t)
        {
            if (!d.TryAdd(c, 1)) d[c]++;
        }

        var need = d.Count; // Number of unique character types we need to satisfy
        var have = 0; // Number of unique character types we've satisfied

        var st = new Queue<(char Char, int Pos)>();
        var min = int.MaxValue;
        var minString = "";

        for (var i = 0; i < s.Length; i++)
        {
            if (!d.ContainsKey(s[i])) continue;

            d[s[i]]--;
            if (d[s[i]] == 0) have++; // Satisfied this character type's requirement
            st.Enqueue((s[i], i));

            while (st.Count > 0 && d[st.Peek().Char] < 0) d[st.Dequeue().Char]++;

            if (have != need) continue;

            var j = st.Peek().Pos;

            if (min <= i - j) continue;

            min = i - j;
            minString = s[j..(i + 1)];
        }

        return minString;
    }
}
