namespace LeetCode.Tasks2025;

public static class MyCalendarsOneTask
{
    // BST implementation where each node represents an event [Start, End)
    // Left subtree: events that end <= current.Start (earlier events)
    // Right subtree: events that start >= current.End (later events)
    //
    // ═══════════════════════════════════════════════════════════════════════════
    // OVERLAP DETECTION LOGIC:
    // ═══════════════════════════════════════════════════════════════════════════
    // Two intervals [a, b) and [c, d) overlap if and only if: c < b AND a < d
    //
    // Visual guide (E = existing, N = new):
    //
    // 1) NO OVERLAP - New completely before Existing:
    //    -----N-----)
    //                    -----E-----)
    //    Result: N.end <= E.start → !(E.start < N.end) → NO OVERLAP ✓
    //
    // 2) NO OVERLAP - New completely after Existing:
    //                    -----E-----)
    //                                    -----N-----)
    //    Result: N.start >= E.end → !(N.start < E.end) → NO OVERLAP ✓
    //
    // 3) OVERLAP - New starts before and overlaps:
    //         -----N-----)
    //                -----E-----)
    //    Result: E.start < N.end (10<15) AND N.start < E.end (5<20) → OVERLAP ✗
    //
    // 4) OVERLAP - New starts after and overlaps:
    //                -----E-----)
    //                   -----N-----)
    //    Result: E.start < N.end (10<25) AND N.start < E.end (15<20) → OVERLAP ✗
    //
    // 5) OVERLAP - New contains Existing:
    //         ---------N---------)
    //            ---E---)
    //    Result: E.start < N.end (10<30) AND N.start < E.end (5<20) → OVERLAP ✗
    //
    // 6) OVERLAP - Existing contains New:
    //         ---------E---------)
    //            ---N---)
    //    Result: E.start < N.end (10<15) AND N.start < E.end (12<20) → OVERLAP ✗
    //
    // ═══════════════════════════════════════════════════════════════════════════
    //
    // Example: Book(10,20), Book(5,10), Book(15,25), Book(20,30), Book(0,5), Book(25,35)
    //
    // Initial: Book(10, 20)
    //          [10,20]
    //
    // Book(5, 10): endTime=10 <= node.Start=10, go left
    //          [10,20]
    //          /
    //       [5,10]
    //
    // Book(15, 25): startTime=15 < node.End=20 && endTime=25 > node.Start=10
    //               → OVERLAP → return false
    //
    // Book(20, 30): startTime=20 >= node.End=20, go right
    //          [10,20]
    //          /     \
    //       [5,10]  [20,30]
    //
    // Book(0, 5): endTime=5 <= node.Start=10, go left
    //             endTime=5 <= node.Start=5, go left again
    //          [10,20]
    //          /     \
    //       [5,10]  [20,30]
    //       /
    //    [0,5]
    //
    // Book(25, 35): startTime=25 >= node.End=20, go right
    //               startTime=25 >= node.End=30? No, but startTime=25 < node.End=30
    //               && endTime=35 > node.Start=20 → OVERLAP → return false
    //
    // Book(30, 40): startTime=30 >= node.End=20, go right
    //               startTime=30 >= node.End=30, go right again
    //          [10,20]
    //          /     \
    //       [5,10]  [20,30]
    //       /            \
    //    [0,5]         [30,40]
    //
    // ═══════════════════════════════════════════════════════════════════════════
    // AVL Tree implementation (self-balancing BST)
    // ═══════════════════════════════════════════════════════════════════════════
    // Guarantees O(log n) WORST CASE for Book operation (vs O(n) for simple BST)
    //
    // AVL Tree properties:
    // 1) For every node: |Height(Left) - Height(Right)| <= 1 (balance factor)
    // 2) After insertion, tree automatically rebalances via rotations
    // 3) Height is always O(log n), guaranteeing O(log n) for all operations
    //
    // When to use AVL vs Simple BST:
    // - AVL: When worst-case performance matters (e.g., sorted input, production code)
    // - Simple BST: When average case is enough and code simplicity matters
    //
    // Example of balancing: Sequential bookings [1,2], [2,3], [3,4]
    //
    // Simple BST (degenerates to linked list):
    //   [1,2]
    //       \
    //      [2,3]
    //          \
    //         [3,4]    ← Height = 3, O(n) search
    //
    // AVL Tree (auto-balances):
    //       [2,3]
    //       /   \
    //    [1,2] [3,4]   ← Height = 2, O(log n) search
    //
    public class MyCalendarAVL
    {
        private class Node(int start, int end)
        {
            public readonly int Start = start;
            public readonly int End = end;
            public Node? Left;
            public Node? Right;
            public int Height = 1; // высота поддерева с корнем в этом узле
        }

        private Node? _root;

        public bool Book(int startTime, int endTime)
        {
            return Insert(ref _root, startTime, endTime);
        }

        // Вспомогательные методы для AVL балансировки
        private static int GetHeight(Node? node) => node?.Height ?? 0;

        private static int GetBalance(Node? node)
        {
            if (node == null) return 0;

            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private static void UpdateHeight(Node node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        // Правый поворот:
        //       y                x
        //      / \              / \
        //     x   C    =>      A   y
        //    / \                  / \
        //   A   B                B   C
        private static void RotateRight(ref Node? root)
        {
            // root != null and root.Left != null are required for right rotation
            var y = root!;
            var x = y.Left!;
            var b = x.Right;

            x.Right = y;
            y.Left = b;

            UpdateHeight(y);
            UpdateHeight(x);

            root = x;
        }

        // Левый поворот:
        //     x                  y
        //    / \                / \
        //   A   y      =>      x   C
        //      / \            / \
        //     B   C          A   B
        private static void RotateLeft(ref Node? root)
        {
            // root != null and root.Right != null are required for left rotation
            var x = root!;
            var y = x.Right!;
            var b = y.Left;

            y.Left = x;
            x.Right = b;

            UpdateHeight(x);
            UpdateHeight(y);

            root = y;
        }

        // New: isolate rebalancing logic (now by-ref)
        private static void Rebalance(ref Node? node)
        {
            if (node is null) return;

            UpdateHeight(node);

            switch (GetBalance(node))
            {
                // Left heavy
                case > 1:
                {
                    // If left-right heavy, rotate left child first
                    if (GetBalance(node.Left) < 0)
                    {
                        RotateLeft(ref node.Left);
                    }
                    // Then rotate right at this node
                    RotateRight(ref node);
                    break;
                }

                // Right heavy
                case < -1:
                {
                    // If right-left heavy, rotate right child first
                    if (GetBalance(node.Right) > 0)
                    {
                        RotateRight(ref node.Right);
                    }
                    // Then rotate left at this node
                    RotateLeft(ref node);
                    break;
                }
            }
            // Already balanced: height was updated above
        }

        private bool Insert(ref Node? node, int startTime, int endTime)
        {
            // Standard BST insert
            if (node == null)
            {
                node = new(startTime, endTime);
                return true;
            }

            // Overlap check: disallow insertion if overlaps existing interval
            if (!(endTime <= node.Start || startTime >= node.End))
            {
                return false;
            }

            var inserted = endTime <= node.Start ?
                Insert(ref node.Left, startTime, endTime) :
                Insert(ref node.Right, startTime, endTime);

            if (inserted)
            {
                Rebalance(ref node);
            }

            return inserted;
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    // Simple BST implementation (not balanced)
    // ═══════════════════════════════════════════════════════════════════════════
    // Complexity: O(log n) AVERAGE case, O(n) WORST case
    //
    // Pros:
    // + Simpler code (no height tracking, no rotations)
    // + Slightly faster in average case (no balancing overhead)
    // + Easier to understand and debug
    //
    // Cons:
    // - Can degenerate to O(n) with sorted/semi-sorted input
    // - No guarantees on tree height
    //
    // Use when:
    // - Input is random/shuffled
    // - Code simplicity > worst-case guarantees
    // - Small datasets where O(n) is acceptable
    //
    public class MyCalendarBST
    {
        private class Node
        {
            public int Start;
            public int End;
            public Node? Left;
            public Node? Right;

            public Node(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        private Node? _root;

        public bool Book(int startTime, int endTime)
        {
            if (_root != null)
            {
                return Insert(_root, startTime, endTime);
            }

            _root = new(startTime, endTime);
            return true;
        }

        private bool Insert(Node node, int startTime, int endTime)
        {
            while (true)
            {
                if (!(endTime <= node.Start || startTime >= node.End))
                {
                    return false;
                }

                if (endTime <= node.Start)
                {
                    // goes left
                    if (node.Left is null)
                    {
                        node.Left = new(startTime, endTime);
                        return true;
                    }

                    node = node.Left;
                }
                else
                {
                    //goes right
                    if (node.Right is null)
                    {
                        node.Right = new(startTime, endTime);
                        return true;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
        }
    }

    // Original implementation kept for reference
    public class MyCalendarList
    {
        private readonly List<int> _events = [];

        public bool Book(int startTime, int endTime)
        {
            var i = _events.BinarySearch(startTime);
            var j = _events.BinarySearch(endTime);

            if (i >= 0 && (i & 1) == 0) return false;
            if (j >= 0 && (j & 1) == 1) return false;

            // Convert to insertion indices
            // If startTime found at odd index (end of event), insert after it
            i = i < 0 ? ~i : i + 1;
            j = j < 0 ? ~j : j;

            if (i != j || (i & 1) == 1) return false;

            _events.Insert(j, endTime);
            _events.Insert(i, startTime);
            return true;
        }
    }
}
