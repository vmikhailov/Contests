#pragma once

#include <cmath>
#include <vector>

class Primes {
public:
    int countPrimes(int n) {
        if (n <= 2) return 0;
        std::vector<bool> marks(n / 2, false);

        int c = 1;

        for (int k = 1; k < n / 2; k++) {
            if (marks[k]) continue;
            for (int i = 1;; i++) {
                auto v = 2 * i * k + i + k;
                if (v >= n / 2) break;
                marks[v] = true;
            }
            c++;
        }

        return c;
    }
};