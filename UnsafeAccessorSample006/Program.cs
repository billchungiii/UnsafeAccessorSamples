using System.Runtime.CompilerServices;

namespace UnsafeAccessorSample006
{
    /// <summary>
    /// .NET 10 support accessing private nested class via UnsafeAccessor by UnsafeAccessorType attribute
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var innerInstance = OuterClassAccessor.Create();
            OuterClassAccessor.CallShowMessage(innerInstance);           
        }
    }


    public class OuterClass
    {        
        /// <summary>
        /// this is an nested inner private class
        /// </summary>
        private class InnerClass
        {
            private void ShowMessage()
            {
                Console.WriteLine("Hello from InnerClass!");
            }
        }
    }

    public static class OuterClassAccessor
    {
        /// <summary>
        /// Accessing private constructor of nested class InnerClass (UnsafeAccessorType with assembly qualified name)
        /// </summary>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
        [return: UnsafeAccessorType("UnsafeAccessorSample006.OuterClass+InnerClass,UnsafeAccessorSample006")]
        public extern static object Create();

       

        /// <summary>
        /// Accessing private nested class InnerClass's method ShowMessage 
        /// </summary>
        /// <param name="innerInstance"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "ShowMessage")]
        public extern static void CallShowMessage([UnsafeAccessorType("UnsafeAccessorSample006.OuterClass+InnerClass")] object instance);
    }
}
