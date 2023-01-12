#include <iostream>
#include <vector>
#include "SummaryRangesTask.h"
#include "RotateImage.h"
#include "PascalTriangle.h"
#include "SerializeDeserializeBinSearchTree.h"
#include "SerializeDeserializeBinTree.h"
#include "SetMatrixZeros.h"
#include "Shift2DGrid.h"
#include "IsSubsequence.h"
#include "DeciBinaryPartTask.h"
#include "StrictlyPalindromicNumberTask.h"
#include "PrimesTest.h"
#include "PerfBinTree.h"

using namespace std;

int main() {

    perf_test_main(21);
//    auto pt = new PrimeTest();
//    pt->primeTest();
//    auto spn = new StrictlyPalindromicNumberTask();
//
//    cout << spn->isStrictlyPalindromic(19);

//    auto dp = new DeciBinaryPartTask();
//
//    cout << dp->minPartitions("32");

//    vector<vector<int>> mat = {{0, 0, 0, 5},
//                               {4, 3, 1, 4},
//                               {0, 1, 1, 4},
//                               {1, 2, 1, 3},
//                               {0, 0, 1, 1}};
//
//    auto smz = new SetMatrixZeros();
//
//        MatrixHelpers::print(mat);
//    smz->setZeroes(mat);
//    MatrixHelpers::print(mat);

//    auto is = new IsSubsequence();
//    cout << is->isSubsequence("abc", "ahbgdc");
//    cout << is->isSubsequence("abx", "ahbgdc");

//    auto sg = new Shift2dGrid();
//
//    vector<vector<int>> mat = {{3,  8, 1,  9},
//                               {19, 7, 2,  5},
//                               {4,  6, 11, 10},
//                               {12, 0, 21, 13}};

    //sg->shiftGrid(mat, 4);

//    auto sr = new SerializeDeserializeBinTree();
//    //[1,2,3,null,null,4,5]
//    auto s = sr->serialize(new TreeNode(1, new TreeNode(2), nullptr));
//    //auto s = sr->serialize(new TreeNode(1, new TreeNode(2), new TreeNode(3, new TreeNode(4), new TreeNode(5))));
//    cout << s << endl;
//    auto t = sr->deserialize(s);

//    auto sr = new SerializeDeserializeBinSearchTree();
//    auto s = sr->serialize(new TreeNode(2, new TreeNode(1), new TreeNode(3)));
//    cout << s << endl;
//    auto t = sr->deserialize(s);

//    auto pt = new PascalTriangle();
//    pt->generate(20);


    //auto srt = new SummaryRangesTask();
    //vector<int> data = {1, 2, 3, 4, 5, 7, 8};
    //vector<string> result = srt->summaryRanges(data);

//    vector<vector<int>> data1 = {{5,  1,  9,  11},
//                                 {2,  4,  8,  10},
//                                 {13, 3,  6,  7},
//                                 {15, 14, 12, 16}};
//
//    vector<vector<int>> data2 = {{5,  1,  9,  11, 7},
//                                {2,  4,  8,  10, 3},
//                                {13, 3,  6,  7, 11},
//                                {15, 14, 12, 16, 22},
//                                {21, 22, 23, 24, 4}};
//
//    vector<vector<int>> data3 = {{1,  2},
//                                 {4,  3}};
//
//    auto data = data1;
//    auto ri = new RotateImageTask();
//    cout << "Before" << endl;
//    ri->print(data);
//
//    ri->rotate(data);
//
//    cout << "After" << endl;
//    ri->print(data);
//    return 0;
}
