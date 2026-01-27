using BenchmarkDotNet.Running;

namespace BenchmarkDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<LinqVsLoopBenchmark>();
        }
    }
}