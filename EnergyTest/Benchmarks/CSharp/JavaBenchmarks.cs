using CsharpRAPL.Benchmarking.Attributes;
using SampleBenchmark;

namespace EnergyTest.Benchmarks;

public class JavaBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using array of arrays", typeof(IpcBenchmarkLifecycle), name:"Java MM double array")]
    public static IpcState JavaMatMultDoubleArray(IpcState s) => s;
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using flat array", typeof(IpcBenchmarkLifecycle), name:"Java MM flat array")]
    public static IpcState JavaMatMultFlatArray(IpcState s) => s;
    
    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle), name:"Java DIL")]
    public static IpcState JavaDivLoop(IpcState s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle), name:"Java PE")]
    public static IpcState JavaPolyEval(IpcState s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation Java", typeof(IpcBenchmarkLifecycle), name:"Java DFE")]
    public static IpcState JavaDistFuncEval(IpcState s) => s;
    
}