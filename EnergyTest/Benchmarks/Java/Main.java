public class Main {

    public static void main(String[] args) throws Exception {
        System.out.println("Hello world");
        if(args.length < 1){
            System.err.println("usage: [socket]");
            System.exit(1);
        }
        var pipe = args[0];
        int LoopIterations = 1;
        FPipe p = new FPipe(pipe);
        try {
            p.WriteCmd(Cmd.Ready);
            do {
                p.WriteCmd(Cmd.Ready);
                System.out.println("Running..");
                p.ExpectCmd(Cmd.Go);
                for (int i = 0; i < LoopIterations; i++) {
                    ///Compute benchmark here!
                }
                p.WriteCmd(Cmd.Done);
            }
            while (p.ExpectCmd(Cmd.Ready) == Cmd.Ready);
        }
        catch(PipeCmdException e) {
            System.out.println("Done!");
        }finally {
            p.close();
        }

    }
}
