#include <stdlib.h>
#include <stdio.h>
#include "comm.h"

int main(int argc, char **argv){
  if(argc<=1){
    fprintf(stderr,"\nUsage: %s [FIFO]\n\n", argv[0]);
    exit(EXIT_FAILURE);
  }
  FILE *f = fopen(argv[1], "r+");
  if (f == NULL)
    exit(EXIT_FAILURE);
  CMD c;
  do{
    writeCmd(f, Go);
  } while ((c = readCmd(f))>= Go ); 
  fclose(f);
}
