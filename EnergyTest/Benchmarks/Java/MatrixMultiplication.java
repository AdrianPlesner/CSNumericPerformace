public class MatrixMultiplication {
    public static long Iterations;
    public static long LoopIterations;

    public static int size = 80;

    public static double[][] A = InitMatrix(size), B = InitMatrix(size), R = new double[size][size];
    public static double[] fA = InitArray(size), fB = InitArray(size), fR = new double[size * size];
    private static int rRows = R.length, rCols = R[0].length, aCols = A[0].length;


    private static double [][] InitMatrix(int size){
        var result = new double [size][size];
        for(var i = 0; i < size; i++){
            for(var j = 0;  j < size; j++){
                result[i][j] = i+j;
            }
        }
        return result;
    }

    private static double[] InitArray(int size){
        var result = new double[size*size];
        for(var i = 0; i < size; i++){
            var offset = size * i;
            for(var j = 0; j < size; j++){
                result[offset + j] = i+j;
            }
        }
        return result;
    }

    /***
     * Benchmark for matrix multiplication using double arrays
     *
     */
    public static void DoubleArray(int LoopIterations){
        for(int i = 0; i < LoopIterations; i++) {
            for (int r = 0; r < rRows; r++) {
                double[] Ar = A[r], Rr = R[r];
                for (int c = 0; c < rCols; c++) {
                    double sum = 0.0;
                    for (int k = 0; k < aCols; k++)
                        sum += Ar[k] * B[k][c];
                    Rr[c] = sum;
                }
            }
        }
    }

    /***
     * Benchmark for matrix multiplication with C style flat array
     *
     */
    public static void FlatArray(int LoopIterations) {
        for (int i = 0; i < LoopIterations; i++) {
            for (var r = 0; r < size; r++) {
                for (var c = 0; c < size; c++) {
                    double sum = 0.0;
                    for (var k = 0; k < size; k++) {
                        sum += fA[r * size + k] * fB[k * size + c];
                    }
                    fR[r * size + c] = sum;
                }
            }
        }
    }
}