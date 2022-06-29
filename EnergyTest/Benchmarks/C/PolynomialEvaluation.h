//
// Created by adrian on 6/29/22.
//

#ifndef C_POLYNOMIALEVALUATION_H
#define C_POLYNOMIALEVALUATION_H

static long Iterations;
static long LoopIterations;

static double cs[] = { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9};
static int length = sizeof cs / sizeof (cs[0]);
static double x = 5.5;

static double HornersRule();

#endif //C_POLYNOMIALEVALUATION_H
