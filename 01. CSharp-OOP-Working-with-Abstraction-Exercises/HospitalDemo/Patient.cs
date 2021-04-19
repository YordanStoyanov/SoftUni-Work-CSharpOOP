using System;
using System.Collections.Generic;

namespace HospitalDemo
{
    public class Patient
    {
        public Patient(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        internal static IEnumerable<object> OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
