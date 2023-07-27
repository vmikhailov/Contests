#pragma once

#include <iostream>
#include <stack>
#include <vector>

using namespace std;

class ReversePar {
public:
    string reverseParentheses(string &s) {
        std::stack<int> openBraces{};

        for (int i = 0; i < s.size(); i++) {
            switch (s[i]) {
                case '(':
                    openBraces.push(i);
                    continue;
                case ')':
                    int start = openBraces.top();
                    std::reverse(s.begin() + start + 1, s.begin() + i);
                    openBraces.pop();
                    continue;
            }
        }

        vector<char> ss;
        ss.reserve(s.size());
        for(auto c: s)
        {
            if(c == '(' || c == ')') continue;
            ss.push_back(c);
        }

        return {ss.begin(), ss.end()};
    }
};