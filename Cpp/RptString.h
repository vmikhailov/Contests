#pragma once
#include <iostream>
using namespace std;

class RptString {
public:
    bool repeatedSubstringPattern(string s) {
        auto n = s.size();
        for(auto i = 1; i <= n/2; i++) {
            if(n % i == 0 && rpt(s, i)) return true;
        }
        return false;
    }

    static bool rpt(const string& s, int f){
        for(auto i = 0; i < f; i++){
            char c = s[i];
            for(auto j = i + f; j < s.size(); j += f){
                if(c != s[j]) return false;
            }
        }
        return true;
    }
};