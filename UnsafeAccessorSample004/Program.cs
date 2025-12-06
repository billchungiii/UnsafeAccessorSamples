using System.Runtime.CompilerServices;

namespace UnsafeAccessorSample004
{
    /// <summary>
    /// .NET 8
    /// Access generic class's public members via UnsafeAccessor
    /// reference to: https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/9.0/unsafeaccessor-generics#reason-for-change
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // create List<int> instance via UnsafeAccessor (.NET8 success)
            // if you change TargetFramework to net9.0, it will thorw exception -- System.InvalidProgramException: Generic type constraints do not match.
            var list = GenericAccessor.Create();
            Console.WriteLine($"list count {list.Count}");

            // this will throw exception -- System.MissingMethodException: Method not found: System.Collections.Generic.List`1.Add.            
            GenericAccessor.Add(list, 999);
            Console.WriteLine($"list count {list.Count}, index 0 is {list[0]}");
        }
    }

    public static class GenericAccessor
    {
        /// <summary>
        /// Accessing public constructor of generic class List<int> (success)
        /// </summary>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
        public extern static List<int> Create();

        /// <summary>
        /// Accessing public method Add of generic class List<int> (failure)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Add")]
        public extern static void Add(List<int> list, int item);
    }
}
