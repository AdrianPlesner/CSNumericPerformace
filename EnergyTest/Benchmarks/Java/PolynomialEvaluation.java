public class PolynomialEvaluation {

    private static double[] cs = InitCS(100);
    private static double x = 5.5;

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

    /***
     * Benchmark for Polynomial evaluation using horners rule
     */
    public static double HornersRule(int LoopIterations)
    {
        double result = 0.0;
        for(int i = 0; i < LoopIterations; i++) {
            double res = 0.0;
            for (double c : cs) res = c + x * res;
            result += res;
        }
        
        return result;
    }
}
