#pragma once

#include <iostream>
#include <unordered_set>
#include <vector>

using namespace std;

class LongestNonRepeatingSec {
public:
    int lengthOfLongestSubstring(string s) {
        unordered_set<char> st;
        int &&a = 5;

        int m = 0;
        int l = s.size();
        vector<bool> marks(256, false);

        for (int i = 0; i < l; i++) {
            marks[s[i]] = true;
            int k = 1;
            for (int j = i + 1; j <= l; j++) {
                int v = s[j];
                if (j == l || marks[v]) {
                    if (k > m) m = k;
                    break;
                }

                k++;
                marks[v] = true;
            }

            std::fill(marks.begin(), marks.end(),false);
        }

        return m;
    }
};