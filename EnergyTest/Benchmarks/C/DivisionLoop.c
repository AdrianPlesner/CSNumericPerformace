//
// Created by adrian on 6/29/22.
//

#include "DivisionLoop.h"

static long LeastInteger()
{
    long result = 0;

    int n = 0;
    double sum = 0.0;
    while (sum < M) {
        n++;
        sum += 1.0/n;
    }

    result += n;
    return result;
}
