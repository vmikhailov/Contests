using System;

namespace Codewars.Entry
{
    public static class MaxOfThree
    {
        public static int Calculate(int[][] matrix)
        {
            var m = 0;
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    var (m1, m2) = MaxTwoAround(matrix, i, j);
                    var v = m1 + m2 + matrix[i][j];
                    m = v > m ? v : m;
                }
            }

            return m;
        }

        private static (int a, int b) MaxTwoAround(int[][] matrix, int i, int j)
        {
            var a = i > 0 ? matrix[i - 1][j] : 0;
            var b = j > 0 ? matrix[i][j - 1] : 0;
            var c = i < matrix.Length - 1 ? matrix[i + 1][j] : 0;
            var d = j < matrix[i].Length - 1 ? matrix[i][j + 1] : 0;

            var m1 = Math.Max(a, b);
            var m2 = Math.Max(c, d);
            var m = Math.Max(m1, m2);
            
            return (m, m == m1 ? Math.Max(m2, Math.Min(a, b)) : Math.Max(m1, Math.Min(c, d)));
        }
    }
}