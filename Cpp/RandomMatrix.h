#ifndef CPP_RANDOMMATRIX_H
#define CPP_RANDOMMATRIX_H

#include <string>
#include <sstream>
#include <chrono>
#include <valarray>
#include <iostream>

using namespace std;

class RandomMatrix {
public:
    void print() {
        srand(time(NULL));
        int a = 0;
        int b = 0;
        cin >> a >> b;
        int mass[a][b];

        for (int i = 0; i < a; i++) {
            for (int j = 0; j < b; j++) {
                mass[i][j] = rand() % 213;
                cout << mass[i][j] << '\t';
            }
            cout << endl;
        }
        cout << endl;

        for (int i = 0; i < a; i++) {
            for (int j = 0; j < b; j++) {
                cout << mass[i][j] << '\t';
            }
            cout << endl;
        }
        cout << endl;
    }
};

#endif //CPP_RANDOMMATRIX_H
