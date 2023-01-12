#include <vector>
#include "MatrixHelpers.h"

using namespace std;

class Shift2dGrid {
public:
    vector<vector<int>> shiftGrid(vector<vector<int>> &grid, int k) {
        int m = grid.size();
        int n = grid[0].size();
        int nm = n * m;
        k = k % nm;
        if (k == 0) return grid;

        if (k % n == 0) {
            // moving whole lines
            rotate(grid, k / n);
        } else {
            int a = k % n;
            for (int i = 0; i < m; i++) {
                rotate(grid[i], a);
            }

            int b = k / n;
            for (int i = 0; i < a; i++) {
                int t = grid[0][i];
                for (int j = 1; j < m; j++) {
                    swap(grid[j][i], t);
                }
                grid[0][i] = t;
            }

            rotate(grid, b);
        }

        return grid;
    }

    template<class T>
    void rotate(vector<T> &arr, int k) {
        int n = arr.size();
        if (k % n == 0) return;
        std::reverse(arr.begin(), arr.end());
        if (k > 1) {
            std::reverse(arr.begin(), arr.begin() + k);
        }
        if (n - k > 1) {
            std::reverse(arr.begin() + k, arr.end());
        }
    }
};