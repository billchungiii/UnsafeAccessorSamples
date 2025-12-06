using BenchmarkDotNet.Running;

namespace BenchmarkTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<AccessorBenchmark>();         
        }
    }
}
