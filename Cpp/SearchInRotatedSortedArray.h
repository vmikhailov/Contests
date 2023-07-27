#pragma onec

#include <vector>

using namespace std;

class SearchInRotatedSortedArray {
public:
    int search(vector<int> &nums, int target) {
        int i = 0;
        int j = nums.size() - 1;
        int k = findBorder(nums, i, j) + 1;

        return search(nums, target, k);
    }

    int search(vector<int> &nums, int target, int shift) {
        int i = 0;
        int n = nums.size();
        int j = n - 1;
        while(i <= j) {
            int m = (i + j) / 2;
            int r = (m + shift) % n;
            if (nums[r] == target) return r;
            if (nums[r] > target) j = m - 1;
            else i = m + 1;
        }
        return -1;
    }

    int findBorder(vector<int> &nums, int i, int j) {
        if (nums[i] < nums[j]) return -1;
        if (i == j) return i;
        auto m = (i + j) / 2;
        auto a = findBorder(nums, i, m);
        if (a >= 0) return a;
        return findBorder(nums, m, j);
    }
};