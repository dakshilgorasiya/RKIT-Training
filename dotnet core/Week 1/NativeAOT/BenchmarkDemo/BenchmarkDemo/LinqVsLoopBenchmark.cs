using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkDemo
{
    [MemoryDiagnoser]
    [CsvExporter]
    public class LinqVsLoopBenchmark
    {
        private List<int> numbers;

        [Params(100, 1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            numbers = Enumerable.Range(1, N).ToList();
        }

        [Benchmark]
        public int ForLoop()
        {
            int count = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > N/2)
                {
                    count++;
                }
            }
            return count;
        }

        [Benchmark]
        public int Linq()
        {
            return numbers.Count(x => x > N/2);
        }
    }
}
