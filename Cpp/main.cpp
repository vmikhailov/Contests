#include <iostream>
#include <vector>
#include "SummaryRangesTask.h"
#include "RotateImage.h"

using namespace std;

int main() {
    //auto srt = new SummaryRangesTask();
    //vector<int> data = {1, 2, 3, 4, 5, 7, 8};
    //vector<string> result = srt->summaryRanges(data);

    vector<vector<int>> data1 = {{5,  1,  9,  11},
                                 {2,  4,  8,  10},
                                 {13, 3,  6,  7},
                                 {15, 14, 12, 16}};

    vector<vector<int>> data2 = {{5,  1,  9,  11, 7},
                                {2,  4,  8,  10, 3},
                                {13, 3,  6,  7, 11},
                                {15, 14, 12, 16, 22},
                                {21, 22, 23, 24, 4}};

    vector<vector<int>> data3 = {{1,  2},
                                 {4,  3}};

    auto data = data1;
    auto ri = new RotateImageTask();
    cout << "Before" << endl;
    ri->print(data);

    ri->rotate(data);

    cout << "After" << endl;
    ri->print(data);
    return 0;
}
