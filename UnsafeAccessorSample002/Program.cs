namespace UnsafeAccessorSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Person
    {
        private string Name { get; set; }
        private int Age { get; set; }
    }
}
