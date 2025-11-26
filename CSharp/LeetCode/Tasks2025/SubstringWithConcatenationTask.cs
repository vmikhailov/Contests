namespace LeetCode.Tasks2025;

public class SubstringWithConcatenationTask
{
    /*
    30. Substring with Concatenation of All Words

    You are given a string s and an array of strings words. All the strings of words are of the same length.

    A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

    For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are
    all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
    Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.
     */
    public IList<int> FindSubstring1(string s, string[] words)
    {
        var wordLen = words[0].Length;
        var count = words.Length;
        var need = new Dictionary<string, int>();

        foreach (var w in words)
        {
            need[w] = need.TryGetValue(w, out var c) ? c + 1 : 1;
        }

        var res = new List<int>();

        // offset-потоки
        for (var offset = 0; offset < wordLen; offset++)
        {
            var left = offset;
            var matched = 0;
            var seen = new Dictionary<string, int>();

            for (var right = offset; right + wordLen <= s.Length; right += wordLen)
            {
                var w = s.Substring(right, wordLen);

                // мусор
                if (!need.ContainsKey(w))
                {
                    seen.Clear();
                    matched = 0;
                    left = right + wordLen;
                    continue;
                }

                // добавили слово
                seen[w] = seen.TryGetValue(w, out var cx) ? cx + 1 : 1;

                if (seen[w] <= need[w])
                {
                    matched++;
                }
                else
                {
                    // слишком много w → сдвигаем левую границу
                    while (seen[w] > need[w])
                    {
                        var leftWord = s.Substring(left, wordLen);
                        seen[leftWord]--;

                        if (seen[leftWord] < need[leftWord])
                        {
                            matched--;
                        }
                        left += wordLen;
                    }
                }

                // вся комбинация есть
                if (matched == count)
                {
                    res.Add(left);

                    // выдвигаем окно вперёд на один wordLen
                    var lw = s.Substring(left, wordLen);
                    seen[lw]--;
                    matched--;
                    left += wordLen;
                }
            }
        }

        return res;
    }

    public IList<int> FindSubstring(string s, string[] words)
    {
        var len = words[0].Length;
        var dict = words.ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());
        var count = words.Length;

        var window = new Dictionary<string, int>();
        var result = new List<int>();

        foreach (var key in dict.Keys) window[key] = 0;
        var queue = new Queue<(string Word, int Pos)>();

        for (var offset = 0; offset < len; offset++)
        {
            ClearWindow();
            queue.Clear();
            var matched = 0;

            for (var i = offset; i <= s.Length - len; i += len)
            {
                var w = s[i..(i + len)];

                if (!dict.ContainsKey(w))
                {
                    ClearWindow(queue);
                    queue.Clear();
                    matched = 0;
                    continue;
                }

                queue.Enqueue((w, i));
                window[w]++;

                var dw = dict[w];
                if (window[w] <= dw)
                {
                    matched++;
                }
                else
                {
                    while (window[w] > dw)
                    {
                        var leftWord = queue.Dequeue().Word;
                        window[leftWord]--;

                        if (window[leftWord] < dict[leftWord])
                        {
                            matched--;
                        }
                    }
                }

                // вся комбинация есть
                if (matched == count)
                {
                    result.Add(queue.Peek().Pos);
                    window[queue.Dequeue().Word]--;
                    matched--;
                }
            }
        }

        return result;

        void ClearWindow(IEnumerable<(string Word, int Pos)>? items = null)
        {
            if (items != null)
            {
                foreach (var (word, _) in items) window[word] = 0;
                return;
            }

            foreach (var key in dict.Keys) window[key] = 0;
        }
    }
}
