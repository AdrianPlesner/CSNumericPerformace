using System.Diagnostics;
using CsharpRAPL.Benchmarking.Attributes;
using SampleBenchmark;

namespace EnergyTest.Benchmarks;

public class CBenchmarks
{
    [Benchmark("Matrix multiplication", "Matrix multiplication in C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CMatMult(IpcState s)
    {
        return s;
    }

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CDivLoop(IpcState s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CPolyEval(IpcState s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CDistFuncEval(IpcState s) => s;

}