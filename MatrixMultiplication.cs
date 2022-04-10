using Accord.Statistics.Moving;
using CsharpRAPL.Benchmarking.Attributes;

namespace EnergyTest;

public class MatrixMultiplication
{
    public static ulong Iterations;
    public static ulong LoopIterations;
    static int size = 80;
    static readonly Random r = new();
    static double[,] R = InitMatrix(size), A = InitMatrix(size), B = InitMatrix(size);
    static int aCols = A.GetLength(1),
        rRows = R.GetLength(0),
        rCols = R.GetLength(1);
    

    private static double[,] InitMatrix(int size)
    {
        var result = new double[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result[i, j] = r.NextDouble();
            }
        }
        return result;
    }

    [Benchmark("Matrix multiplication", "Straightforward matrix multiplication")]
    public static double Standard()
    {
        var result = 0.0;
        for (ulong i = 0; i < LoopIterations; i++)
        {
            
            for (int r = 0; r < rRows; r++)
            {
                for (int c = 0; c < rCols; c++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < aCols; k++)
                        sum += A[r, k] * B[k, c];
                    R[r, c] = sum;
                }
            }
            foreach (var n in R)
            {
                result += n;
            }
        }
        return result;
    }  
}