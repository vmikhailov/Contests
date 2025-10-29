namespace LeetCode.Tasks;

public class RestoreIp
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var q = new Stack<int>();
        var r = new List<string>();
        Parse(0);
        return r;

        void Parse(int i)
        {
            if (q.Count == 4)
            {
                if (i == s.Length)
                {
                    r.Add(string.Join('.', q.Reverse()));
                }

                return;
            }

            for (var j = i + 1; j <= s.Length; j++)
            {
                var w = s[i..j];
                var v = int.Parse(w);
                if (v > 255) break;
                if (w.Length > 1 && v == 0) continue;
                if (w.StartsWith('0') && v != 0) continue;

                q.Push(v);
                Parse(j);
                q.Pop();
            }
        }
    }
}