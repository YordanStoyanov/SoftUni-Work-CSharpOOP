using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            :base(name, age)
        {
            base.Age = age;
        }

        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Children should not be able to have an age more than 15!");
                }
                base.Age = value;
            }
        }
    }
}
