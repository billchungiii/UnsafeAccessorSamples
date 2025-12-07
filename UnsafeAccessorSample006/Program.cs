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
            ref var innerInstance = ref OuterClassAccessor.GetInnerInstance(new OuterClass());
            OuterClassAccessor.CallShowMessage(innerInstance);
        }
    }


    public class OuterClass
    {
        private object _innerInstance = new InnerClass();
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
        /// Accessing private field _innerInstance of OuterClass
        /// </summary>
        /// <param name="outerInstance"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_innerInstance")]
        public extern static ref object GetInnerInstance(OuterClass outerInstance);

        /// <summary>
        /// Accessing private nested class InnerClass's method ShowMessage 
        /// </summary>
        /// <param name="innerInstance"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "ShowMessage")]
        public extern static void CallShowMessage([UnsafeAccessorType("UnsafeAccessorSample006.OuterClass+InnerClass")] object instance);
    }
}
