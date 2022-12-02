using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;

namespace EnergyTest.Benchmarks.CSharp;
[SkipBenchmarks]
public class CSBenchmarks
{
    [Benchmark("Distribution function evaluation", "Distribution function evaluation CS IPC", typeof(IpcBenchmarkLifecycle),
        name: "Cs IPC DFE", skip: false, loopIterations: 33554432)]
    public static IpcState IPCDistFuncEval(IpcState s)
    {
        s.ExecutablePath = "../CSIPC/bin/Release/net6.0/CSIPC";
        return s;
    }
    
    [Benchmark("Division intensive loop", "Division intensive loop in CS IPC", typeof(IpcBenchmarkLifecycle),
        name: "Cs IPC DIL", skip: false, loopIterations:1)]
    public static IpcState IPCDivLoop(IpcState s)
    {
        s.ExecutablePath = "../CSIPC/bin/Release/net6.0/CSIPC";
        return s;
    }
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation function CS IPC", typeof(IpcBenchmarkLifecycle),
        name: "Cs IPC PE", skip: false, loopIterations: 102400)]
    public static IpcState IPCPolyEval(IpcState s)
    {
        s.ExecutablePath = "../CSIPC/bin/Release/net6.0/CSIPC";
        return s;
    }
    
    [Benchmark("Matrix multiplication", "Matrix multiplication CS standard IPC", typeof(IpcBenchmarkLifecycle),
        name: "Cs IPC MM standard", skip: false, loopIterations: 512)]
    public static IpcState IPCMMStandard(IpcState s)
    {
        s.ExecutablePath = "../CSIPC/bin/Release/net6.0/CSIPC";
        return s;
    }
    
    [Benchmark("Matrix multiplication", "Matrix multiplication CS unsafe IPC", typeof(IpcBenchmarkLifecycle),
        name: "Cs IPC MM unsafe", skip: false, loopIterations: 1024)]
    public static IpcState IPCMMUnsafe(IpcState s)
    {
        s.ExecutablePath = "../CSIPC/bin/Release/net6.0/CSIPC";
        return s;
    }
    
    [Benchmark("Matrix multiplication", "Matrix multiplication CS JavaLike IPC", typeof(IpcBenchmarkLifecycle),
        name: "Cs IPC MM JavaLike", skip: false, loopIterations: 1024)]
    public static IpcState IPCMMJavaLike(IpcState s)
    {
        s.ExecutablePath = "../CSIPC/bin/Release/net6.0/CSIPC";
        return s;
    }
}