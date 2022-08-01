public class PolynomialEvaluation {
    public static long Iterations;
    public static long LoopIterations;

    private static double[] cs = { 1.1, -2.2, 3.3, -4.4, 5.5, -6.6, 7.7, -8.8, 9.9};
    private static double x = 5.5;

    /***
     * Benchmark for Polynomial evaluation using horners rule
     */
    public static double HornersRule()
    {
        double result = 0.0;
        double res = 0.0;
        for (double c : cs) res = c + x * res;
        result += res;
        return result;
    }
}
