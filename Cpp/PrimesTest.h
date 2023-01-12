#ifndef CPP_PRIMESTEST_H
#define CPP_PRIMESTEST_H

#include <string>
#include <sstream>
#include <chrono>
#include <valarray>
#include <iostream>

using namespace std;

class PrimeTest {
public:
    void primeTest() {
        int n = 1000000;
        int m = 6;

        while (--m >= 0) {
            auto start = chrono::high_resolution_clock::now();
            int k = 0;
            for (int i = 4; i < n; i++) {
                bool isPrime = i % 2 == 1;
                int s = (int) sqrt(i) + 1;
                for (int j = 3; j < s && isPrime; j += 2){
                    if (i % j == 0) {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) k++;
            }

            auto finish = chrono::high_resolution_clock::now();
            auto elapsed = chrono::duration_cast<std::chrono::milliseconds>(finish-start).count();

            cout << k << " primes in first " << n/1000000 << " mln. ";
            cout << elapsed << "ms " << k / elapsed << endl;
            n *= 2;
        }
    }
};


#endif //CPP_PRIMESTEST_H
