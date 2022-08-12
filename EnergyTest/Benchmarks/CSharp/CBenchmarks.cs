using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks.CSharp;

public class CBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in C", typeof(IpcBenchmarkLifecycle), name:"C MM", skip: false, loopIterations:512)]
    public static FPipe CMatMult(FPipe s)
    {
        return s;
    }

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name:"C DIL", skip: false, loopIterations: 1)]
    public static FPipe CDivLoop(FPipe s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name:"C PE", skip: false, loopIterations:67108864)]
    public static FPipe CPolyEval(FPipe s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle), name:"C DFE", skip: false, loopIterations:33554432)]
    public static FPipe CDistFuncEval(FPipe s) => s;

}