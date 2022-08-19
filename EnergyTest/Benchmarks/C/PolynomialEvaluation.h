
#ifndef C_POLYNOMIALEVALUATION_H
#define C_POLYNOMIALEVALUATION_H


static const int csSize = 1000;
const double cs[1000];
static int length = sizeof cs / sizeof (cs[0]);
static double x = 5.5;

void InitCS(int i, double* result);
double HornersRule(int LoopIterations);

#endif //C_POLYNOMIALEVALUATION_H
