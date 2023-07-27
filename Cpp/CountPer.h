#pragma once

#include <vector>

using namespace std;

class CountPer {
public:
    int islandPerimeter(vector<vector<int>> &grid) {
        auto v = 0;
        for (int i = 0; i < grid.size(); i++) {
            for (int j = 0; j < grid[0].size(); j++) {
                v += countEmpty(grid, i, j);
            }
        }
        return v;
    }

    int countEmpty(vector<vector<int>> &grid, int i, int j) {
        int c = 0;

        if (grid[i][j] == 0) return 0;

        if (i > 0) c += grid[i - 1][j];
        if (j > 0) c += grid[i][j - 1];

        if (i < grid.size() - 1) c += grid[i + 1][j];
        if (j < grid[0].size() - 1) c += grid[i][j + 1];

        return 4 - c;
    }
};