using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BenchmarkTest
{

    public class Person
    {
        /// <summary>
        /// field
        /// </summary>
        public string _name;

        /// <summary>
        /// filed
        /// </summary>
        public int _age;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Person(string name, int age) => (_name, _age) = (name, age);
       
        /// <summary>
        /// method (with parameters)
        /// </summary>
        /// <param name="year"></param>
        public void AddAge(int year) => _age += year;
    }

    public static class PersonAccessor
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
