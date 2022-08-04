using CsharpRAPL.Benchmarking.Attributes;

namespace EnergyTest.Benchmarks;

public class DivisionLoop
{
    public static ulong Iterations;
    public static ulong LoopIterations;
    private static readonly int M = 20;

    [Benchmark("Division intensive loop","Division intensive loop in C#", name:"C sharp DIL")]
    public static long LeastInteger()
    {
        long result = 0;
        
        for (ulong i = 0; i < LoopIterations; i++)
        {
            var n = 0;
            var sum = 0.0;
            while (sum < M) {
                n++;
                sum += 1.0/n;
            }

            result += n;
        }
        return result;
    }
}