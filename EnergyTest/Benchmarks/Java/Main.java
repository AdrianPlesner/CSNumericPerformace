import java.io.IOException;

public class Main {

    public static void main(String[] args) throws Exception {
        System.out.println("Hello world");
        if(args.length < 1){
            System.err.println("usage: [socket]");
        }
        var pipe = args[0];
        FPipe p = new FPipe(pipe);
        p.WriteCmd(Cmd.Ready);
        Cmd c;
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
            MatrixMultiplication.FlatArray();
            p.WriteCmd(Cmd.Done);
        }
        while ((c = p.ReadCmd()) == Cmd.Ready);
        System.out.println("Done!");
        p.close();
    }
}
