using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    public class AccessorBenchmark
    {
        private Person _person;
        [GlobalSetup]
        public void Setup()
        {
            _person = new Person("BenchmarkUser", 40);
        }

        [Benchmark(Description = "Field — direct access")]
        public void AccessPrivateField_Direct()
        {            
            _person._age += 1;
        }

        [Benchmark(Description = "Field — unsafeaccessor")]
        public void AccessPrivateField_Unsafe()
        {
            ref int age = ref PersonAccessor.GetAgeField(_person);
            age += 1;
        }

        [Benchmark(Description = "Field — reflection")]
        public void AccessPrivateField_Reflection()
        {
            var fieldInfo = typeof(Person).GetField("_age");
            int age = (int)fieldInfo.GetValue(_person);
            age += 1;
            fieldInfo.SetValue(_person, age);
        }

        [Benchmark(Description = "Method — direct access")]
        public void AccessPrivateMethod_Direct()
        {
            _person.AddAge(2);
        }

        [Benchmark(Description = "Method — unsafeaccessor")]
        public void AccessPrivateMethod_Unsafe()
        {
            PersonAccessor.CallAddAge(_person, 2);
        }

        [Benchmark(Description = "Method — reflection")]
        public void AccessPrivateMethod_Reflection()
        {
            var methodInfo = typeof(Person).GetMethod("AddAge");
            methodInfo.Invoke(_person, new object[] { 2 });
        }

    }
}
