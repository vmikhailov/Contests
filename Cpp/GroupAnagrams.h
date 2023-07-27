#pragma once

#include <vector>
#include <iostream>
#include <string>
#include <unordered_map>

using namespace std;

class GroupAnagrams {
public:
    vector<vector<string>> groupAnagrams(vector<string> &strs) {
        unordered_map<string, vector<string>> rr;
        vector<vector<string>> r;

        for (auto const &s: strs) {
            auto key = sortChars(s);
            rr[key].push_back(s);
        }

        r.reserve(rr.size());
        std::transform(rr.begin(), rr.end(), std::back_inserter(r), [](auto const &p)  { return p.second; });

        for (auto &a: rr) {
            r.push_back(std::move(a.second));
        }

        return r;
    }

    string sortChars(const string &s) {
        auto ss = s;
        std::sort(ss.begin(), ss.end());
        return ss;
    }
};