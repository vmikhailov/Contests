using System.Collections.Generic;

namespace Codewars.FB
{
    public class Node
    {
        public Node? Left { get; set; }

        public Node? Right { get; set; }

        public int Value { get; set; }
    }

    
    public class Iterator
    {
        public static IEnumerable<int> LTR(Node? root)
        {
            if (root == null)
            {
                yield break;
            }

            foreach (var item in LTR(root.Left))
            {
                yield return item;
            }

            yield return root.Value;

            foreach (var item in LTR(root.Right))
            {
                yield return item;
            }
        }


        private Node? _current;
        private readonly Stack<Node?> _path = new Stack<Node?>();

        public Iterator(Node root)
        {
            _current = DiveLeft(root);
        }

        public int? Next()
        {
            if (_current == null)
            {
                return null;
            }

            var v = _current.Value;
            _current = DiveLeft(_current.Right) ?? _path.Pop();
            return v;
        }

        private Node? DiveLeft(Node? node)
        {
            if (node == null)
            {
                return node;
            }

            while (node.Left != null)
            {
                _path.Push(node);
                node = node.Left;
            }

            return node;
        }
    }
}