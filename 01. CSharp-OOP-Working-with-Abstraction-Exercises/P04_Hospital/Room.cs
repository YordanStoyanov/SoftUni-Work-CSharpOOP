using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        private List<Patient> patient;
        private int number;
        public Room(int number)
        {
            this.Number = number;
            patient = new List<Patient>();
        }
        public List<Patient> Patient { get; set; }
        public int Number
        {
            get { return this.number; }
            private set
            {
                if (value > 0 || value < 20)
                {
                    this.number = value;
                }
            }
        }

    }
}
