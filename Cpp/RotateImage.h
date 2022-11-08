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

    tuple<int, int> GetSrc(int i, int s) {
        if (s == 1) return {0, 0};
        int r = (s - 1) * 4;
        if (i >= r) {
            auto [x, y] = GetSrc(i - r, s - 2);
            return {x + 1, y + 1};
        } else {
            if (i < s) return {i, 0};
            if (i < 2 * s - 1) return {s - 1, i - s + 1};
            if (i < 3 * s - 2) return {3 * s - i - 3, s - 1};
            return {0, 4 * s - i - 4};
        }
    }

    tuple<int, int> GetDest(int i, int s) {
        if (s == 1) return {0, 0};
        int r = (s - 1) * 4;
        if (i >= r) {
            auto [x, y] = GetDest(i - r, s - 2);
            return {x + 1, y + 1};
        } else {
            if (i < s) return {s - 1, i};
            if (i < 2 * s - 1) return {2 * s - i - 2, s - 1};
            if (i < 3 * s - 2) return {0, 3 * s - i - 3};
            return {i - 3 * s + 3, 0};
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