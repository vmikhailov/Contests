namespace LeetCode.Tasks2025;

public class WordLadderTask
{
    /* A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence
     of words beginWord -> s1 -> s2 -> ... -> sk such that:

    Every adjacent pair of words differs by a single letter.
    Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
    sk == endWord
    Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in
    the shortest transformation sequence from beginWord to endWord, or 0 if no such sequence exists.
    */
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        return Bfs(beginWord, BuildMapping(wordList));

        int Bfs(string wrd, IDictionary<string, List<string>> map)
        {
            var visited = new HashSet<string>();
            var q = new Queue<string>();
            q.Enqueue(wrd);
            var depth = 0;

            while(q.Count > 0)
            {
                var size = q.Count;

                depth++;
                for(var i = 0; i < size; i++)
                {
                    var word = q.Dequeue();

                    if(word == endWord)
                    {
                        return depth;
                    }

                    foreach(var opt in GetOptions(word))
                    {
                        if(!map.TryGetValue(opt, out var list)) continue;

                        foreach (var w in list.Where(w => visited.Add(w)))
                        {
                            q.Enqueue(w);
                        }
                    }
                }
            }

            return 0;
        }
    }

    IDictionary<string, List<string>> BuildMapping(IList<string> words)
    {
        var map = new Dictionary<string, List<string>>();

        foreach (var w in words)
        {
            foreach (var opt in GetOptions(w))
            {
                if (!map.TryGetValue(opt, out var list))
                {
                    map[opt] = list = [];
                }

                list.Add(w);
            }
        }

        return map;
    }

    IEnumerable<string> GetOptions(string w)
    {
        var buf = w.ToCharArray();

        for (var i = 0; i < w.Length; i++)
        {
            var old = buf[i];
            buf[i] = '.';
            yield return new(buf);
            buf[i] = old;
        }
    }
}
