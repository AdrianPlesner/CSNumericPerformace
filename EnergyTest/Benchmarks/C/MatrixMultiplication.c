#include <stdlib.h>
#include "MatMult.h"

double* InitArray(const int size){
    double* result = (double*) malloc(size * size * sizeof(double));
    for(int i = 0; i < size; i++){
        int offset = i * size;
        for(int j = 0; j < size; j++){
            result[offset + j] = i + j;
        }
    }
    return result;
}

/***
 * Benchmark for Matrix multiplication
 */
void FlatArray(){
    double* A = InitArray(size);
    double* B = InitArray(size);
    double* R = (double*) calloc(size * size, sizeof(double));
    for(int r = 0; r < size; r++){
        for(int c = 0; c < size; c++){
            double sum = 0.0;
            for(int k = 0; k < size; k++){
                sum += A[r*size + k] * B[k * size + c];
            }
            *(R +r*size + c) = sum;
        }
    }
    free(A);
    free(B);
    free(R);
}