using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalDemo
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patient = new List<Patient>();
        }
        public List<Patient> Patient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } set {; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var patient in Patient.OrderBy(p => p.Name))
            {
                sb.AppendLine(patient.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
