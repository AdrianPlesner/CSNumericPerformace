using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks.CSharp;

public class CBenchmarks
{
    
    [Benchmark("Matrix multiplication", "Matrix multiplication in C",  typeof(IpcBenchmarkLifecycle), 
        name:"C MM", skip: false, loopIterations:512)]
    public static CState CMatMult(IpcState s)
    {
        return new CState(s.PipePath) {
            BenchmarkSignature = "FlatArray(512)",
            LibPath = "Benchmarks/C",
            HeaderFile = "MatMult.h", 
            CFile = "MatrixMultiplication.c"};
    }

    [Benchmark("Division intensive loop", "Division intensive loop in C", typeof(IpcBenchmarkLifecycle), name: "C DIL",
        skip: false, loopIterations: 1)]
    public static CState CDivLoop(IpcState s)
    {
        return new CState(s.PipePath)
        {
            BenchmarkSignature = "LeastInteger(1)",
            LibPath = "Benchmarks/C",
            HeaderFile = "DivisionLoop.h",
            CFile = "DivisionLoop.c"
        };
    }

    [Benchmark("Polynomial evaluation", "Polynomial evaluation in C", typeof(IpcBenchmarkLifecycle), name: "C PE",
        skip: false, loopIterations: 131072)]
    public static CState CPolyEval(IpcState s)
    {
        return new CState(s.PipePath)
        {
            BenchmarkSignature = "InitCS();HornersRule(131072);",
            LibPath = "Benchmarks/C",
            HeaderFile = "PolynomialEvaluation.h",
            CFile = "PolynomialEvaluation.c"
        };
    }

    [Benchmark("Distribution function evaluation", "Distribution function evaluation C", typeof(IpcBenchmarkLifecycle),
        name: "C DFE", skip: false, loopIterations: 8388608)]
    public static CState CDistFuncEval(IpcState s)
    {
        return new CState(s.PipePath)
        {
            BenchmarkSignature = "Evaluate(8388608);",
            LibPath = "Benchmarks/C",
            HeaderFile = "DistributionFunction.h",
            CFile = "DistributionFunction.c",
            AdditionalCompilerOptions = "-lm"
        };
    }

}