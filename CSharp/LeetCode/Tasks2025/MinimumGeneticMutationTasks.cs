namespace LeetCode.Tasks2025;

public class MinimumGeneticMutationTasks
{
    /* A gene string can be represented by an 8-character long string, with choices from 'A', 'C', 'G', and 'T'.

    Suppose we need to investigate a mutation from a gene string startGene to a gene string endGene where one mutation
     is defined as one single character changed in the gene string.

    For example, "AACCGGTT" --> "AACCGGTA" is one mutation.
    There is also a gene bank bank that records all the valid gene mutations. A gene must be in bank to make it
    a valid gene string.

    Given the two gene strings startGene and endGene and the gene bank bank, return the minimum number of mutations
    needed to mutate from startGene to endGene. If there is no such a mutation, return -1.

    Note that the starting point is assumed to be valid, so it might not be included in the bank.
    */
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        return Bfs(startGene, BuildMapping(bank));

        int Bfs(string wrd, IDictionary<string, List<string>> map)
        {
            var visited = new HashSet<string>();
            var q = new Queue<string>();
            q.Enqueue(wrd);
            var depth = 0;

            while (q.Count > 0)
            {
                var size = q.Count;

                depth++;

                for (var i = 0; i < size; i++)
                {
                    var word = q.Dequeue();

                    if (word == endGene)
                    {
                        return depth - 1;
                    }

                    foreach (var opt in GetOptions(word))
                    {
                        if (!map.TryGetValue(opt, out var list)) continue;

                        foreach (var w in list.Where(w => visited.Add(w)))
                        {
                            q.Enqueue(w);
                        }
                    }
                }
            }

            return -1;
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
