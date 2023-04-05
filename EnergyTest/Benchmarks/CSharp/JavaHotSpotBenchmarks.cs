using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Lifecycles;

namespace EnergyTest.Benchmarks.CSharp;
using static LoopIterations;
public class JavaHotSpotBenchmarks
{

    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using array of arrays",
        typeof(IpcBenchmarkLifecycle), name: "Java HotSpot double", skip: false, loopIterations: 1024)]
    public static JavaState JavaMatMultDoubleArray(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "MatrixMultiplication.java",
            BenchmarkSignature = "MatrixMultiplication.DoubleArray(1024);",
            JavaPath = "/usr/lib/jvm/jdk-17/bin/java"
        };
    }

    [Benchmark("Matrix multiplication", "Matrix multiplication in Java using flat array",
        typeof(IpcBenchmarkLifecycle), name: "Java HotSpot flat", skip: false, loopIterations: 1024)]
    public static JavaState JavaMatMultFlatArray(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "MatrixMultiplication.java",
            BenchmarkSignature = "MatrixMultiplication.FlatArray(1024);",
            JavaPath = "/usr/lib/jvm/jdk-17/bin/java"
        };
    }

    [Benchmark("Division intensive loop", "Division intensive loop in Java", typeof(IpcBenchmarkLifecycle),
        name: "Java HotSpot", skip: false, loopIterations: 1)]
    public static JavaState JavaDivLoop(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "DivisionLoop.java",
            BenchmarkSignature = "DivisionLoop.LeastInteger(1);",
            JavaPath = "/usr/lib/jvm/jdk-17/bin/java"
        };
    }

    [Benchmark("Polynomial evaluation", "Polynomial evaluation in Java", typeof(IpcBenchmarkLifecycle),
        name: "Java HotSpot", skip: false, loopIterations: PolyEval)]
    public static JavaState JavaPolyEval(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "PolynomialEvaluation.java",
            BenchmarkSignature = $"PolynomialEvaluation.HornersRule({PolyEval});",
            JavaPath = "/usr/lib/jvm/jdk-17/bin/java"
        };
    }

    [Benchmark("Distribution function evaluation", "Distribution function evaluation Java",
        typeof(IpcBenchmarkLifecycle), name: "Java HotSpot", skip: false, loopIterations: DistFuncEval)]
    public static JavaState JavaDistFuncEval(IpcState s)
    {
        return new JavaState(s)
        {
            LibPath = "Benchmarks/Java",
            JavaFile = "DistributionFunction.java",
            BenchmarkSignature = $"DistributionFunction.Evaluate({DistFuncEval});",
            JavaPath = "/usr/lib/jvm/jdk-17/bin/java"
        };
    }
    
}