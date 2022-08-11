package JavaRun;

import java.io.IOException;

public class Main {

    public static void main(String[] args) throws Exception {
        System.out.println("Hello world");
        if(args.length < 1){
            System.err.println("usage: [socket]");
        }
        var pipe = args[0];
        Thread.sleep(1000);
        int LoopIterations = 10;
        FPipe p = new FPipe(pipe);
        p.WriteCmd(Cmd.Ready);
        if(pipe.contains("DoubleArray")){
            do {
                p.WriteCmd(Cmd.Ready);
                p.ExpectCmd(Cmd.Go);
                System.out.println("Running..");
                for(int i = 0; i < LoopIterations; i++) {
                    MatrixMultiplication.DoubleArray();
                }
                p.WriteCmd(Cmd.Done);
            }
            while (p.ExpectCmd(Cmd.Go) == Cmd.Go);
        } else if (pipe.contains("FlatArray")) {
            do {
                p.WriteCmd(Cmd.Ready);
                p.ExpectCmd(Cmd.Go);
                System.out.println("Running..");
                for(int i = 0; i < LoopIterations; i++) {
                    MatrixMultiplication.FlatArray();
                }
                p.WriteCmd(Cmd.Done);
            }
            while (p.ExpectCmd(Cmd.Go) == Cmd.Go);
        } else if (pipe.contains("DivLoop")) {
            do {
                p.WriteCmd(Cmd.Ready);
                p.ExpectCmd(Cmd.Go);
                System.out.println("Running..");
                for(int i = 0; i < LoopIterations; i++) {
                    DivisionLoop.LeastInteger();
                }
                p.WriteCmd(Cmd.Done);
            }
            while (p.ExpectCmd(Cmd.Go) == Cmd.Go);
        } else if (pipe.contains("PolyEval")) {
            do {
                p.WriteCmd(Cmd.Ready);
                p.ExpectCmd(Cmd.Go);
                System.out.println("Running..");
                for(int i = 0; i < LoopIterations; i++) {
                    PolynomialEvaluation.HornersRule();
                }
                p.WriteCmd(Cmd.Done);
            }
            while (p.ExpectCmd(Cmd.Go) == Cmd.Go);
        }
        else if(pipe.contains("DistFuncEval")){
            do {
                p.WriteCmd(Cmd.Ready);
                p.ExpectCmd(Cmd.Go);
                System.out.println("Running..");
                for(int i = 0; i < LoopIterations; i++) {
                    DistributionFunction.Evaluate();
                }
                p.WriteCmd(Cmd.Done);
            }
            while (p.ExpectCmd(Cmd.Go) == Cmd.Go);
        }
        System.out.println("Done!");
        p.close();
    }
}
