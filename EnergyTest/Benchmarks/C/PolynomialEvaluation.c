//
// Created by adrian on 6/29/22.
//

#include "PolynomialEvaluation.h"

static const int csSize = 1000;
double cs[1000];
static int length = sizeof cs / sizeof (cs[0]);
static double x = 5.5;

void InitCS(int i, double* result){
    for (int j = 0; j < i; j++)
    {
        result[j] = 1.1 * j;
        if (j % 3 == 0)
        {
            result[j] *= -1;
        }
    }
}

double HornersRule(int LoopIterations)
{
    double result = 0.0;
    for(int j = 0; j < LoopIterations; j++) {
        double res = 0.0;
        for (int i = 0; i < length; i++) {
            double c = cs[i];
            res = c + x * res;
        }
        result += res;
    }
    return result;
}
