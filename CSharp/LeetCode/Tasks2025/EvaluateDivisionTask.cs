namespace LeetCode.Tasks2025;

public class EvaluateDivisionTask
{
    /*You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and values[i] represent the equation Ai / Bi = values[i]. Each Ai or Bi is a string that represents a single variable.

    You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.

    Return the answers to all queries. If a single answer cannot be determined, return -1.0.

    Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.

    Note: The variables that do not occur in the list of equations are undefined, so the answer cannot be determined for them.
    */
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var graph = new Dictionary<string, Dictionary<string, double>>();

        for (var i = 0; i < equations.Count; i++)
        {
            var start = equations[i][0];
            var end = equations[i][1];
            var value = values[i];

            if (!graph.TryGetValue(start, out var forward))
            {
                graph[start] = forward = [];
            }

            if (!graph.TryGetValue(end, out var backward))
            {
                graph[end] = backward = [];
            }

            forward[end] = value;
            backward[start] = 1.0 / value;
        }

        var result = new double[queries.Count];
        for (var i = 0; i < queries.Count; i++)
        {
            var start = queries[i][0];
            var end = queries[i][1];

            var visited = new HashSet<string>();
            var r = Dfs(start, end, 1.0, visited);
            result[i] = r ?? -1.0;
        }
        return result;

        double? Dfs(string current, string target, double accumulatedProduct, HashSet<string> visited)
        {
            if (!graph.TryGetValue(current, out var neighbors))
            {
                return null;
            }

            if (current == target)
            {
                return accumulatedProduct;
            }

            visited.Add(current);
            foreach (var (neighbor, weight) in neighbors)
            {
                if(visited.Contains(neighbor)) continue;

                var r = Dfs(neighbor, target, accumulatedProduct * weight, visited);

                if (r.HasValue)
                {
                    return r;
                }
            }

            visited.Remove(current);
            return null;
        }
    }
}
