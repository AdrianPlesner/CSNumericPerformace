using System.Diagnostics;
using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;


namespace EnergyTest.Benchmarks;

public class CBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in C", typeof(IpcBenchmarkLifecycle), name:"C MM")]
    public static FPipe CMatMult(FPipe s)
    {
        return s;
    }

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name:"C DIL")]
    public static FPipe CDivLoop(FPipe s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name:"C PE")]
    public static FPipe CPolyEval(FPipe s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle), name:"C DFE")]
    public static FPipe CDistFuncEval(FPipe s) => s;

}