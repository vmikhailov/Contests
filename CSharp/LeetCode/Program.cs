using LeetCode;

var data = new char[9][]
{
	new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
	new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
	new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
	new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
	new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
	new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
	new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
	new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
	new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};

var ss = new Sudoku();

Console.WriteLine(ss.IsValidSudoku(data));
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