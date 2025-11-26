namespace LeetCode.Tasks2025;

public class SearchSuggestionsSystemTask
{
    // 1268. Search Suggestions System
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var r = new List<IList<string>>();
        var t = new Trie26Search();

        foreach (var p in products) t.Insert(p);

        for (var i = 1; i <= searchWord.Length; i++)
        {
            r.Add(t.StartsWith(searchWord[..i], 3));
        }

        return r;
    }
}

public sealed class Trie26Search
{
    public sealed class Node
    {
        public bool IsTerminal;
        public readonly Node?[] Children = new Node?[26];
    }

    public Node Root { get; } = new();

    private static int Idx(char c) => c - 'a';

    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word)) return;

        var node = Root;

        foreach (var ch in word)
        {
            var i = Idx(ch);
            var next = node.Children[i];

            if (next == null)
            {
                next = new();
                node.Children[i] = next;
            }

            node = next;
        }

        node.IsTerminal = true;
    }

    public IList<string> StartsWith(string prefix, int top)
    {
        var node = FindNode(prefix);
        if (node is null) return [];

        var result = new List<string>();
        Collect(prefix, node, result, ref top);
        return result;
    }

    private bool Collect(string prefix, Node node, List<string> result, ref int top)
    {
        if (top == 0) return false;

        if (node.IsTerminal)
        {
            result.Add(prefix);
            top--;
        }

        for (var i = 0; i < 26; i++)
        {
            var subNode = node.Children[i];
            if (subNode is null) continue;

            var ch = (char)(i + 'a');
            if (!Collect(prefix + ch, subNode, result, ref top)) return false;
        }

        return true;
    }

    private Node? FindNode(string s)
    {
        if (string.IsNullOrEmpty(s)) return Root;

        var node = Root;

        foreach (var ch in s)
        {
            var i = Idx(ch);
            node = node.Children[i];
            if (node == null) return null;
        }

        return node;
    }
}
