namespace LeetCode.Tasks2025;

public class ConstructQuadTreeTask
{
    public class Node {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf) {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    public Node Construct(int[][] grid) {
        return Build(0, grid[0].Length - 1, 0, grid.Length - 1);

        Node Build(int x1, int x2, int y1, int y2)
        {
            if(x1 > x2 || y1 > y2) return null;

            var (s, c) = Sum(x1, x2, y1, y2);
            if(s == c || s == 0)
            {
                // leaf
                return new Node(s != 0, true);
            }

            var w = (x2 - x1 + 1) / 2;

            var node = new Node()
            {
                isLeaf = false,
                val = true,
                topLeft = Build(x1, x1 + w - 1, y1, y1 + w - 1),
                topRight = Build(x1 + w, x2, y1, y1 + w - 1),
                bottomLeft = Build(x1, x1 + w - 1, y1 + w, y2),
                bottomRight = Build(x1 + w, x2, y1 + w, y2)
            };

            return node;
        }

        (int Sum, int Count) Sum(int x1, int x2, int y1, int y2)
        {
            var s = 0;
            var c = 0;
            for(var x = x1; x <= x2; x++)
            {
                for(var y = y1; y <= y2; y++)
                {
                    s += grid[y][x];
                    c++;
                }
            }

            return (s, c);
        }
    }
}
