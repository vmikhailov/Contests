namespace LeetCode.Tasks2025;

public class WordSearchTwoTask
{
    // 212. Word Search II
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var result = new HashSet<string>();
        var rows = board.Length;
        var cols = board[0].Length;

        var trie = new Trie26();
        foreach (var word in words)
        {
            trie.Insert(word);
        }

        var visited = new bool[rows, cols];

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                Dfs(board, r, c, trie.Root, "", visited, result);
            }
        }

        return result.ToList();
    }

    void Dfs(char[][] board, int r, int c, Trie26.Node node, string path, bool[,] visited, HashSet<string> result)
    {
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || visited[r, c])
            return;

        var ch = board[r][c];
        var childNode = node.Children[ch - 'a'];
        if (childNode == null)
            return;

        visited[r, c] = true;
        path += ch;

        if (childNode.IsTerminal)
        {
            result.Add(path);
        }

        Dfs(board, r + 1, c, childNode, path, visited, result);
        Dfs(board, r - 1, c, childNode, path, visited, result);
        Dfs(board, r, c + 1, childNode, path, visited, result);
        Dfs(board, r, c - 1, childNode, path, visited, result);

        visited[r, c] = false;
    }
}

public sealed class Trie26
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

    public bool Contains(string word)
    {
        var node = FindNode(word);
        return node is { IsTerminal: true };
    }

    public bool StartsWith(string prefix)
    {
        return FindNode(prefix) != null;
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
