using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalDemo
{
    public class Department
    {
        private const int numberOfRooms = 20;
        public Department(string name)
        {
            this.Name = name;
            this.Room = new List<Room>();
        }
        public string Name { get; set; }
        public List<Room> Room { get; set; }
        public bool AddPatientInRoom(Patient patient)
        {
            var currentRoom = this.Room.FirstOrDefault(r => !r.IsFull);
            if (currentRoom != null)
            {
                currentRoom.Patient.Add(patient);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var room in Room)
            {
                foreach (var patient in room.Patient)
                {
                    sb.AppendLine(patient.Name);
                }
            }
            return sb.ToString().TrimEnd();
        }
        private void CreateRoom()
        {
            for (int i = 0; i < numberOfRooms; i++)
            {
                this.Room.Add(new Room());
            }
        }
    }
}
