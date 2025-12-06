namespace UnsafeAccessorSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Person
    {
        /// <summary>
        /// property
        /// </summary>
        private string Name { get; set; }

        /// <summary>
        /// property
        /// </summary>
        private int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public static class PersonAccessor
    {

    }
}
