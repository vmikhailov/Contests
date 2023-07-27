#ifndef MOVE_ALL_ZEROS
#define MOVE_ALL_ZEROS

#include <vector>

void moveZeros(std::vector<int>& source){
    auto i = 0;
    auto j = -1;
    auto size = source.size();

    while(i < size){
        if(source[i] == 0) {
            i++;
            continue;
        }

        j = i;
        while(j < size && source[j] != 0) j++;
        if(j == size) return;

        std::swap(source[i], source[j]);
        i++;
    }
}

#endif