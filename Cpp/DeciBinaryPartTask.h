#ifndef CPP_DECIBINARYPARTTASK_H
#define CPP_DECIBINARYPARTTASK_H
#include <string>

using namespace std;

class DeciBinaryPartTask {
public:
    int minPartitions(string n) {
        int i = 0;
        bool allZeros = false;
        while(!allZeros){

            allZeros = true;
            for(char &c : n){
                if(c == '0') continue;
                c = (char)((int)c - 1);
                allZeros = false;
            }
            i++;
        }

        return i - 1;
    }
};

#endif
