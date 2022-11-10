using System.Diagnostics;
using CodeForcesSimple.LeetCode;
using LeetCode;
using LeetCode.Tasks;


MaximalRectangleTask.TestPerf();
//
// var zz = new ZigzagLevelOrderTask();
//
// zz.ZigzagLevelOrder(new(1, new(2), new(3, new(4), new(5))));
// zz.ZigzagLevelOrder(new(1, new(2, new(4)), new(3, null, new(5))));

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