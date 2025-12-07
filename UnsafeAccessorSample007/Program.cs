using System.Runtime.CompilerServices;

namespace UnsafeAccessorSample007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sqrt = MathAccessor.Sqrt(null, 16.0);
            Console.WriteLine($"The square root of 16.0 is {sqrt}");
            var pow = MathAccessor.Pow(null, 2.0, 8.0);
            Console.WriteLine($"2.0 to the power of 8.0 is {pow}");
        }
    }

    public static class MathAccessor
    {
        /// <summary>
        /// Accessing static method Sqrt of Math class
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "Sqrt")]
        public extern static double Sqrt([UnsafeAccessorType("System.Math")] object _, double value);


        /// <summary>
        /// Accessing static method Pow of Math class
        /// </summary>
        /// <param name="_"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "Pow")]
        public extern static double Pow([UnsafeAccessorType("System.Math")] object _, double x, double y);
    }
}
