using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using System.Threading.Tasks;

namespace MeasurePerformanceORM
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ManualConfig()
                            .AddJob(Job.Default)
                            .AddDiagnoser(MemoryDiagnoser.Default)
                            .AddLogger(ConsoleLogger.Default)
                            .AddExporter(MarkdownExporter.Default)
                            .AddColumnProvider(DefaultColumnProviders.Instance);

            var summary = BenchmarkRunner.Run<DataAccessBenchmarks>(config);
        }
    }
}
