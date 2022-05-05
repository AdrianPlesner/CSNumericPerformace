
pingpong: pingpong.c scomm.o cmd.o
	gcc -o pingpong pingpong.c comm.o cmd.o

cmd.o: cmd.c cmd.h
	gcc -c cmd.c -o cmd.o
scomm.o: cmd.o scomm.c scomm.h
	gcc -c comm.c -o comm.o cmd.o

