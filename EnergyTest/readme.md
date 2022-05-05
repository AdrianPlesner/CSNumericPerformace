
# CSNumericPerformance


This project serves to replicate the [experiments of Peter Sestoft](https://www.itu.dk/~sestoft/papers/numericperformance.pdf), investigating the performance of C, C# and Java regarding heavy numeric operations. However, in addition to measuring the run time, we also measure the energy consumption.

The test cases are implemented in the Benchmarks directory.

The tests are carried out using the [CSharpRAPL](https://github.com/PLEnergyDev/CsharpRAPL) measuring framework. 

To run the test cases run:

    sudo dotnet run --configuration release -- [CSharpRAPL options e.g. -p]

Here sudo is necessary to access the RAPL directories, we use the release configuration to avoid the the overhead of debug information and CSharpRAPL -p draws boxplots of the results.
