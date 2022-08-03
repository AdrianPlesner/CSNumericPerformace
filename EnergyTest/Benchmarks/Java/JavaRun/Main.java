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
        FPipe p = new FPipe(pipe);
        p.WriteCmd(Cmd.Ready);
        Cmd c;
        if(pipe.contains("DoubleArray")){
            do {
                p.WriteCmd(Cmd.Ready);
                c = p.ReadCmd();
                System.out.println("received: " + c);
                if (c == Cmd.Go){
                    System.out.println("Running..");
                    MatrixMultiplication.DoubleArray();
                }
                else{
                    p.WriteCmd(Cmd.Error);
                    System.out.println("Error expected GO");
                }
                p.WriteCmd(Cmd.Done);
            }
            while ((c = p.ReadCmd()) == Cmd.Ready);

        } else if (pipe.contains("FlatArray")) {
            do {
                p.WriteCmd(Cmd.Ready);
                c = p.ReadCmd();
                System.out.println("received: " + c);
                if (c == Cmd.Go){
                    System.out.println("Running..");
                    MatrixMultiplication.FlatArray();
                }
                else{
                    p.WriteCmd(Cmd.Error);
                    System.out.println("Error expected GO");
                }
                p.WriteCmd(Cmd.Done);
            }
            while ((c = p.ReadCmd()) == Cmd.Ready);

        } else if (pipe.contains("DivLoop")) {
            do {
                p.WriteCmd(Cmd.Ready);
                c = p.ReadCmd();
                System.out.println("received: " + c);
                if (c == Cmd.Go){
                    System.out.println("Running..");
                    DivisionLoop.LeastInteger();
                }
                else{
                    p.WriteCmd(Cmd.Error);
                    System.out.println("Error expected GO");
                }
                p.WriteCmd(Cmd.Done);
            }
            while ((c = p.ReadCmd()) == Cmd.Ready);

        } else if (pipe.contains("PolyEval")) {
            do {
                p.WriteCmd(Cmd.Ready);
                c = p.ReadCmd();
                System.out.println("received: " + c);
                if (c == Cmd.Go){
                    System.out.println("Running..");
                    PolynomialEvaluation.HornersRule();
                }
                else{
                    p.WriteCmd(Cmd.Error);
                    System.out.println("Error expected GO");
                }
                p.WriteCmd(Cmd.Done);
            }
            while ((c = p.ReadCmd()) == Cmd.Ready);

        }
        else if(pipe.contains("DistFuncEval")){
            do {
                p.WriteCmd(Cmd.Ready);
                c = p.ReadCmd();
                System.out.println("received: " + c);
                if (c == Cmd.Go){
                    System.out.println("Running..");
                    DistributionFunction.Evaluate();
                }
                else{
                    p.WriteCmd(Cmd.Error);
                    System.out.println("Error expected GO");
                }
                p.WriteCmd(Cmd.Done);
            }
            while ((c = p.ReadCmd()) == Cmd.Ready);
        }
        System.out.println("Done!");
        p.close();
    }
}
