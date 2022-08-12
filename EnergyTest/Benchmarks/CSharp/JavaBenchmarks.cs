using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks.CSharp;

public class JavaBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using array of arrays", typeof(IpcBenchmarkLifecycle), name:"Java MM double array", skip: false, loopIterations: 512 )]
    public static FPipe JavaMatMultDoubleArray(FPipe s) => s;
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using flat array", typeof(IpcBenchmarkLifecycle), name:"Java MM flat array", skip: false, loopIterations: 512)]
    public static FPipe JavaMatMultFlatArray(FPipe s) => s;
    
    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle), name:"Java DIL", skip: false, loopIterations:1)]
    public static FPipe JavaDivLoop(FPipe s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle), name:"Java PE", skip: false, loopIterations:67108864)]
    public static FPipe JavaPolyEval(FPipe s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation Java", typeof(IpcBenchmarkLifecycle), name:"Java DFE", skip: false, loopIterations:33554432)]
    public static FPipe JavaDistFuncEval(FPipe s) => s;
    
}