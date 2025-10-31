//
// Created by slava on 15/01/2023.
//

#include "bimap.h"

#include <stdio.h>

int sumDigitsInBase7(int n) {
    int sum = 0;
    while (n > 0) {
        sum += n % 7;
        n /= 7;
    }
    return sum;
}

int main() {
    int n;
    scanf("%d", &n);

    int decimalNumber = 0;
    int base = 1;
    while (n > 0) {
        decimalNumber += (n % 10) * base;
        n /= 10;
        base *= 5;
    }

    int sumInBase7 = sumDigitsInBase7(decimalNumber);

    int ternaryResult = 0;
    int ternaryBase = 1;
    while (sumInBase7 > 0) {
        ternaryResult += (sumInBase7 % 3) * ternaryBase;
        sumInBase7 /= 3;
        ternaryBase *= 10;
    }

    printf("%d", ternaryResult);

    return 0;
}
