#include <vector>

#pragma once
class RemoveMatching {
public:
    int remove(std::vector<int>& nums, int val) {
        auto r = nums.size();
        auto i = 0;
        while(i < r){
            if(nums[i] == val){
                r--;
                std::swap(nums[i], nums[r]);
            }
            else
            {
                i++;
            }
        }
        return r;
    }
};