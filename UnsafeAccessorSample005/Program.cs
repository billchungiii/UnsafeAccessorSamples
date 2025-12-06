using System.Runtime.CompilerServices;

namespace UnsafeAccessorSample005
{
    /// <summary>
    /// .NET9 support generic UnsafeAccessor
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = GenericAccessor<int>.Create();
            Console.WriteLine($"list count {list.Count}");
                       
            GenericAccessor<int>.Add(list, 999);
            Console.WriteLine($"list count {list.Count}, index 0 is {list[0]}");
        }
    }

    public static class GenericAccessor<T>
    {
        /// <summary>
        /// Accessing public constructor of generic class List<T>
        /// </summary>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
        public extern static List<T> Create();
        /// <summary>
        /// Accessing public method Add of generic class List<T>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Add")]
        public extern static void Add(List<T> list, T item);
    }
}
