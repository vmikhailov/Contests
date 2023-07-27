#pragma once

#include <unordered_map>
#include <algorithm>
#include "SerializeDeserializeBinSearchTree.h"

using namespace std;

class FindMaxLevelSum {
public:
    int maxLevelSum(TreeNode *root) {
        unordered_map<int, int> levels;

        processLevels(root, 0, levels);

        auto max = max_element(levels.begin(), levels.end(),
                               [](const auto &l, const auto &r) {
            if(l.second < r.second) return true;
            if(l.second > r.second) return false;
            return l.first > r.first;
        });

        return max->first;
    }

    void processLevels(TreeNode *node, int level, unordered_map<int, int> &levels) {
        levels[level] += node->val;

        if (node->left) processLevels(node->left, level + 1, levels);
        if (node->right) processLevels(node->right, level + 1, levels);
    }
};