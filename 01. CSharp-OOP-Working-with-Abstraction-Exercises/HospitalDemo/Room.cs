using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalDemo
{
    public class Room
    {
        private const int numberOfPatientInRoom = 3;
        public Room()
        {
            this.Patient = new List<Patient>();
        }

        public bool IsFull 
        { 
            get 
            { 
                return Patient.Count >= numberOfPatientInRoom; 
            } 
        }
        public List<Patient> Patient { get; set; }

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
