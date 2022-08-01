using CsharpRAPL.Benchmarking.Attributes;
using SampleBenchmark;

namespace EnergyTest.Benchmarks;

public class CBenchmarks
{
    [Benchmark("Matrix multiplication", "Matrix multiplication with flat array in C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CMatrixMult(IpcState s) => s;
    
    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CDivisionLoop(IpcState s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name:"C")]
    public static IpcState CPolynomialEvaluation(IpcState s) => s;

}