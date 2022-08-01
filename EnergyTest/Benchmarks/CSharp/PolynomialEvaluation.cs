using CsharpRAPL.Benchmarking.Attributes;

namespace EnergyTest.Benchmarks;

public class PolynomialEvaluation
{
    public static ulong Iterations;
    public static ulong LoopIterations;

    private static readonly double[] cs = { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9};
    private static readonly double x = 5.5;

    [Benchmark("Polynomial evaluation","C#", name:"C#")]
    public static double HornersRule()
    {
        double result = 0.0;
        for (ulong n = 0; n < LoopIterations; n++)
        {
            double res = 0.0;
            foreach (var t in cs)
                res = t + x * res;
            result += res;
        }
        return result;
    }
}