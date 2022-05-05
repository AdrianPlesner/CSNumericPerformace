// See https://aka.ms/new-console-template for more information

using CsharpRAPL.Benchmarking;
using CsharpRAPL.CommandLine;

//Console.WriteLine("Hello, World!!");

var options = CsharpRAPLCLI.Parse(args);


var suite = new BenchmarkCollector(options.Iterations, options.LoopIterations);

suite.RunAll();
