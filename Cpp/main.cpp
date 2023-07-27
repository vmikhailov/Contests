#include <iostream>
#include <vector>
#include <chrono>
#include <ranges>
#include <queue>
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
#include "bimap.h"
#include "RandomMatrix.h"
#include "bimap2.h"
#include "t1.h"
#include "t2.h"
#include "move_all_zeros.h"
#include "RemoveMatching.h"
#include "GroupAnagrams.h"
#include "GroupAnagramsData.h"
#include "MaxLevelSum.h"
#include "ReversePar.h"
#include "LongestNonRepeatingSec.h"
#include "Primes.h"
#include "MaximumBombs.h"
#include "RansomString.h"
#include "FascinatingNumber.h"
#include "IsPalindromeListClass.h"
#include <boost/bimap.hpp>
#include <future>

using namespace std;
using std::chrono::high_resolution_clock;
using std::chrono::duration_cast;
using std::chrono::duration;
using std::chrono::milliseconds;

typedef boost::bimap<int, std::string> bm_type;

struct Data {
    int X;
    int Y;

    Data() : X(0), Y(0) {
        cout << "Ctor 0\n";
    }

    ~Data() {
        cout << "Del " << X << " " << Y << "\n";
    }

    Data(int x, int y) : X(x), Y(y) {
        cout << "Ctor " << X << " " << Y << "\n";
    }

    Data(int x, int y, int z) : X(x), Y(y) {
        cout << "Ctor " << X << " " << Y << "\n";
    }

    Data(const Data &d) : X(d.X), Y(d.Y) {
        cout << "Copy " << X << " " << Y << endl;
    }

    Data(Data &&d) noexcept: X(d.X), Y(d.Y) {
        cout << "Move " << X << " " << Y << endl;
    }
};

template<typename T>
struct Enumerator {
    virtual T getCurrent() = 0;

    virtual bool moveNext() = 0;

    virtual void reset() = 0;
};

template<typename T>
struct Enumerable {
    virtual Enumerator<T> getEnumerator() = 0;
};

template<typename T1, typename T2>
Enumerator<T2> select(Enumerator<T1> &src, T2 (*selector)(T1 x)) {
    while (src.moveNext()) {

    }
}

int run(int (*body)()) {
    auto t1 = high_resolution_clock::now();
    auto v = body();
    auto t2 = high_resolution_clock::now();
    auto ms_int = duration_cast<milliseconds>(t2 - t1);
    return (int) ms_int.count();
}

int main1() {
    return 0;
};

//    IsPalindromeListClass ip;
//    ListNode* head = new ListNode(1, new ListNode(0, new ListNode(1)));
//    cout << ip.isPalindrome(head);
//    delete head;

    //FascinatingNumber fn;
    //cout << fn.isFascinating(102);
    //RansomString rs;
    //cout << rs.canConstruct("aa", "ab");

//    MaximumBombs mb;
//    std::vector<std::vector<int>> a = {{2, 1, 3},
//                                       {6, 1, 4}};
//
//    std::vector<std::vector<int>> b = {{1, 2, 3},
//                                       {2, 3, 1},
//                                       {3, 4, 2},
//                                       {4, 5, 3},
//                                       {5, 6, 4}};
//
//    std::vector<std::vector<int>> c = {{1,  1,  100},
//                                       {81, 61, 60}};
//    cout << mb.maximumDetonation(c);

//    unordered_set<int> st;
//    auto aa= get<1>(st.insert(5));
//    auto bb= get<1>(st.insert(5));
//
//    int sum = 0;
//    int count = 0;
//    unordered_map<int, string> aaa{};
//    for (int i = 0; i < 200; i++) {
//        auto t1 = high_resolution_clock::now();
//        Primes pp;
//        auto ms = pp.countPrimes(100000000);
//        auto t2 = high_resolution_clock::now();
//        auto ms_int = duration_cast<milliseconds>(t2 - t1);
//        sum += ms_int.count();
//        count++;
//        cout << ms << " " << ms_int.count() << "ms " <<  sum/count << "ms\n";
//    }

    //
//    ReversePar rp;
//    string s{"((hello) (a) (world))"};
//    auto ss = rp.reverseParentheses(s);
//    cout << ss;
//}
//    FindMaxLevelSum sm;
//
//    auto tn = new TreeNode(1, new TreeNode(7, new TreeNode(8), new TreeNode(-1)), new TreeNode(0));
//    auto l = sm.maxLevelSum(tn);
//    cout << l;
//    delete tn;

//    //GroupAnagrams ga;
//    //auto aa = vector<string>{"eat","tea","tan","ate","nat","bat"};
//    //auto aa = vector<string>{"ddddddddddg","dgggggggggg"};
//
//
//    map<int, Data> dmap{{1, Data(1, 1)},
//                        {2, Data(2, 2)}};
//
//    std::cout << endl;
//    vector<Data> datas;
//    datas.reserve(dmap.size());
//
//    for (auto &a: dmap) {
//        datas.push_back(std::move(a.second));
//    }
//
//    std::cout << endl;


//    using std::chrono::high_resolution_clock;
//    using std::chrono::duration_cast;
//    using std::chrono::duration;
//    using std::chrono::milliseconds;
//
//    auto t1 = high_resolution_clock::now();
//    auto rr = ga.groupAnagrams(GroupAnagramData::LargeData2);
//    auto t2 = high_resolution_clock::now();
//
//    /* Getting number of milliseconds as an integer. */
//    auto ms_int = duration_cast<milliseconds>(t2 - t1);
//    cout << ms_int.count() << "ms\n";
//
//    for (auto &r: rr) {
//        if(r.size() > 1) {
//            for (auto &s: r) {
//                cout << s << " ";
//            }
//            cout << endl;
//        }
//    }


//    RemoveMatching r;
//    std::vector<int> v1{1, 2, 3, 4, 5, 5, 5, 5, 5, 0};
//    std::vector<int> v{1};
//    auto x = r.remove(v, 1);
//    cout << x << ": ";
//    for(auto i: v){
//    cout << i << ", ";
//    }
//    cout << endl;
//
//    moveZeros(v);
//
//    for (int x: v) {
//        cout << x << ", ";
//    }

//    cout << endl;

//    TextInput* input = new NumericInput();
//    input->add('1');
//    input->add('a');
//    input->add('0');
//    std::cout << input->getValue();

//    std::vector<std::string> names1 = {"Ava", "Emma", "Olivia1"};
//    std::vector<std::string> names2 = {"Olivia", "Sophia", "Emma"};
//
//    std::vector<std::string> result = unique_names(names1, names2);
//    for(auto& element : result)
//    {
//        std::cout << element << ' '; // should print Ava Emma Olivia Sophia
//    }
//

//    auto bm = bimap2::Bimap<int, string>();
//    bm.set(1, "aaa");
//    bm.removeKey(1);
//
//    cout << bm.size() << endl;
//    bm.set(2, "aabb");
//    bm.set(3, "aabb");
//    bm.removeKey(1);
//
//    auto &keys = bm.keysByValue("aabb");
//
//    cout << "keys for : aabb" << keys.size() << endl;
//    cout << bm.size() << endl;

//    auto rm = new RandomMatrix();
//    rm->print();

//    auto bbm = bm_type();
//    bbm.insert(bm_type::value_type(1, "aaa"));
//    bbm.insert(bm_type::value_type(3, "aaa"));
//    bbm.insert(bm_type::value_type(2, "bbb"));
//
//    auto bm = bimap::Bimap<int, string>();
//    bm.set(1, "aaa");
//    bm.set(3, "aaa");
//    bm.set(2, "bbb");
//
//
//    cout << bm.keysForValue("aaa").size();


//perf_test_main(21);
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

