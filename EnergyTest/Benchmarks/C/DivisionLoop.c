#include "DivisionLoop.h"

void LeastInteger(int LoopIterations)
{
    long result = 0;
    for(int i = 0; i < LoopIterations; i++) {
        int n = 0;
        double sum = 0.0;
        while (sum < M) {
            n++;
            sum += 1.0 / n;
        }

        result += n;
    }
}
