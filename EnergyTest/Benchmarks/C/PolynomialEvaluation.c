//
// Created by adrian on 6/29/22.
//

#include "PolynomialEvaluation.h"

double HornersRule()
{
    double result = 0.0;

    double res = 0.0;
    for (int i = 0; i < length; i++){
        double c = cs[i];
        res = c + x * res;
    }
    result += res;
    return result;
}
