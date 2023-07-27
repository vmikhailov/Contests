#pragma once
#include <vector>
#include <unordered_set>
#include <cmath>

using namespace std;

class MaximumBombs {
public:
    int maximumDetonation(vector<vector<int>>& bombs) {
        vector<vector<int>> all;
        for(auto i = 0; i < bombs.size(); i++){
            vector<int> c;

            for(auto j = 0; j < bombs.size(); j++){
                if(i == j) continue;
                auto dx = (bombs[i][0]-bombs[j][0]);
                auto dy = (bombs[i][1]-bombs[j][1]);
                auto r = sqrt(dx*dx + dy*dy);
                if(bombs[i][2] >= r) c.push_back(j);
            }

            all.push_back(std::move(c));
        }

        auto max = -1;
        for(auto i = 0; i < all.size(); i++){
            auto d = computeBombs(all, i);
            max = d > max ? d : max;
        }
        return max;
    }

    int computeBombs(vector<vector<int>>& all, int i){
        unordered_set<int> visited;
        return computeBombs(all, i, visited);
    }

    int computeBombs(vector<vector<int>>& all, int i, unordered_set<int>& visited){
        if(!get<1>(visited.insert(i))) return 0;

        auto w = 1;
        for(auto b: all[i]){
            w += computeBombs(all, b, visited);
        }
        return w;
    }
};