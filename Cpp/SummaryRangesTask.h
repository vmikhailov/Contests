#include <vector>
#include <string>

using namespace std;

class SummaryRangesTask {
public:
    vector<string> summaryRanges(vector<int> &nums) {
        auto r = vector<string>();
        int i = 0, j;
        char buffer[100];

        while (i < nums.size()) {
            int v = nums[i];

            for (j = i + 1; j < nums.size() && ++v == nums[j]; j++);

            if (i == j - 1) sprintf(buffer, "%d", nums[i]);
            else sprintf(buffer, "%d->%d", nums[i], nums[j - 1]);

            r.emplace_back(buffer);
            i = j;
        }

        return r;
    }
};

