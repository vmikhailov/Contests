using LeetCode;


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