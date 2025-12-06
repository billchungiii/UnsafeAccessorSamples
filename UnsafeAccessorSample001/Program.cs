using System.Runtime.CompilerServices;

namespace UnsafeAccessorSample001
{
    /// <summary>
    /// Access instance's private constructor, method and field via UnsafeAccessor
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = PersonAccessor.Create("Joe", 25);
            PersonAccessor.CallDisplay(person);
            ref int age = ref PersonAccessor.GetAgeField(person);
            age = 31;
            PersonAccessor.CallDisplay(person);
            ref string name = ref PersonAccessor.GetNameFiled(person);
            name = "David";
            PersonAccessor.CallDisplay(person);
            string description = PersonAccessor.CallDescribe(person);
            Console.WriteLine(description);

            PersonAccessor.CallAddAge(person, 10);
            PersonAccessor.CallDisplay(person);

        }
    }
    public class Person
    {
        /// <summary>
        /// field
        /// </summary>
        private string _name;

        /// <summary>
        /// filed
        /// </summary>
        private int _age;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        private Person(string name, int age) => (_name, _age) = (name, age);

        /// <summary>
        /// method 
        /// </summary>
        private void Display() => Console.WriteLine($"{_name} -- {_age}");

        /// <summary>
        /// method (with return value)
        /// </summary>
        /// <returns></returns>
        private string Describe() => $"My name is {_name} ,and I am {_age} years old";

        /// <summary>
        /// method (with parameters)
        /// </summary>
        /// <param name="year"></param>
        private void AddAge(int year) => _age += year;
    }

    public class PersonAccessor
    {
        /// <summary>
        /// Access private instance constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
        public extern static Person Create(string name, int age);

        /// <summary>
        /// Access private instance method (Display)
        /// </summary>
        /// <param name="person"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Display")]
        public extern static void CallDisplay(Person person);

        /// <summary>
        /// Access private instance method (Describe)
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Describe")]
        public extern static string CallDescribe(Person person);


        /// <summary>
        /// Access private instance method (AddAge)
        /// </summary>
        /// <param name="person"></param>
        /// <param name="year"></param>
        [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "AddAge")]
        public extern static void CallAddAge(Person person, int year);


        /// <summary>
        /// Access private instance field (_name)
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_name")]
        public extern static ref string GetNameFiled(Person person);

        /// <summary>
        /// Access private instance field (_age)
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_age")]
        public extern static ref int GetAgeField(Person person);

    }

}
