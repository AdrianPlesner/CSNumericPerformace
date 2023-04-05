using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks.CSharp;
using static LoopIterations;
public class CBenchmarks
{
    [Benchmark("Matrix multiplication", "Matrix multiplication in C",  typeof(IpcBenchmarkLifecycle), 
        name:"C O1", skip: false, loopIterations:1024)]
    public static CState CMatMultO1(IpcState s)
    {
        return new CState(s) {
            BenchmarkSignature = "FlatArray(1024)",
            LibPath = "Benchmarks/C",
            HeaderFile = "MatMult.h", 
            CFile = "MatrixMultiplication.c",
            AdditionalCompilerOptions = "-O1"
        };
    }

    [Benchmark("Matrix multiplication", "Matrix multiplication in C", typeof(IpcBenchmarkLifecycle),
        name: "C O2", skip: false, loopIterations: 1024)]
    public static CState CMatMultO2(IpcState s)
    {
        var state = CMatMultO1(s);
        state.AdditionalCompilerOptions = "-O2";
        return state;
    }
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in C", typeof(IpcBenchmarkLifecycle),
        name: "C O3", skip: false, loopIterations: 1024)]
    public static CState CMatMultO3(IpcState s)
    {
        var state = CMatMultO1(s);
        state.AdditionalCompilerOptions = "-O3";
        return state;
    }
    
    

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name: "C O1",
        skip: false, loopIterations: 1)]
    public static CState CDivLoopO1(IpcState s)
    {
        return new CState(s)
        {
            BenchmarkSignature = "LeastInteger(1)",
            LibPath = "Benchmarks/C",
            HeaderFile = "DivisionLoop.h",
            CFile = "DivisionLoop.c",
            KeepCompilationResults = true,
            AdditionalCompilerOptions = "-O1"
        };
    }

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name: "C O2",
        skip: false, loopIterations: 1)]
    public static CState CDivLoopO2(IpcState s)
    {
        var state = CDivLoopO1(s);
        state.AdditionalCompilerOptions = "-O2";
        return state;
    }
    
    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name: "C O3",
        skip: false, loopIterations: 1)]
    public static CState CDivLoopO3(IpcState s)
    {
        var state = CDivLoopO1(s);
        state.AdditionalCompilerOptions = "-O3";
        return state;
    }
    
    
    

    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name: "C O1",
        skip: false, loopIterations: PolyEval)]
    public static CState CPolyEvalO1(IpcState s)
    {
        return new CState(s)
        {
            BenchmarkSignature = $"InitCS();HornersRule({PolyEval});",
            LibPath = "Benchmarks/C",
            HeaderFile = "PolynomialEvaluation.h",
            CFile = "PolynomialEvaluation.c",
            AdditionalCompilerOptions = "-O1"
        };
    }

    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name: "C O2",
        skip: false, loopIterations: PolyEval)]
    public static CState CPolyEvalO2(IpcState s)
    {
        var state = CPolyEvalO1(s);
        state.AdditionalCompilerOptions = "-O2";
        return state;
    }
    
    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name: "C O3",
        skip: false, loopIterations: PolyEval)]
    public static CState CPolyEvalO3(IpcState s)
    {
        var state = CPolyEvalO1(s);
        state.AdditionalCompilerOptions = "-O3";
        return state;
    }

    

    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle),
        name: "C O1", skip: false, loopIterations: DistFuncEval)]
    public static CState CDistFuncEvalO1(IpcState s)
    {
        return new CState(s)
        {
            BenchmarkSignature = $"Evaluate({DistFuncEval});",
            LibPath = "Benchmarks/C",
            HeaderFile = "DistributionFunction.h",
            CFile = "DistributionFunction.c",
            AdditionalCompilerOptions = "-lm -O1"
        };
    }

    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle),
        name: "C O2", skip: false, loopIterations: DistFuncEval)]
    public static CState CDistFuncEvalO2(IpcState s)
    {
        var state = CDistFuncEvalO1(s);
        state.AdditionalCompilerOptions = "-lm -O2";
        return state;
    }
    
    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle),
        name: "C O3", skip: false, loopIterations: DistFuncEval)]
    public static CState CDistFuncEvalO3(IpcState s)
    {
        var state = CDistFuncEvalO1(s);
        state.AdditionalCompilerOptions = "-lm -O3";
        return state;
    }

}