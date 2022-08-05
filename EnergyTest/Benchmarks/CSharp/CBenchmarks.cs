using System.Diagnostics;
using CsharpRAPL.Benchmarking.Attributes;
using SampleBenchmark;

namespace EnergyTest.Benchmarks;

public class CBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in C", typeof(IpcBenchmarkLifecycle), name:"C MM")]
    public static IpcState CMatMult(IpcState s)
    {
        return s;
    }

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name:"C DIL")]
    public static IpcState CDivLoop(IpcState s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name:"C PE")]
    public static IpcState CPolyEval(IpcState s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle), name:"C DFE")]
    public static IpcState CDistFuncEval(IpcState s) => s;

}