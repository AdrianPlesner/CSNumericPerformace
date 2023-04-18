//
// Created by adrian on 6/29/22.
//

#include <stdio.h>
#include "PolynomialEvaluation.h"

double cs[100];
static int length = sizeof cs / sizeof (cs[0]);

void InitCS(){
    for (int j = 0; j < length; j++)
    {
        cs[j] = 1.1 * j;
        if (j % 3 == 0)
        {
            cs[j] *= -1;
        }
    }
}

long double HornersRule(long LoopIterations)
{
    long double result = 0.0;
    for(long j = 0; j < LoopIterations; j++) {
        double res = 0.0;
        for (int i = 0; i < length; i++) {
            double c = cs[i];
            res = c + x * res;
        }
        result += res;
    }
    return result;
}
