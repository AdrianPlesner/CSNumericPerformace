namespace EnergyTest.Benchmarks;

public class DistributionFunctionEvaluation
{
    public static ulong Iterations;
    public static ulong LoopIterations;

    private static double cutoff = 7.071, root2pi;
    private static double p0, p1, p2, p3, p4, p5, p6, q0, q1, q2, q3, q4, q5, q6, q7;

    public double Evaluate()
    {
        var result = 0.0;
        for (ulong i = 0; i < LoopIterations; i++)
        {
            result += F(5);
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