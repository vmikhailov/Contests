#ifndef CPP_STRICTLYPALINDROMICNUMBERTASK_H
#define CPP_STRICTLYPALINDROMICNUMBERTASK_H
#include <vector>
using namespace std;

class StrictlyPalindromicNumberTask {
public:
    bool isStrictlyPalindromic(int n) {
        for(int i = n - 2; i >= 2; i--){
            auto v = getNumberInBase(n, i);
            if(!isPalindromic(v)) return false;
        }
        return true;
    }

private:
    vector<int> getNumberInBase(int n, int b){
        auto v = vector<int>();

        while(n > 0){
            v.push_back(n % b);
            n = n / b;
        }
        return v;
    }

    bool isPalindromic(vector<int> v){
        auto i = v.begin();
        auto j = v.end() - 1;

        while(i < j){
            if(*i-- != *j--) return false;
        }

        return true;
    }
};

#endif