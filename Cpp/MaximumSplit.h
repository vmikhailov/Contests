#pragma once

#include <vector>
#include <cmath>

using namespace std;

class MaximumSplit {
public:
    vector<long long> maximumEvenSplit(long long finalSum) {
        auto n = finalSum / 2;
        // 1, 2, 3, 4 = 8

        //x * (x + 1) / 2 + y = n/2
        //x^2 + x - (n - 2y) = 0
        //b2 - 4ac = 1 + 4(n - 2y);
        //1 + 4(n - 2x) = 64

        // q * q = 1 + 4(n - 2x)
        //(q * q - 1)/2 = n - 2x;

        auto q = (int) sqrt(1 + 4 * finalSum);
        auto x = (finalSum - (q * q - 1) / 4) / 2;

        vector<long long> r;
        r.push_back(q);
        r.push_back(x);
        return r;
    }
};