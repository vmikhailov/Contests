using LeetCode;
using LeetCode.Tasks;

var ss = new SudokuSolver();

ss.SolveSudoku(ss.Test3);

// var q = new Sq2();
// q.countTriples(12);


// var ch = new Change();
// Console.WriteLine(ch.LemonadeChange(ch.Test1));

// var sc = new ShortestCompletingWordClass();
//
// var a = sc.ShortestCompletingWord("1s3 PSt", new[] { "step", "steps", "stripe", "stepple" });
// Console.WriteLine(a);


// var intr = new Intervals();
//
// var a1 = new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };
// var a2 = new[] { new[] { 1, 3 }, new[] { 4, 5 } };
// var a3 = new[] { new[] { 1, 4 }, new[] { 0, 2 } };
//
// var b = intr.Merge(a3);

// var sd = new StringDiv();
//
// //Console.WriteLine(sd.GcdOfStrings("ABCABC", "ABC"));
// Console.WriteLine(sd.GcdOfStrings("ABABAB", "ABAB"));
// Console.WriteLine(sd.GcdOfStrings("LEET", "CODE"));

// var fw = new FindWord();
//
// var w1 = new[]
// {
//     new[] { 'A', 'B', 'C', 'E' }, 
//     new[] { 'S', 'F', 'C', 'S' }, 
//     new[] { 'A', 'D', 'E', 'E' }
// };
//
// var w2 = new[]
// {
//     new[] { 'A' } 
// };
// var word = "ABCCEED";
// Console.WriteLine(fw.Exist(w1, word));
// Console.WriteLine(fw.Exist(w2, "A"));

// var aa = "123";
// var bb = aa[1..];
//
// var p = new PathWithMinEffort();
//
// var m1 = new[]
// {
//     new[] { 1, 2, 2 },
//     new[] { 3, 8, 2 },
//     new[] { 5, 3, 5 }
// };
//
// var m2 = new[]
// {
//     new[] { 1, 2, 1, 1, 1 },
//     new[] { 1, 2, 1, 2, 1 },
//     new[] { 1, 2, 1, 2, 1 },
//     new[] { 1, 2, 1, 2, 1 },
//     new[] { 1, 1, 1, 2, 1 }
// };
//
// var m3 = new[] { new[] { 1, 10, 6, 7, 9, 10, 4, 9 } };
//
// Console.WriteLine(p.MinimumEffortPath(m3));
// Console.WriteLine(p.MinimumEffortPath(m2));
// Console.WriteLine(p.MinimumEffortPath(m1));

//
// var ds = new DirectoryServices1();
//
// var dirs = new[] { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" };
//
// var rr = ds.RemoveSubfolders(dirs);
//
// foreach (var r in rr)
// {
//     Console.WriteLine(r);
// }

// var sl = new NextGreaterElement1();
//
// var nums1 = new int[] { 4, 1, 2 }; 
// var nums2 = new int[] { 1, 3, 4, 2 };
// sl.NextGreaterElement(nums1, nums2);

// var textFile = File.OpenText(@"..\..\..\..\Data\WP.txt");
// var words = textFile.ReadToEnd().Split(' ', StringSplitOptions.RemoveEmptyEntries);
//
// var n = 1500;
// var k = words.Length;
//
// while (n > 3)
// {
//     var d = new int[n];
//
//     foreach (var w in words)
//     {
//         var v = (uint)w.GetHashCode() % n;
//         d[v]++;
//     }
//
//     var r = d.Select(x => x * 1d / k).ToArray();
//     
//
//     var avg = r.Average();
//     var sq = Math.Sqrt(r.Select(x => x - avg).Select(x => x * x).Sum() / n);
//     Console.WriteLine($"{n}, {avg*100:F2}, {sq*1000:F3}");
//     n--;

//    var tops = r.Select((x, i) => (x, i)).OrderByDescending(x => x.x).Take(5).Select(x => x).ToList();
//    var bottoms = r.Select((x, i) => (x, i)).OrderBy(x => x.x).Take(5).Select(x => x).ToList();
//    var str_tops = string.Join(", ", tops.Select(x => $"{x.i}:{x.x:F2}"));
//    var str_bottoms = string.Join(", ", bottoms.Select(x => $"{x.i}:{x.x:F2}"));
//    Console.WriteLine(str_tops);
//    Console.WriteLine(str_bottoms);
//}

// var sl = new SameLine();
// Console.WriteLine(sl.CheckStraightLine(new[] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 5, 5 } }));
// Console.WriteLine(sl.CheckStraightLine(new[] { new[] { 1, 2 }, new[] { 2, 4 }, new[] { 5, 10 } }));
// Console.WriteLine(
//     sl.CheckStraightLine(
//         new[]
//         {
//             new[] { 1, 1 },
//             new[] { 2, 2 },
//             new[] { 3, 4 },
//             new[] { 4, 5 },
//             new[] { 5, 6 },
//             new[] { 7, 7 }
//         }));
//
// Console.WriteLine(
//     sl.CheckStraightLine(
//         new[]
//         {
//             new[] { 1, 2 },
//             new[] { 2, 3 },
//             new[] { 3, 4 },
//             new[] { 4, 5 },
//             new[] { 5, 6 },
//             new[] { 6, 7 }
//         }));

// var ni = new NumberOfIslandsClass();
// var a = new[]
// {
//     new []{ '1', '1', '0', '0', '0' },
//     new []{ '1', '1', '0', '0', '0' },
//     new []{ '0', '0', '1', '0', '0' },
//     new []{ '0', '0', '0', '1', '1' }
// };
//
// Console.WriteLine(ni.NumIslands(a));

// var lp = new LargestNumberClass();
//
// var a = new int[] { 3, 30, 34, 5, 9 };
// var b = new int[] { 10, 2 };
// var c = new int[] { 34323, 3432 };
// var d = new int[] { 1, 0 };
// //var a = new int[] { 3, 30, 34 };
//
// Console.WriteLine(lp.LargestNumber(d));
// Console.WriteLine(lp.LargestNumber(a));
// Console.WriteLine(lp.LargestNumber(b));
// Console.WriteLine(lp.LargestNumber(c));

//var fmp = new FirstMissingPositive();
//Console.WriteLine(fmp.Compute(new[] { 1 }));
// Console.WriteLine(fmp.Compute(new[] { 1, 3, 1 }));
// Console.WriteLine(fmp.Compute(new[] { 4, 1, 2, 6, -333, 0 }));
// Console.WriteLine(fmp.Compute(new[] { 7, 8, 9, 11, 12 }));

//var wc = new WildCards();

// Console.WriteLine("{0} {1}", wc.IsMatch("", "**"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "*?*?*?*?"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "*"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("a", "a****"), true);
//
// Console.WriteLine(
//     "{0} {1}",
//     wc.IsMatch(
//         "abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb",
//         "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb"),
//     false);
//
// Console.WriteLine(
//     "{0} {1}",
//     wc.IsMatch("bbbbbbbabbaabbabbbbaaabbabbabaaabbababbbabbbabaaabaab", "b*b*ab**ba*b**b***bba"),
//     false);
// Console.WriteLine("{0} {1}", wc.IsMatch("a", "a****"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abczzzde", "abc???de*"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcabczzzde", "*abc???de*"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "abcd"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "ab?d"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "ab?dd"), false);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "*"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "*?c*"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("abcd", "a?c*"), true);
// Console.WriteLine("{0} {1}", wc.IsMatch("", "*"), true);

// var sum = 0d;
// var count = 0;
// for (var i = 0; i < 50; i++)
// {
//     var p = new Primes();
//     var sw = Stopwatch.StartNew();
//     var n = p.CountPrimes(100_000_000);
//     sw.Stop();
//     count++;
//     sum += sw.ElapsedMilliseconds;
//     Console.WriteLine($"{n} {sw.ElapsedMilliseconds}ms {sum/count:F0}ms");
// }

// var ms = new MaximumCount();
//
// Console.WriteLine(ms.Compute(new[] { 1, 2, 3, 4 }));
// Console.WriteLine(ms.Compute(new[] { -3, -2, -1 }));
//
// Console.WriteLine(ms.Compute(new[] { -3, -2, -1, 0, 0, 1, 2, 3, 5 }));
// Console.WriteLine(ms.Compute(new[] { -3, -2, -1, 0, 0, 1, 2 }));
// Console.WriteLine(ms.Compute(new[] { 0, 0, 1, 2 }));

//var sq = new SimpleSqrt();
//Console.WriteLine(sq.MySqrt(4));
//Console.WriteLine(sq.MySqrt(2147483647));

//
// var sm = new SpiralMatrixTask();
// var m = new int[][]
// {
// 	new[] { 1, 2, 3, 4 },
// 	new[] { 5, 6, 7, 8 },
// 	new[] { 9, 10, 11, 12 }
// };
//
// var m3 = new int[][]
// {
// 	new[] { 1, 2, 3 },
// 	new[] { 8, 9, 4 },
// 	new[] { 7, 6, 5 }
// };

//Console.WriteLine(string.Join(", ", sm.SpiralOrder(m)));

//var wp = new WordPatternTask();
//wp.WordPattern("aba", "dog cat cat");
//MaximalRectangleTask.TestPerf();

//var zz = new ZigzagLevelOrderTask();

//zz.ZigzagLevelOrder(new(1, new(2), new(3, new(4), new(5))));
//zz.ZigzagLevelOrder(new(1, new(2, new(4)), new(3, null, new(5))));

// var ms = new MySqrtTask();
// ms.MySqrt(4);
// ms.MySqrt(2147483647);
// ms.MySqrt(2147395599);

//var ra = new RectangleArea();
//Console.WriteLine(ra.ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2));

// var ss = new SubsetsTask();
// var r = ss.Subsets(new[] { 1, 2, 3 });
//
// Console.WriteLine(string.Join(", ", r.Select(x => "[" + string.Join(", ", x) + "]")));
//
// return;
// var pr = new PerfectRectangle();
//
// var r1 = new[] { new[] { 1, 1, 3, 3 }, new[] { 3, 1, 4, 2 }, new[] { 3, 2, 4, 4 }, new[] { 1, 3, 2, 4 }, new[] { 2, 3, 3, 4 } };
// var r2 = new[] { new[] { 1, 1, 2, 3 }, new[] { 1, 3, 2, 4 }, new[] { 3, 1, 4, 2 }, new[] { 3, 2, 4, 4 } };
// var r3 = new[] { new[] { 0, 0, 4, 1 }, new[] { 0, 0, 4, 1 } };
// var r4 = pr.ReadTestData("TestData/PerfectRectangle.txt");
//
// Console.WriteLine(pr.IsRectangleCover(r4));
// Console.WriteLine(pr.IsRectangleCover(r3));
// Console.WriteLine(pr.IsRectangleCover(r1));
// Console.WriteLine(pr.IsRectangleCover(r2));

// var rl = new RotateListTask();
// var r = rl.RotateRight(new(1, new(2, new(3))), 1);
// return;

// var mcmae = new MinimumCostToMakeArrayEqual();
// mcmae.MinCost(new[] { 2, 2, 2, 2 }, new[] { 2, 3, 1, 14 });
// Console.WriteLine(mcmae.MinCost(new[] { 1, 3, 5, 2 }, new[] { 2, 3, 1, 14 }));
//
// var nums = new[]
// {
// 	735103, 366367, 132236, 133334, 808160, 113001, 49051, 735598, 686615, 665317, 999793, 426087, 587000, 649989, 509946,
// 	743518
// };
//
// var cost = new[]
// {
// 	724182, 447415, 723725, 902336, 600863, 287644, 13836, 665183, 448859, 917248, 397790, 898215, 790754, 320604, 468575,
// 	825614
// };

//Console.WriteLine(mcmae.MinCost(nums, cost));

// var spt = new ShortestPalindromeTask();
// Console.WriteLine(spt.ShortestPalindrome("aaa"));
// Console.WriteLine(spt.ShortestPalindrome("aacecaaa"));
//
// var lmt = new LargestMultipleOfThreeTask();
// Console.WriteLine(lmt.LargestMultipleOfThree(new[] { 8, 1, 9 }));
// Console.WriteLine(lmt.LargestMultipleOfThree(new[] { 1, 1, 0 }));
// Console.WriteLine(lmt.LargestMultipleOfThree(new[] { 8, 6, 7, 1, 0 }));

// var md = new MedianFinder();
// var md = new MedianFinder();
// md.AddNum(6);
// Console.WriteLine(md.FindMedian());
// md.AddNum(10);
// Console.WriteLine(md.FindMedian());
// md.AddNum(2);
// Console.WriteLine(md.FindMedian());
// md.AddNum(6);
// Console.WriteLine(md.FindMedian());

//
// var bc = new BasicCalculator();
// Console.WriteLine(bc.Calculate("1+2"));

// var mr = new MaximalRectangleTask();
// var matrix = new[]
// {
// 	new[] { '1', '0', '1', '0', '0' },
// 	new[] { '1', '0', '1', '1', '1' },
// 	new[] { '1', '1', '1', '1', '1' },
// 	new[] { '0', '0', '0', '0', '0' },
// 	new[] { '1', '1', '1', '1', '1' }
// };
//
// var sw = Stopwatch.StartNew();
// Console.WriteLine("{0} in {1}ms", mr.MaximalRectangle(matrix), sw.ElapsedMilliseconds);
//
//
// var data = mr.ReadTestData("TestData/MaximalRectangleTask_test1.txt");
// sw.Restart();
// Console.WriteLine("{0} in {1}ms", mr.MaximalRectangle(data), sw.ElapsedMilliseconds);
//
// Console.WriteLine(mr.MaximalRectangle(new[]{new[]{'0'}}));
// Console.WriteLine(mr.MaximalRectangle(new[]{new[]{'1'}}));

// var eao = new ExpressionAddOperators();
//
// //var rr = eao.AddOperators("1234567890", 5);
// var sw = Stopwatch.StartNew();
// //var rr = eao.AddOperators("3456237490", 9191);
// var rr = eao.AddOperators("105", 5);
// Console.WriteLine(sw.Elapsed);
// Console.WriteLine(eao.Computed);
//
// foreach (var r in rr)
// {
// 	Console.WriteLine(r);
// }
//
// Console.WriteLine($"Total = {rr.Count}");

//
// Console.WriteLine(FurthestBuilding.Solve(new[] { 1, 2, 2 }, 0, 0));
// Console.WriteLine(FurthestBuilding.Solve(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2));
// Console.WriteLine(FurthestBuilding.Solve(new[] { 14, 3, 19, 3 }, 17, 0));
// Console.WriteLine(FurthestBuilding.Solve(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1));
//
// var data1 = FurthestBuilding.ReadTestData("TestData/FurthestBuilding_test1.txt");
// var sw1 = Stopwatch.StartNew();
// Console.WriteLine(FurthestBuilding.Solve(data1.Heights, data1.Bricks, data1.Ladders));
// Console.WriteLine(sw1.Elapsed);
//
// var data2 = FurthestBuilding.ReadTestData("TestData/FurthestBuilding_test2.txt");
// var sw2 = Stopwatch.StartNew();
// Console.WriteLine(FurthestBuilding.Solve(data2.Heights, data2.Bricks, data2.Ladders));
// Console.WriteLine(sw2.Elapsed);

//4,8,0,5,0,15,2,0,16

// var p = new Permutations();
//
// foreach (var s in p.Permute(new[] { 0, 1 }))
// {
// 	Console.WriteLine(string.Join(", ", s));
// }

//
// // Fancy fancy1 = new Fancy();
// // fancy1.Append(2);   // fancy sequence: [2]
// // fancy1.AddAll(3);   // fancy sequence: [2+3] -> [5]
// // fancy1.Append(7);   // fancy sequence: [5, 7]
// // fancy1.MultAll(2);  // fancy sequence: [5*2, 7*2] -> [10, 14]
// // fancy1.GetIndex(0); // return 10
// // fancy1.AddAll(3);   // fancy sequence: [10+3, 14+3] -> [13, 17]
// // fancy1.Append(10);  // fancy sequence: [13, 17, 10]
// // fancy1.MultAll(2);  // fancy sequence: [13*2, 17*2, 10*2] -> [26, 34, 20]
// // fancy1.GetIndex(0); // return 26
// // fancy1.GetIndex(1); // return 34
// // fancy1.GetIndex(2); // return 20
//
// Fancy fancy2 = new Fancy();
// fancy2.Append(5);
// fancy2.Append(8);
// fancy2.MultAll(6);
// fancy2.GetIndex(0);
// fancy2.GetIndex(1);
// fancy2.MultAll(2);
// fancy2.MultAll(5);
// Console.WriteLine(fancy2.GetIndex(1));
//
// var fancy = new Fancy();
//
// fancy.Append(12);
// fancy.Append(8);
// fancy.GetIndex(1);
// fancy.Append(12);
// fancy.GetIndex(0);
// fancy.AddAll(12);
// fancy.Append(8);
// fancy.GetIndex(2);
// fancy.GetIndex(2);
// fancy.Append(4);
// fancy.Append(13);
// fancy.GetIndex(4);
// fancy.Append(12);
// fancy.GetIndex(6);
// fancy.Append(11);
// fancy.GetIndex(1);
// fancy.Append(10);
// fancy.GetIndex(2);
// fancy.MultAll(3);
// fancy.AddAll(1);
// fancy.GetIndex(6);
// fancy.Append(14);
// fancy.AddAll(5);
// fancy.GetIndex(6);
// fancy.MultAll(12);
// fancy.GetIndex(3);
// fancy.MultAll(12);
// fancy.AddAll(15);
// fancy.AddAll(6);
// fancy.Append(7);
// fancy.MultAll(8);
// fancy.Append(13);
// fancy.Append(15);
// fancy.Append(15);
// fancy.MultAll(10);
// fancy.GetIndex(9);
// fancy.MultAll(12);
// fancy.MultAll(12);
// fancy.MultAll(9);
// fancy.GetIndex(9);
// fancy.AddAll(9);
// fancy.Append(9);
// fancy.MultAll(4);
// fancy.AddAll(8);
// fancy.AddAll(11);
// fancy.MultAll(15);
// fancy.AddAll(9);
// fancy.AddAll(1);
// fancy.Append(4);
// fancy.Append(10);
// Console.WriteLine(fancy.GetIndex(9));
// Console.WriteLine(fancy.GetIndex(9));

return;

var eq = new EqualFrequency();
Console.WriteLine("{0},{1}", true, eq.Solve("zz"));
Console.WriteLine("{0},{1}", false, eq.Solve("cbccca"));
Console.WriteLine("{0},{1}", false, eq.Solve("abbccc"));
Console.WriteLine("{0},{1}", true, eq.Solve("abbcc"));
Console.WriteLine("{0},{1}", true, eq.Solve("abcc"));

Console.WriteLine("{0},{1}", true, eq.Solve("cccaa"));
Console.WriteLine("{0},{1}", true, eq.Solve("bac"));
Console.WriteLine("{0},{1}", false, eq.Solve("ddaccb"));

Console.WriteLine("{0},{1}", false, eq.Solve("aazz"));
Console.WriteLine("{0},{1}", true, eq.Solve("aazzd"));
Console.WriteLine("{0},{1}", true, eq.Solve("abb"));

//
// var data = new char[9][]
// {
// 	new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
// 	new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
// 	new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
// 	new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
// 	new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
// 	new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
// 	new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
// 	new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
// 	new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
// };

//var ss = new Sudoku();

//Console.WriteLine(ss.IsValidSudoku(data));
//
// var r1 = ContainerWithMostWater.MaxArea(new[] { 1, 2, 3 });
// var r2 = ContainerWithMostWater.MaxArea(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });

// var r = string.Join(", ", LetterCombinations.Solve(""));
// Console.WriteLine(r);

//var ga = new Anagrams();

//var a = ga.GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });

//var gl = new LongestPalindrome();

// Console.WriteLine(gl.GetLongestPalindrome("a"));
// Console.WriteLine(gl.GetLongestPalindrome("ac"));
// Console.WriteLine(gl.GetLongestPalindrome("aacabdkacaa"));
//
// Console.WriteLine(gl.GetLongestCommon("aaabbdccabe", "aaabbdccabe"));
// Console.WriteLine(gl.GetLongestCommon("aaabbdccabe", "bbcca"));

var arr = new[] { 1, 5, 1, 2, 2, 3, 8, 4, 0, 0 };

// 1, 5, 1, 2, 2, 3, 8, 4, 0, 0
// 0, 5, 1, 2, 2, 3, 8, 4, 0, 1
// 0, 5, 1, 2, 2, 3, 8, 4, 0, 1

//[5,4,6,null,null,3,7]
// TreeNode node = new(5, new(4), new(6, new(3), new(7)));
// TreeNode node2 = new(
// 	120,
// 	new(70, new(50, new(20), new(55)), new(100, new(75), new(110))),
// 	new(140, new(130, new(119), new(135)), new(160, new(150), new(200))));
//
// TreeNode node3 = new(int.MaxValue);
// TreeNode node4 = new(int.MinValue);
//
// var cb = new CheckBinSearchTree();
// Console.WriteLine(cb.IsValidBST(node4));


//var kf = new TopKFreq();
//Console.WriteLine(string.Join(", ", kf.GetTopK(arr, 2)));


//Console.WriteLine(ThreeSumClosest.Compute(new [] {-1, 2, 1, -4}, 1));

// Console.WriteLine(SquareSums.GetPermutations(new[] { 2, 2, 2, 2 }));
// Console.WriteLine(SquareSums.GetPermutations(new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }));
// Console.WriteLine(SquareSums.GetPermutations(new[] { 1, 17, 8 }));
// Console.WriteLine(SquareSums.GetPermutations(new[] { 2, 2, 2 }));
// Console.WriteLine(SquareSums.GetPermutations(new[] { 2, 2, 1 }));
// Console.WriteLine(SquareSums.GetPermutations(new[] { 2, 23, 2 }));
//Console.WriteLine(DivideNumbers.Compute(-2147483648, 2));
//Console.WriteLine(DivideNumbers.Compute(10, 3));


//Console.WriteLine(LongestBraces.Compute("()"));
// Console.WriteLine(LongestBraces.Compute("))))((()(("));
// Console.WriteLine(LongestBraces.Compute("()(()"));
// Console.WriteLine(LongestBraces.Compute(")()())"));
// Console.WriteLine(LongestBraces.Compute(")()())((((())))(())()()()()())))))"));
// Console.WriteLine(LongestBraces.Compute("(()"));