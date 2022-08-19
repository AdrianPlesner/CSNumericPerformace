
#ifndef C_POLYNOMIALEVALUATION_H
#define C_POLYNOMIALEVALUATION_H


static const int csSize;
double cs[1000];
static int length;
static double x;

void InitCS(int i, double* result);
double HornersRule(int LoopIterations);

#endif //C_POLYNOMIALEVALUATION_H
