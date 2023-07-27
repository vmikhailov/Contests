#pragma once
#include <iostream>
#include <vector>
#include <unordered_map>
using namespace std;

class IsomorphicString {
public:
    bool isIsomorphic(string s, string t) {
        if(s.size() != t.size()) return false;

        return toVector(s) == toVector(t);
    }

    vector<int> toVector(const string& s){
        unordered_map<char, int> h;
        vector<int> r;
        r.reserve(s.size());
        auto p = 0;
        for(auto c: s){
            auto t = h.find(c);
            if(t != h.end()){
                r.push_back(t->second);
            }
            else{
                r.push_back(p);
                h.insert(pair(c, p));
                p++;
            }
        }
        return r;
    }
};
