namespace LeetCode.Tasks2025;

public class TopDfs
{
    IList<int> TopoSort(List<int>[] graph)
    {
        var visited = new HashSet<int>();
        var stack = new Stack<(int node, bool processed)>();
        var order = new List<int>();

        for (var i = 0; i < graph.Length; i++)
        {
            if (!visited.Add(i)) continue;

            stack.Push((i, false));

            while (stack.Count > 0)
            {
                var (u, processed) = stack.Pop();

                if (processed) order.Add(u);
                else if (visited.Add(u))
                {
                    stack.Push((u, true)); // поместим для пост-обработки

                    foreach (var v in graph[u].AsEnumerable().Reverse()) // чтобы порядок совпадал с рекурсивным
                    {
                        if (!visited.Add(v))
                        {
                            stack.Push((v, false));
                        }
                    }
                }
            }
        }

        order.Reverse();
        return order;
    }

    public static int[] TopoSort2(List<int>[] g)
    {
        var n = g.Length;
        var visiting  = new bool[n]; // в текущем DFS-стеке
        var processed = new bool[n]; // полностью завершён
        var nextIdx   = new int[n];  // указатель следующего соседа
        var order     = new List<int>(n);

        for (var s = 0; s < n; s++)
        {
            if (processed[s]) continue;

            var st = new Stack<int>();
            st.Push(s);

            while (st.Count > 0)
            {
                var u = st.Peek();

                if (!visiting[u] && !processed[u])
                    visiting[u] = true; // вход в u

                // все соседи просмотрены — пост-обработка
                if (nextIdx[u] == g[u].Count)
                {
                    st.Pop();
                    if (!processed[u])
                    {
                        visiting[u] = false;
                        processed[u] = true;
                        order.Add(u); // пост-ордер
                    }
                    continue;
                }

                var v = g[u][nextIdx[u]++];

                if (processed[v]) continue;      // уже готов
                if (visiting[v]) return Array.Empty<int>(); // back-edge → цикл

                st.Push(v);
            }
        }

        order.Reverse();
        return order.ToArray(); // пустой массив => цикл
    }
}
