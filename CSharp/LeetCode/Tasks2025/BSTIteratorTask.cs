using System.Collections;

namespace LeetCode.Tasks2025;

public class BSTIteratorTask
{
    public class BSTIterator
    {
        private readonly IEnumerator<int> _enumerator;
        private bool _hasNext;

        public BSTIterator(TreeNode root) {
            _enumerator = InOrder(root).GetEnumerator();
            _hasNext = _enumerator.MoveNext();
        }

        public int Next() {
            var v = _enumerator.Current;
            _hasNext = _enumerator.MoveNext();
            return v;
        }

        public bool HasNext()
        {
            return _hasNext;
        }

        private IEnumerable<int> InOrder(TreeNode? node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var val in InOrder(node.left))
            {
                yield return val;
            }

            yield return node.val;

            foreach (var val in InOrder(node.right))
            {
                yield return val;
            }
        }
    }

}
