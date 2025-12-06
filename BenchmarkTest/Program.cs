using BenchmarkDotNet.Running;

namespace BenchmarkTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
             var summary = BenchmarkRunner.Run<AccessorBenchmark>();         

            //var _person = new Person("Test", 30);
            //ref int age = ref PersonAccessor.GetAgeField(_person);
            //age += 1;
            //Console.WriteLine($"Person's age after unsafe access: {_person._age}");
        }
    }
}
