namespace LeetCode.Tasks;

public class WordBreaker
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        if(!wordDict.All(x => s.Contains(x))) return false;
        
        var st = wordDict.ToHashSet();

        var q = new Stack<string>();
        return Parse(0);

        bool Parse(int i)
        {
            if (i == s.Length)
            {
                return true;
            }

            for (var j = i + 1; j <= s.Length; j++)
            {
                var w = s[i..j];
                if (st.Contains(w))
                {
                    q.Push(w);
                    if(Parse(j)) return true;
                    q.Pop();
                }
            }
            return false;
        }
    }
}