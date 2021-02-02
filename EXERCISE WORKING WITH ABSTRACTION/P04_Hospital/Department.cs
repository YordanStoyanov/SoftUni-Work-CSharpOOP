using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public void AddPatientToRoom(Patient patient)
        {
            var currentRoom = this.Rooms.FirstOrDefault(r => !r.IsFull);
            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
            }
        }

        private void CreateRoom()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }
    }
}
