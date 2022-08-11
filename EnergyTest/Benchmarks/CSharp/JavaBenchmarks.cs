using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks;

public class JavaBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using array of arrays", typeof(IpcBenchmarkLifecycle), name:"Java MM double array")]
    public static FPipe JavaMatMultDoubleArray(FPipe s) => s;
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using flat array", typeof(IpcBenchmarkLifecycle), name:"Java MM flat array")]
    public static FPipe JavaMatMultFlatArray(FPipe s) => s;
    
    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle), name:"Java DIL")]
    public static FPipe JavaDivLoop(FPipe s) => s;
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle), name:"Java PE")]
    public static FPipe JavaPolyEval(FPipe s) => s;
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation Java", typeof(IpcBenchmarkLifecycle), name:"Java DFE")]
    public static FPipe JavaDistFuncEval(FPipe s) => s;
    
}