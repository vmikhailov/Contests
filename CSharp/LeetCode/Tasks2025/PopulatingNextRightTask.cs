namespace LeetCode.Tasks2025;

public class PopulatingNextRightTask
{
    public class Node
    {
        public int val;
        public Node? left;
        public Node? right;
        public Node? next;
    }

    public Node? Connect(Node? root)
    {
        if (root == null) return root;

        var q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            var levelSize = q.Count;

            Node? prev = null;

            for (var i = 0; i < levelSize; i++)
            {
                var n = q.Dequeue();
                if (prev is not null) prev.next = n;
                prev = n;

                if (n.left is not null) q.Enqueue(n.left);
                if (n.right is not null) q.Enqueue(n.right);
            }
        }

        return root;
    }
}
