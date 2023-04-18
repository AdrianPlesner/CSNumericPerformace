using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Attributes.Parameters;

namespace EnergyTest.Benchmarks.CSharp;
public class PolynomialEvaluation
{
    /*public static ulong Iterations;
    public static ulong LoopIterations;*/

    private static readonly double[] cs = InitCS(1000);
    private static readonly double x = 5.5;

    private static double[] InitCS(int i)
    {
        var result = new double[i];
        for (int j = 0; j < i; j++)
        {
            result[j] = 1.1 * j;
            if (j % 3 == 0)
            {
                result[j] *= -1;
            }
        }

        return result;
    }    

    [Benchmark("Polynomial evaluation","Polynomial evaluation", name:"Cs PE", skip: false)]
    public static double HornersRule([BenchmarkLoopiterations] ulong LoopIterations)
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