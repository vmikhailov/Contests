#pragma once

#include <cmath>

class FascinatingNumber {
public:
    bool isFascinating(int n) {
        auto v2 = n * 2;
        auto v3 = n * 3;
        auto d2 = (int) log10(v2) + 1;
        auto d3 = (int) log10(v3) + 1;
        auto v = (1L * n * (int) pow(10, d2) + v2) * (int) pow(10, d3) + v3;

        bool vals[9]{false};

        while (v > 0) {
            auto d = v % 10;
            if (d == 0) return false;
            if (vals[d]) return false;
            vals[d] = true;
            v = v / 10;
        }
        return true;
    }
};