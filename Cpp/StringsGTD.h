#pragma once
#include <string>
#include <vector>
using namespace std;

class StringsGTD {
public:
    string gcdOfStrings(string str1, string str2) {
        auto d1 = repeatedSubstringPattern(str1);
        auto d2 = repeatedSubstringPattern(str2);

        int i = d1.size() - 1;
        int j = d2.size() - 1;
        while(i >= 0 && j >= 0){
            if(d1[i] == d2[j]) return d1[i];
            if(d1[i].size() > d2[j].size()) i--;
            else j--;
        }
        return "";
    }
private:
    vector<string> repeatedSubstringPattern(string s) {
        auto n = s.size();
        vector<string> r;
        for(auto i = 1; i <= n/2; i++) {
            if(n % i == 0 && rpt(s, i)){
                r.push_back(s.substr(0, i));
            }
        }
        r.push_back(s);
        return r;
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