using System;
using System.Linq;

namespace HospitalDemo
{
    public class Engine
    {
        private Hospital hospital;
        public Engine()
        {
            this.hospital = new Hospital();
        }
        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "Output")
            {
                string[] parts = input.Split();
                var departments = parts[0];
                var firstName = parts[1];
                var lastName = parts[2];
                var patientName = parts[3];
                var fullName = firstName + " " + lastName;
                this.hospital.AddDepartment(departments);
                this.hospital.AddDoctor(firstName, lastName);
                this.hospital.AddPatient(departments, fullName, patientName);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] parts = input.Split();
                if (parts.Length == 1)
                {
                    var departmentName = parts[0];
                    var department = this.hospital.Departments.FirstOrDefault(de => de.Name == departmentName);
                    Console.WriteLine(department);
                }
            }
        }
    }
}
