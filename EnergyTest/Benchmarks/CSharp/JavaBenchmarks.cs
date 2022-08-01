using CsharpRAPL.Benchmarking.Attributes;
using SampleBenchmark;

namespace EnergyTest.Benchmarks;

public class JavaBenchmarks
{
    [Benchmark("Matrix multiplication", "Matrix multiplication using array of arrays in JAva", typeof(IpcBenchmarkLifecycle), name:"Java double array")]
    public static IpcState JavaMatrixMultDoubleArray(IpcState s) => s;
    
    [Benchmark("Matrix multiplication", "Matrix multiplication using flat array in Java", typeof(IpcBenchmarkLifecycle), name:"Java falt array")]
    public static IpcState JavaMatrixMultFlatArray(IpcState s) => s;
    
    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle), name:"Java")]
    public static IpcState JavaDivisionLoop(IpcState s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle), name:"Java")]
    public static IpcState JavaPolynomialEvaluation(IpcState s) => s;
}