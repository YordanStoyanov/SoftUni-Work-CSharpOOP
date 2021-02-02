using System;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        private Hospital hospital;
        public StartUp()
        {
            this.hospital = new Hospital();
        }
        public void Program()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] arguments = command.Split();
                var departament = arguments[0];

                var firstName = arguments[1];
                var secondName = arguments[2];

                var patient = arguments[3];

                var fullName = firstName + " " + secondName;

                this.hospital.AddDoctor(firstName, secondName);
                this.hospital.AddDepartment(departament);
                this.hospital.AddPatient(departament, fullName, patient);
            }

            command = Console.ReadLine();
            while (command != "End")
            {
                string[] arguments = command.Split();
                if (arguments.Length == 1)
                {
                    var departmentName = arguments[0];
                    var department = this.hospital.Departments.FirstOrDefault(d => d.Name == departmentName);
                    Console.WriteLine(department);
                }
            }
        }
    }
}
