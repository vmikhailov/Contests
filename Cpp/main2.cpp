// conditionVariables.cpp

#include <condition_variable>
#include <iostream>
#include <string>
#include <thread>
#include <coroutine>

std::mutex mutex_;
std::condition_variable condVar;

#include <chrono>
#include <unordered_map>


std::atomic<int> atomic;

bool dataReady{false};

void waitingForWork() {
    std::cout << "waitingForWork: " << "Sleeping " << std::endl;

    std::cout << "waitingForWork: " << "Waiting " << std::endl;
    std::unique_lock<std::mutex> lck(mutex_);
    std::cout << "waitingForWork: " << "Lock created " << std::endl;
    std::this_thread::sleep_for(std::chrono::seconds(1));

//    condVar.wait(lck);
    condVar.wait(lck, [] {
        std::cout << "waitingForWork: " << "Checking guard: " << dataReady << std::endl;
        return dataReady;
    });   // (4)
    std::cout << "waitingForWork: " << "Running " << dataReady << std::endl;
}

void setDataReady() {
    std::cout << "setDataReady: " << "Enter" << std::endl;
    {
        std::cout << "setDataReady: " << "Locking" << std::endl;
        std::lock_guard<std::mutex> lck(mutex_);
        std::cout << "setDataReady: " << "Locked" << std::endl;
        dataReady = true;
    }
    std::cout << "setDataReady: " << "Data prepared" << std::endl;
    condVar.notify_one();                        // (3)
}

#include <future>
#include <vector>
#include <list>
#include <random>
#include <unordered_set>
#include "CountPer.h"
#include "SearchInRotatedSortedArray.h"
#include "MaximumSplit.h"
#include "RptString.h"
#include "IsomorphicString.h"
#include "StringsGTD.h"

std::default_random_engine rnd(time(nullptr));
std::uniform_int_distribution<int> distribution(1000, 1500);

void sleepRandom() {
    //auto v = distribution(rnd);
    auto v = 50;
    std::this_thread::sleep_for(std::chrono::milliseconds(v));
}

static std::atomic<int> id = 1;

int getId() {
    sleepRandom();
    return id++;
}

class SomeString{
public:
    SomeString(const string& s): value_{s}{
        cout << "SomeString ctor\n";
    }

    SomeString(const SomeString& ss): value_{ss.value_}{
        cout << "SomeString copy ctor\n";
    }

    SomeString(const SomeString&& ss): value_{ss.value_}{
        cout << "SomeString move ctor\n";
    }
    std::string value_;
};

class Settings{
public:
    int intValue;
    SomeString strValue;
};

class SomeClass{
public:
    SomeClass(Settings settings){
        cout << "SomeClass ctor\n";
    }
};

int main() {
    cout << "step 1\n";
    Settings s{1, string("test") };
    cout << "step 2\n";
    SomeClass a(s);


//    StringsGTD st;
//    cout << st.gcdOfStrings("ABCABC","ABC");

//    IsomorphicString is;
//    cout << is.isIsomorphic("foo", "bar");

//    unordered_map<char, int> h;
//
//    h.find('a');
//    h.insert(std::pair('a', 1));
//
//    unordered_set<char> st;
//
//    auto a1 = st.insert('a');
//    auto i1 = get<0>(a1);
//    auto b1 = get<1>(a1);
//    auto a2 = st.insert('a');
//    auto i2 = get<0>(a2);
//    auto b2 = get<1>(a2);
//
//    RptString rpt;
//    cout << rpt.repeatedSubstringPattern("abac");

//    MaximumSplit ms;
//    auto r = ms.maximumEvenSplit(12);
//
//    for(auto p: r)
//    {
//        cout << p;
//    }
//    cout << std::endl;

////    CountPer cp;
////    vector<vector<int>> s = {{0, 1, 0, 0},
////                             {1, 1, 1, 0},
////                             {0, 1, 0, 0},
////                             {1, 1, 0, 0}};
////    cout << cp.islandPerimeter(s);
//
//    vector<int> s = {4, 5, 6, 7, 8, 0, 1, 2};
//                  //{0, 1, 2, 4, 5, 6, 7, 8};
//    //vector<int> s = {6, 1, 2, 3, 4, 5};
//
//    SearchInRotatedSortedArray sirsa;

//    cout << sirsa.search(s, 2);



//    std::list<std::future<int>> tasks{};
//    std::vector<std::future<int>> resultsFut{};
//    std::vector<int> results{};
//
//    int n = 2;
//    int km = 10;
//    for(auto i = 1; i < 25; i++) {
//        auto begin = std::chrono::steady_clock::now();
//
//        for(auto k = 0; k < km; k++) {
//            tasks.clear();
//            resultsFut.clear();
//            results.clear();
//            id = 1;
//            for (auto j = 0; j < n; j++) tasks.push_back(std::async({} { return getId(); }));
//            for (auto &task: tasks) results.push_back(task.get());
//        }
//
//        auto end = std::chrono::steady_clock::now();
//        auto s1 = std::accumulate(results.begin(), results.end(), 0);
//        auto s2 = n * 1L * (n + 1) / 2;
//
//        std::cout
//                << n << " "
//                << std::chrono::duration_cast<std::chrono::milliseconds>(end - begin).count()/km << " "
//                << s1 - s2
//                << std::endl;
//        n *= 2;
//    }
//
//    std::cout << std::endl;
}