#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "unistd.h"
#include "scomm.h"
#include "cmd.h"
#include "MatMult.h"
#include "DivisionLoop.h"
#include "PolynomialEvaluation.h"
#include "DistributionFunction.h"


int main(int argc, char **argv){
    if(argc<=1){
        fprintf(stderr,"\nUsage: %s [socket]\n\n", argv[0]);
        exit(EXIT_FAILURE);
    }
    // int s = serveSingleClient(argv[1]);
    sleep(1);
    char* pipe = argv[1];
    int s = connectTo(pipe);
    if(s<0){
        printf("Bad socket...");
        exit(EXIT_FAILURE);
    }
    writeCmd(s, Ready);
    int i = 0;
    int LoopIterations = 10;
    if(strstr(pipe, "MatMult")){
        do{
            writeCmd(s, Ready);
            if(expectCmd(s, Go)){
                printf("Running iteration %d\n", i++);
                for(int j = 0; j < 512; j++) {
                    FlatArray();
                }
            }
            writeCmd(s, Done); //
        } while(expectCmd(s, Ready) == Ready);
    } else if(strstr(pipe,"DivLoop")){
        do{
            writeCmd(s, Ready);
            if(expectCmd(s, Go)){
                printf("Running iteration %d\n", i++);
                for(int j = 0; j < 1; j++) {
                    LeastInteger();
                }
            }
            writeCmd(s, Done); //
        } while(expectCmd(s, Ready) == Ready);
    } else if(strstr(pipe, "PolyEval")){
        do{
            writeCmd(s, Ready);
            if(expectCmd(s, Go)){
                printf("Running iteration %d\n", i++);
                for(int j = 0; j < 67108864; j++) {
                    HornersRule();
                }
            }
            writeCmd(s, Done); //
        } while(expectCmd(s, Ready) == Ready);
    }
    else if(strstr(pipe,"DistFuncEval")){
        do{
            writeCmd(s, Ready);
            if(expectCmd(s, Go)){
                printf("Running iteration %d\n", i++);
                for(int j = 0; j < 33554432; j++) {
                    F(5);
                }
            }
            writeCmd(s, Done); //
        } while(expectCmd(s, Ready) == Ready);
    }
    // we should have read done at this point
    printf("\ndone\n");
    closeSocket(s);
}