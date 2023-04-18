using CSIPC;
using SocketComm;
if (args.Length < 1)
{
    Console.Error.WriteLine("usage: [socket]");
    return;
}

var path = args[0];
var pipe = new FPipe(path);
pipe.Connect();

pipe.WriteCmd(Cmd.Ready);

Cmd c;
do
{
    pipe.WriteCmd(Cmd.Ready);
    if (path.Contains("DistFuncEval"))
    {
        pipe.ExpectCmd(Cmd.Go);
        //Run benchmark
        DistributionFunctionEvaluation.Evaluate(EnergyTest.Benchmarks.LoopIterations.DistFuncEval);
    }else if (path.Contains("DivLoop"))
    {
        pipe.ExpectCmd(Cmd.Go);
        //Run benchmark
        DivisionLoop.LeastInteger(EnergyTest.Benchmarks.LoopIterations.DivisionLoop);
    }else if (path.Contains("PolyEval"))
    {
        pipe.ExpectCmd(Cmd.Go);
        //Run benchmark
        PolynomialEvaluation.HornersRule(EnergyTest.Benchmarks.LoopIterations.PolyEval);
    }
    else if (path.Contains("Standard"))
    {
        pipe.ExpectCmd(Cmd.Go);
        //Run benchmark
        MatrixMultiplication.Standard(512);
    }
    else if (path.Contains("Unsafe"))
    {
        pipe.ExpectCmd(Cmd.Go);
        //Run benchmark
        MatrixMultiplication.Unsafe(1024);
    }
    else if (path.Contains("JavaLike"))
    {
        pipe.ExpectCmd(Cmd.Go);
        //Run benchmark
        MatrixMultiplication.LikeJava(1024);
    }
    
    
    pipe.WriteCmd(Cmd.Done);
    c = pipe.ReadCmd();
}while(c == Cmd.Ready);
pipe.Dispose();
Console.WriteLine("Benchmark done!");