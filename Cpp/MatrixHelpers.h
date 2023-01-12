#include <vector>
#include <iostream>
using namespace std;

#ifndef MatrixHelpers_H
#define MatrixHelpers_H

class MatrixHelpers{
public:
    static void print(vector<vector<int>> &matrix) {
        for (auto & i : matrix) {
            for (int j : i) {
                cout << j << " ";
            }
            cout << endl;
        }
        cout << endl;
    }
};
#endif