using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;
using SocketComm;

namespace EnergyTest.Benchmarks.CSharp;
using static LoopIterations;
public class JavaBenchmarks
{

    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using array of arrays",
        typeof(IpcBenchmarkLifecycle), name: "Java OpenJDK MM double", skip: false, loopIterations: 1024)]
    public static JavaState JavaMatMultDoubleArray(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "MatrixMultiplication.java",
            BenchmarkSignature = "MatrixMultiplication.DoubleArray(1024);"
        };
    }

    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using flat array",
        typeof(IpcBenchmarkLifecycle), name: "Java OpenJDK MM flat", skip: false, loopIterations: 1024)]
    public static JavaState JavaMatMultFlatArray(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "MatrixMultiplication.java",
            BenchmarkSignature = "MatrixMultiplication.FlatArray(1024);"
        };
    }

    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle),
        name: "Java OpenJDK DIL", skip: false, loopIterations: 1)]
    public static JavaState JavaDivLoop(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "DivisionLoop.java",
            BenchmarkSignature = "DivisionLoop.LeastInteger(1);"
        };
    }

    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle),
        name: "Java OpenJDK PE", skip: false, loopIterations: PolyEval)]
    public static JavaState JavaPolyEval(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "PolynomialEvaluation.java",
            BenchmarkSignature = $"PolynomialEvaluation.HornersRule({PolyEval});"
        };
    }

    [Benchmark("Distribution function evaluation", "Distribution function evaluation Java",
        typeof(IpcBenchmarkLifecycle), name: "Java OpenJDK DFE", skip: false, loopIterations: DistFuncEval)]
    public static JavaState JavaDistFuncEval(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "DistributionFunction.java",
            BenchmarkSignature = $"DistributionFunction.Evaluate({DistFuncEval});"
        };
    }
    
}