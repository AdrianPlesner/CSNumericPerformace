using CsharpRAPL.Benchmarking.Attributes;
using CsharpRAPL.Benchmarking.Attributes.Parameters;

namespace EnergyTest.Benchmarks;

public class DistributionFunctionEvaluation
{
    /*public static ulong Iterations;
    public static ulong LoopIterations;*/

    private static double cutoff = 7.071, root2pi = Math.Sqrt(2 * Math.PI);
    private static double p0 = 220.2068679123761,
        p1 = 221.2135961699311,
        p2 = 112.0792914978709, 
        p3 = 33.912866078383,
        p4 = 6.37396220353165,
        p5 = .7003830644436881,
        p6 = .03526249659989109, 
        q0 = 440.4137358247522,
        q1 = 793.8265125199484,
        q2 = 637.3336333788311,
        q3 = 296.5642487796737,
        q4 = 86.78073220294608,
        q5 = 16.06417757920695,
        q6 = 1.755667163182642,
        q7 = .08838834764831844;

    [Benchmark("Distribution function evaluation", "Distribution function evaluation in C#", name:"C sharp DFE", skip: false)]
    public double Evaluate([BenchmarkLoopiterations]ulong loopIterations)
    {
        var result = 0.0;
        for (ulong i = 0; i < loopIterations; i++)
        {
            result += F(-3);
        }

        return result;
    }
    
    private double F(double z) {
        double p, zabs = Math.Abs(z);
        if (zabs > 37)
            p = 0;
        else { // |z| <= 37
            double expntl = Math.Exp(zabs * zabs * -.5);
            double pdf = expntl / root2pi;
            if (zabs < cutoff) // |z| < CUTOFF = 10/sqrt(2)
                p = expntl * ((((((p6 * zabs + p5) * zabs + p4) * zabs + p3) * zabs
                                + p2) * zabs + p1) * zabs + p0) / (((((((q7 * zabs + q6) *
                        zabs + q5) * zabs + q4) * zabs + q3) * zabs + q2) * zabs + q1)
                    * zabs + q0);
            else // CUTOFF <= |z| <= 37
                p = pdf / (zabs + 1 / (zabs + 2 / (zabs + 3 / (zabs + 4 / (zabs
                                                                           + .65)))));
        }
        if (z < 0)
            return p;
        else
            return 1-p;
    }
}