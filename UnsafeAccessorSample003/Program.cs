using System.Runtime.CompilerServices;

namespace UnsafeAccessorSample003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ref string key = ref ConfigurationAccessor.GetKeyField(null);
            Console.WriteLine($"Current Key: {key}");
            ConfigurationAccessor.CallSetKey(null, "New-Secret");
            ref string newKey = ref ConfigurationAccessor.GetKeyField(null);
            Console.WriteLine($"Updated Key: {newKey}");
        }
    }

    public class Configuration
    {
        /// <summary>
        /// static field
        /// </summary>
        private static string _key = "Default-key";

        /// <summary>
        /// static method
        /// </summary>
        /// <param name="key"></param>
        private static void SetKey(string key)
        {
            _key = key;
        }
    }

    public static class ConfigurationAccessor
    {
        /// <summary>
        /// Accessing private static field's getter (_key)
        /// </summary>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.StaticField, Name = "_key")]
        public extern static ref string GetKeyField(Configuration _);
        /// <summary>
        /// Accessing private static method (SetKey)
        /// </summary>
        /// <param name="key"></param>
        [UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "SetKey")]
        public extern static void CallSetKey(Configuration _ , string key);
    }
}
