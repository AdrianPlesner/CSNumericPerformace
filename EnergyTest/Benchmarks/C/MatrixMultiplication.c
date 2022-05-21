#include <stdlib.h>
#include <time.h>
#include "MatMult.h"


double randfrom(double min, double max)
{
    srand (time ( NULL));
    double range = (max - min);
    double div = RAND_MAX / range;
    return min + (rand() / div);
}


double* InitArray(const int size){
    double* result = (double*) malloc(size * size * sizeof(double));
    for(int i = 0; i < size * size; i++){
        result[i] = randfrom(0.0, 1.0);
    }
    return result;
}

/***
 * Benchmark for Matrix multiplication
 */
double* FlatArray(){
    double* A = InitArray(size);
    double* B = InitArray(size);
    double* R = (double*) calloc(size * size, sizeof(double));
    for(long i = 0; i < LoopIterations; i++){
        for(int r = 0; r < size; r++){
            for(int c = 0; c < size; c++){
                double sum = 0.0;
                for(int k = 0; k < size; k++){
                    sum += A[r*size + k] * B[k * size + c];
                }
                *(R +r*size + c) = sum;
            }
        }
    }
    free(A);
    free(B);
    return R;
}