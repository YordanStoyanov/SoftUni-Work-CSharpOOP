using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                if (age < 15)
                {
                    Child child = new Child(name, age);
                    Console.WriteLine(child);
                }
                else
                {
                    Person child = new Person(name, age);
                    Console.WriteLine(child);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
