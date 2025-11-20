namespace LeetCode.Tasks2025;

public class WordDictionaryTask
{
    private sealed class Node
    {
        public bool IsTerminal;
        public Node?[] Children = new Node?[26];
        public byte ChildCount; // Track number of non-null children for faster wildcard search
    }

    private readonly Node _root = new();

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private static int Idx(char c) => c - 'a';

    public void AddWord(string word)
    {
        if (string.IsNullOrEmpty(word)) return;

        var node = _root;

        foreach (var ch in word)
        {
            var i = Idx(ch);
            var next = node.Children[i];

            if (next == null)
            {
                next = new Node();
                node.Children[i] = next;
                node.ChildCount++;
            }

            node = next;
        }

        node.IsTerminal = true;
    }

    public bool Search(string word)
    {
        if (string.IsNullOrEmpty(word)) return false;

        var node = FindNode(word);
        return node is { IsTerminal: true };
    }

    public bool StartsWith(string prefix)
    {
        return FindNode(prefix) != null;
    }

    private Node? FindNode(string s)
    {
        return string.IsNullOrEmpty(s) ? _root : FindNode(_root, s.AsSpan());
    }

    private Node? FindNode(Node node, ReadOnlySpan<char> s)
    {
        // Base case: reached the end of string
        if (s.Length == 0)
            return node;

        var ch = s[0];
        var remaining = s[1..];

        if (ch == '.')
        {
            // Wildcard: try all possible children
            // Early termination if no children exist
            if (node.ChildCount == 0)
                return null;

            // Need to recursively search remaining characters
            // Only iterate through actual children using ChildCount
            byte foundCount = 0;
            foreach (var child in node.Children)
            {
                if (child is null)
                    continue;

                var result = FindNode(child, remaining);
                if (result is not null)
                    return result;

                // Early termination: stop once we've checked all children
                if (++foundCount == node.ChildCount)
                    break;
            }

            return null;
        }

        // Regular character: follow the exact path (tail recursion)
        var idx = Idx(ch);
        var nextNode = node.Children[idx];

        return nextNode is null ? null : FindNode(nextNode, remaining);
    }
}
