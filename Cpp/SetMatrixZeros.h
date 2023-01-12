#include <vector>
#include <set>
#include <unordered_set>

using namespace std;

class SetMatrixZeros {
public:
    void setZeroes(vector<vector<int>>& matrix) {
        unordered_set<int> rows = unordered_set<int>();
        unordered_set<int> cols = unordered_set<int>();

        for(int r = 0; r < matrix.size(); r++){
            auto row = matrix[r];
            for(int c = 0; c < row.size(); c++){
                if(row[c] == 0) {
                    rows.insert(r);
                    cols.insert(c);
                }
            }
        }

        for(auto c: cols){
            for(auto & r : matrix){
                r[c] = 0;
            }
        }

        for(auto r: rows){
            for(int & c : matrix[r]){
                c = 0;
            }
        }
    }
};