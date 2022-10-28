using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Codewars.Codewars.LinearEquation
{
    public class LinearSystem
    {
        private static decimal epsilon = (decimal)1e-15;

        public string Solve(string input)
        {
            var matrix = input.Split("\r\n").Select(x => x.Split(" ").Select(decimal.Parse).ToArray()).ToArray();
            var m = matrix[0].Length;
            var n = matrix.Length;
            var solution = new decimal[n]; 
            
            Print2(matrix);

            RemoveRedundant(ref matrix);
            for (var i = 0; i < n; i++)
            {
                ReorderZeros(ref matrix);
                var row1 = matrix[i];
                if(Equals(row1[i], 0)) continue;
                if(!Equals(row1[i], 1)) MultiplyRow(row1, 1/row1[i]);
                
                for (var j = i + 1; j < n; j++)
                {
                    var row2 = matrix[j];
                    if(Equals(row2[i], 0)) continue; 
                    
                    var k = -row1[i]/row2[i];
                    
                    MultiplyRow(row2, k);
                    SumRows(row1, row2);
                }
            }
            Print2(matrix, "shifted");
            
            if (Equals(matrix[n - 1].Take(m - 1).Sum(x => x), 0)) return "SOLUTION=NONE";
            
            for (var i = n - 1; i >= 0; i--)
            {
                var row = matrix[i];
                var v = row[m - 1];
                for (var j = m - 2; j > i; j--)
                {
                    v -= row[j] * solution[j];
                }

                solution[i] = v;
            }

            var result = new string[n];
            for(var i = 0; i < n; i++)
            {
                var r = Math.Round(solution[i], 15, MidpointRounding.ToZero);
                var s = r.ToString();
                result[i] = s.Length - s.IndexOf(".") > 6 ? s.Substring(0, s.IndexOf(".") + 6) : s;
            }
            
            return $"SOLUTION=({string.Join("; ", result)})";
        }

        private void Print(decimal[][] matrix)
        {
            Debug.WriteLine("-------------------------");
            var vars = matrix.Length <= 3 ? "xyz" : "abcdefghijklmopqrstuvwxyz";
            foreach (var row in matrix)
            {
                var first = true;
                for (var j = 0; j < row.Length - 1; j++)
                {
                    var k = row[j];
                    if (Equals(k, 0)) continue;
                    var s = Math.Sign(k);
                    k = k * s;
                    if (!first)
                    {
                        Debug.Write(s > 0 ? " + ":" - ");
                    } else if (s < 0)
                    {
                        Debug.Write("-");
                    }

                    Debug.Write(Equals(k, 1) ? $"{vars[j]:F10}" : $"{k}{vars[j]:F10}");
                    first = false;
                }
                Debug.WriteLine($" = {row.Last():F10}");
            }
            
        }
        
        private void Print2(decimal[][] matrix, string title = "")
        {
            Debug.WriteLine($"-----------{title}--------------");
            foreach (var t in matrix)
            {
                var row = string.Join(", ", t[..^1].Select(x => x.ToString("F3")));
                Debug.WriteLine($"{row} = {t.Last():F3}");
            }
        }

        private bool RemoveRedundant(ref decimal[][] matrix)
        {
            var toRemove = new HashSet<int>();
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = i + 1; j < matrix.Length; j++)
                {
                    if (IsProportional(matrix[i], matrix[j]))
                    {
                        toRemove.Add(j);
                    }
                }
            }

            var r = toRemove.Any();
            if (r)
            {
                matrix = matrix.Where((x, i) => !toRemove.Contains(i)).ToArray();
            }

            return r;
        }

        private void ReorderZeros(ref decimal[][] matrix)
        {
            matrix = matrix.OrderBy(x => x.TakeWhile(y => Equals(y, 0)).Count()).ToArray();
        }

        private bool IsProportional(decimal[] r1, decimal[] r2)
        {
            if (r1.Zip(r2).Any(x => Equals(x.First, 0) ^ Equals(x.Second, 0)))
            {
                return false;
            }

            var i = 0;
            while (i < r1.Length && Equals(r1[i], 0) && Equals(r2[i], 0)) i++;
            var k = r1[i] / r2[i];
            i++;
            while (i < r1.Length && Equals(r1[i], k * r2[i])) i++;

            return i == r1.Length;
        }

        private void MultiplyRow(decimal[] row, decimal k)
        {
            for (var i = 0; i < row.Length; i++)
            {
                row[i] *= k;
            }
        }

        private void SumRows(decimal[] r1, decimal[] r2)
        {
            for (var i = 0; i < r1.Length; i++)
            {
                r2[i] = r2[i] + r1[i];
            }
        }

        private bool Equals(decimal d1, decimal d2)
        {
            return Math.Abs(d1 - d2) < epsilon;
        }
    }
}