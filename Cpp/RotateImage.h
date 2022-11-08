#include <vector>
#include <tuple>
#include <cstdio>
#include <iostream>

using namespace std;

class RotateImageTask {
public:
    void rotate(vector<vector<int>> &matrix) {
        int p = 0;
        int s = matrix.size();
        while (s > 1) {
            auto m = p + s - 1;
            for (auto i = 0; i < s - 1; i++) {
                int a = matrix[p][p + i];
                int b = matrix[p + i][m];
                int c = matrix[m][m - i];
                int d = matrix[m - i][p];

                matrix[p][p + i] = d;
                matrix[p + i][m] = a;
                matrix[m][m - i] = b;
                matrix[m - i][p] = c;
            }
            print(matrix);
            p++;
            s -= 2;
        }
    }

    void print(vector<vector<int>> &matrix) {
        for (int i = 0; i < matrix.size(); i++) {
            for (int j = 0; j < matrix[i].size(); j++) {
                cout << matrix[i][j] << " ";
            }
            cout << endl;
        }
    }
};