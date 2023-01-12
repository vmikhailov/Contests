#include <vector>
using namespace std;

class PascalTriangle {
public:
        vector<vector<int>> generate(int numRows) {

        auto vv = vector<vector<int>>();

        vector<int> p = vector<int>(1,1);

        vv.push_back(p);
        for(int i = 1; i < numRows; i++) {

            vector<int> v = vector<int>();

            v.push_back(1);

            for(int j = 1; j < i; j++){
                v.push_back(p[j] + p[j-1]);
            }
            v.push_back(1);
            vv.push_back(v);
            p = v;
        }

        return vv;
    }
};