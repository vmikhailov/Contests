namespace Codewars.Codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SquareSumsFromCW
    {
        private static readonly Random RandomInstance = new Random();
        private static Dictionary<int, int[]> precomputedResults = new Dictionary<int, int[]>();

        public static int[] GetPermutation(int n)
        {
            if (precomputedResults.Count == 0)
            {
                precomputedResults = new Dictionary<int, int[]>
                {
                    { 15, new[] { 8, 1, 15, 10, 6, 3, 13, 12, 4, 5, 11, 14, 2, 7, 9 } },
                    { 16, new[] { 8, 1, 15, 10, 6, 3, 13, 12, 4, 5, 11, 14, 2, 7, 9, 16 } },
                    { 17, new[] { 16, 9, 7, 2, 14, 11, 5, 4, 12, 13, 3, 6, 10, 15, 1, 8, 17 } },
                    { 23, new[] { 2, 23, 13, 12, 4, 21, 15, 10, 6, 19, 17, 8, 1, 3, 22, 14, 11, 5, 20, 16, 9, 7, 18 } },
                    { 25, new[] { 2, 23, 13, 12, 24, 25, 11, 14, 22, 3, 1, 8, 17, 19, 6, 10, 15, 21, 4, 5, 20, 16, 9, 7, 18 } },
                    { 26, new[] { 2, 14, 22, 3, 13, 23, 26, 10, 6, 19, 17, 8, 1, 15, 21, 4, 12, 24, 25, 11, 5, 20, 16, 9, 7, 18 } },
                    { 27, new[] { 1, 8, 17, 19, 6, 3, 13, 12, 24, 25, 11, 14, 22, 27, 9, 16, 20, 5, 4, 21, 15, 10, 26, 23, 2, 7, 18 } },
                    { 28, new[] { 1, 15, 10, 26, 23, 13, 3, 6, 19, 17, 8, 28, 21, 4, 12, 24, 25, 11, 5, 20, 16, 9, 27, 22, 14, 2, 7, 18 } },
                    { 29, new[] { 1, 24, 25, 11, 5, 4, 12, 13, 3, 6, 19, 17, 8, 28, 21, 15, 10, 26, 23, 2, 14, 22, 27, 9, 16, 20, 29, 7, 18 } },
                    { 30, new[] { 1, 24, 25, 11, 5, 4, 12, 13, 3, 6, 30, 19, 17, 8, 28, 21, 15, 10, 26, 23, 2, 14, 22, 27, 9, 16, 20, 29, 7, 18 } },
                    {
                        31,
                        new[] { 1, 15, 10, 6, 30, 19, 17, 8, 28, 21, 4, 5, 31, 18, 7, 29, 20, 16, 9, 27, 22, 3, 13, 12, 24, 25, 11, 14, 2, 23, 26 }
                    },
                    {
                        32,
                        new[]
                        {
                            1, 8, 28, 21, 4, 32, 17, 19, 30, 6, 3, 13, 12, 24, 25, 11, 5, 31, 18, 7, 29, 20, 16, 9, 27, 22, 14, 2, 23, 26, 10, 15
                        }
                    },
                    {
                        33,
                        new[]
                        {
                            1, 8, 28, 21, 4, 32, 17, 19, 30, 6, 3, 13, 12, 24, 25, 11, 5, 20, 29, 7, 18, 31, 33, 16, 9, 27, 22, 14, 2, 23, 26, 10, 15
                        }
                    },
                    {
                        34,
                        new[]
                        {
                            1, 3, 6, 19, 30, 34, 2, 7, 18, 31, 33, 16, 9, 27, 22, 14, 11, 25, 24, 12, 13, 23, 26, 10, 15, 21, 28, 8, 17, 32, 4, 5, 20,
                            29
                        }
                    },
                    {
                        35,
                        new[]
                        {
                            1, 3, 6, 19, 30, 34, 2, 7, 18, 31, 33, 16, 9, 27, 22, 14, 11, 25, 24, 12, 13, 23, 26, 10, 15, 21, 28, 8, 17, 32, 4, 5, 20,
                            29, 35
                        }
                    },
                    {
                        36,
                        new[]
                        {
                            1, 3, 6, 10, 26, 23, 2, 7, 18, 31, 33, 16, 9, 27, 22, 14, 35, 29, 20, 5, 11, 25, 24, 12, 13, 36, 28, 8, 17, 19, 30, 34,
                            15, 21, 4, 32
                        }
                    },
                    {
                        37,
                        new[]
                        {
                            1, 3, 13, 36, 28, 8, 17, 32, 4, 21, 15, 34, 30, 19, 6, 10, 26, 23, 2, 7, 18, 31, 33, 16, 9, 27, 22, 14, 35, 29, 20, 5, 11,
                            25, 24, 12, 37
                        }
                    },
                    {
                        38,
                        new[]
                        {
                            1, 3, 6, 19, 30, 34, 2, 23, 13, 36, 28, 8, 17, 32, 4, 21, 15, 10, 26, 38, 11, 25, 24, 12, 37, 27, 22, 14, 35, 29, 20, 5,
                            31, 18, 7, 9, 16, 33
                        }
                    },
                    {
                        39,
                        new[]
                        {
                            1, 3, 6, 19, 30, 34, 2, 7, 18, 31, 33, 16, 9, 27, 22, 14, 35, 29, 20, 5, 11, 38, 26, 23, 13, 36, 28, 8, 17, 32, 4, 21, 15,
                            10, 39, 25, 24, 12, 37
                        }
                    },
                    {
                        40,
                        new[]
                        {
                            1, 3, 6, 10, 39, 25, 24, 40, 9, 16, 33, 31, 18, 7, 2, 23, 26, 38, 11, 5, 20, 29, 35, 14, 22, 27, 37, 12, 13, 36, 28, 8,
                            17, 19, 30, 34, 15, 21, 4, 32
                        }
                    },
                };

                const int MaxN = 1001;
                var squares = new HashSet<int>();
                var sqrIndex = 2;
                const int MaxSum = 2 * MaxN - 1;
                while (true)
                {
                    if (sqrIndex * sqrIndex > MaxSum) break;
                    squares.Add(sqrIndex * sqrIndex);
                    sqrIndex++;
                }

                var currentResult = precomputedResults[40];
                for (var i = 41; i <= MaxN; i++)
                {
                    currentResult = Search(i, currentResult, squares);
                    precomputedResults[i] = currentResult;
                }
            }

            return precomputedResults.ContainsKey(n) ? precomputedResults[n] : null;
        }

        private static int[] Search(int n, int[] currentResult, HashSet<int> squares)
        {
            var result = new int[n];

            // option 0 (add N to the begin or the end of sequence)
            if (squares.Contains(currentResult[0] + n))
            {
                result[0] = n;
                for (var i = 1; i < n; i++)
                {
                    result[i] = currentResult[i - 1];
                }

                return result;
            }

            if (squares.Contains(currentResult[n - 2] + n))
            {
                for (var i = 0; i < n - 1; i++)
                {
                    result[i] = currentResult[i];
                }

                result[n - 1] = n;

                return result;
            }

            var left = currentResult;
            var right = new[] { n };

            // infinity loop
            const int MaxAttemptBeforeSwap = 10;
            var attemptNumber = 0;
            while (true)
            {
                // option 1 (just merge left and right)
                var tempRes = TryToGetSimpleResult(left, right, squares);
                if (tempRes != null)
                {
                    return tempRes;
                }

                // swap left and right
                if (attemptNumber++ == MaxAttemptBeforeSwap)
                {
                    var temp = left;
                    left = right;
                    right = temp;
                    attemptNumber = 0;
                }

                // too small left part
                if (left.Length < 5)
                {
                    var temp = left;
                    left = right;
                    right = temp;
                }

                var randIndex = -1;
                var leftLeftLen = -1;
                var leftRightLen = -1;

                // option 2.1 (combine reversed left part)
                if (squares.Contains(left[0] + right[0]))
                {
                    randIndex = RandomInstance.Next(left.Length - 1);
                    leftLeftLen = randIndex + 1;
                    leftRightLen = left.Length - leftLeftLen;
                    var tempLeft = new int[leftLeftLen + right.Length];
                    FillResult(tempLeft, left.Reverse().ToArray(), leftLeftLen, 0, leftRightLen);
                    FillResult(tempLeft, right, right.Length, leftLeftLen, 0);

                    var tempRight = new int[leftRightLen];
                    FillResult(tempRight, left, leftRightLen, 0, leftLeftLen);
                    left = tempLeft;
                    right = tempRight;

                    continue;
                }

                if (squares.Contains(left[0] + right[^1]))
                {
                    randIndex = RandomInstance.Next(left.Length - 1);
                    leftLeftLen = randIndex + 1;
                    leftRightLen = left.Length - leftLeftLen;
                    var tempLeft = new int[leftLeftLen + right.Length];
                    FillResult(tempLeft, left.Reverse().ToArray(), leftLeftLen, 0, leftRightLen);
                    FillResult(tempLeft, right.Reverse().ToArray(), right.Length, leftLeftLen, 0);

                    var tempRight = new int[leftRightLen];
                    FillResult(tempRight, left, leftRightLen, 0, leftLeftLen);
                    left = tempLeft;
                    right = tempRight;

                    continue;
                }

                // option 2.2 (combine with proper index)
                var properIndexes = new List<int>();
                for (var leftIndex = 0; leftIndex < left.Length; leftIndex++)
                {
                    if (squares.Contains(left[leftIndex] + right[0]))
                    {
                        properIndexes.Add(leftIndex * 1);
                    }
                    else if (squares.Contains(left[leftIndex] + right[^1]))
                    {
                        properIndexes.Add(leftIndex * 1);
                    }
                }

                if (properIndexes.Count == 0) continue;

                randIndex = RandomInstance.Next(properIndexes.Count - 1);
                leftLeftLen = properIndexes[randIndex] + 1;
                leftRightLen = left.Length - leftLeftLen;
                if (squares.Contains(left[leftLeftLen - 1] + right[0]))
                {
                    var tempLeft = new int[leftLeftLen + right.Length];
                    FillResult(tempLeft, left, leftLeftLen, 0, 0);
                    FillResult(tempLeft, right, right.Length, leftLeftLen, 0);

                    var tempRight = new int[leftRightLen];
                    FillResult(tempRight, left, leftRightLen, 0, leftLeftLen);
                    left = tempLeft;
                    right = tempRight;

                    continue;
                }

                if (squares.Contains(left[leftLeftLen - 1] + right[^1]))
                {
                    var tempLeft = new int[leftLeftLen + right.Length];
                    FillResult(tempLeft, left, leftLeftLen, 0, 0);
                    FillResult(tempLeft, right.Reverse().ToArray(), right.Length, leftLeftLen, 0);

                    var tempRight = new int[leftRightLen];
                    FillResult(tempRight, left, leftRightLen, 0, leftLeftLen);
                    left = tempLeft;
                    right = tempRight;

                    continue;
                }
            }
        }

        private static int[] TryToGetSimpleResult(int[] left, int[] right, HashSet<int> squares)
        {
            if (squares.Contains(left[^1] + right[0]))
            {
                var result = new int[left.Length + right.Length];
                FillResult(result, left, left.Length, 0, 0);
                FillResult(result, right, right.Length, left.Length, 0);

                return result;
            }

            if (squares.Contains(left[0] + right[0]))
            {
                var result = new int[left.Length + right.Length];
                FillResult(result, left.Reverse().ToArray(), left.Length, 0, 0);
                FillResult(result, right, right.Length, left.Length, 0);

                return result;
            }

            if (squares.Contains(left[^1] + right[^1]))
            {
                var result = new int[left.Length + right.Length];
                FillResult(result, left, left.Length, 0, 0);
                FillResult(result, right.Reverse().ToArray(), right.Length, left.Length, 0);

                return result;
            }

            if (squares.Contains(left[0] + right[^1]))
            {
                var result = new int[left.Length + right.Length];
                FillResult(result, right, right.Length, 0, 0);
                FillResult(result, left, left.Length, right.Length, 0);

                return result;
            }

            return null;
        }

        private static void FillResult(int[] dest, int[] source, int count, int destShift, int sourceShift)
        {
            for (var i = 0; i < count; i++)
            {
                var destIndex = i + destShift;
                var sourceIndex = i + sourceShift;
                dest[destIndex] = source[sourceIndex];
            }
        }
    }
}