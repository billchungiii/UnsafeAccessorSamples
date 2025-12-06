using System.Runtime.CompilerServices;


namespace UnsafeAccessorSample002
{
    /// <summary>
    /// Access instance's private properties via UnsafeAccessor
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Alice", 28);
            // Accessing private properties via UnsafeAccessor
            string name = PersonAccessor.GetNameProperty(person);
            int age = PersonAccessor.GetAgeProperty(person);
            Console.WriteLine($"Person: {person.ToString()}");
            // Modifying private properties via UnsafeAccessor
            PersonAccessor.SetNameProperty(person, "Bob");
            PersonAccessor.SetAgeProperty(person, 35);
            Console.WriteLine($"Updated Person: {person.ToString()}");

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

        public override string ToString()
        {
            return  $"{Name} -- {Age}";
        }
    }

    public static class PersonAccessor
    {
        /// <summary>
        /// Accessing private property's getter (Name)
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Name")]
        public extern static string GetNameProperty(Person person);

        /// <summary>
        /// Accessing private property's setter (Name)
        /// </summary>
        /// <param name="person"></param>
        /// <param name="name"></param>

        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_Name")]
        public extern static void SetNameProperty(Person person, string name);

        /// <summary>
        /// Accessing private property's getter (Age)
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Age")]
        public extern static int GetAgeProperty(Person person);

        /// <summary>
        /// Accessing private property's setter (Age)
        /// </summary>
        /// <param name="person"></param>
        /// <param name="age"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_Age")]
        public extern static void SetAgeProperty(Person person, int age);
    }
}
