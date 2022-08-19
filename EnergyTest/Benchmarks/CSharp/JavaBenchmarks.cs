using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks.CSharp;
public class JavaBenchmarks
{

    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using array of arrays",
        typeof(IpcBenchmarkLifecycle), name: "Java MM double array", skip: false, loopIterations: 512)]
    public static JavaState JavaMatMultDoubleArray(IpcState s)
    {
        return new JavaState(s.PipePath)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "MatrixMultiplication.java",
            BenchmarkSignature = "MatrixMultiplication.DoubleArray(512);"
        };
    }

    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using flat array",
        typeof(IpcBenchmarkLifecycle), name: "Java MM flat array", skip: false, loopIterations: 512)]
    public static JavaState JavaMatMultFlatArray(IpcState s)
    {
        return new JavaState(s.PipePath)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "MatrixMultiplication.java",
            BenchmarkSignature = "MatrixMultiplication.FlatArray(512);"
        };
    }

    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle),
        name: "Java DIL", skip: false, loopIterations: 1)]
    public static JavaState JavaDivLoop(IpcState s)
    {
        return new JavaState(s.PipePath)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "DivisionLoop.java",
            BenchmarkSignature = "DivisionLoop.LeastInteger(1);"
        };
    }

    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle),
        name: "Java PE", skip: false, loopIterations: 131072)]
    public static JavaState JavaPolyEval(IpcState s)
    {
        return new JavaState(s.PipePath)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "PolynomialEvaluation.java",
            BenchmarkSignature = "PolynomialEvaluation.HornersRule(131072);"
        };
    }

    [Benchmark("Distribution function evaluation", "Distribution function evaluation Java",
        typeof(IpcBenchmarkLifecycle), name: "Java DFE", skip: false, loopIterations: 8388608)]
    public static JavaState JavaDistFuncEval(IpcState s)
    {
        return new JavaState(s.PipePath)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "DistributionFunction.java",
            BenchmarkSignature = "DistributionFunction.Evaluate(8388608);"
        };
    }
    
}