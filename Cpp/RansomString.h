#pragma once
#include <iostream>
#include <set>
using namespace std;

class RansomString {
public:
    bool canConstruct(string&& ransomNote, string&& magazine) {
        set<char> s1{};
        set<char> s2{};

        for(auto c: ransomNote) s1.insert(c);
        for(auto c: magazine) s2.insert(c);

        return includes(begin(s2), end(s2), begin(s1), end(s1));
    }
};