namespace LeetCode.Tasks2025;

public class NumberOfSquarefulArraysTask
{
    // 996. Number of Squareful Arrays
    public int NumSquarefulPerms(int[] nums)
    {
        var n = nums.Length;
        if(n == 1) return 1;
        var map = new Dictionary<int, ISet<int>>();
        var freq = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                var a = nums[i];
                var b = nums[j];
                var s = a + b;
                var c = (int)Math.Sqrt(s);

                if (s != c * c)
                {
                    continue;
                }

                if(!map.TryGetValue(a, out var st))
                    map[a] = st = new HashSet<int>();
                st.Add(b);

                if(!map.TryGetValue(b, out st))
                    map[b] = st = new HashSet<int>();
                st.Add(a);
            }
        }

        for (var i = 0; i < n; i++)
        {
            if(!freq.ContainsKey(nums[i]))
                freq[nums[i]] = 0;
            freq[nums[i]]++;
        }

        var result = 0;
        foreach (var start in freq.Keys)
        {
            freq[start]--;
            Dfs(start, 1);
            freq[start]++;
        }

        return result;

        void Dfs(int last, int depth)
        {
            if (depth == n)
            {
                result++;
                return;
            }

            if (!map.TryGetValue(last, out var value))
            {
                return;
            }

            foreach (var next in value)
            {
                if (freq[next] == 0) continue;

                freq[next]--;
                Dfs(next, depth + 1);
                freq[next]++;
            }
        }
    }
}
