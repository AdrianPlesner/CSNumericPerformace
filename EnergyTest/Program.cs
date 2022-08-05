// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using CsharpRAPL.Benchmarking;
using CsharpRAPL.CommandLine;

//Console.WriteLine("Hello, World!!");

var options = CsharpRAPLCLI.Parse(args);
options.PlotResults = true;

var suite = new BenchmarkCollector(options.Iterations, options.LoopIterations);
suite.RunAll(false);
