using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Hospital
    {
        public Hospital()
        {
            this.Departments = new List<Department>();
            this.Doctors = new List<Doctor>();
        }
        public List<Department> Departments { get; set; }
        public List<Doctor> Doctors { get; set; }

        public void AddDoctor(string firstName, string lastName)
        {
            if (this.Doctors.Any(d => d.FirstName == firstName && d.LastName == lastName))
            {
                Doctor doctor = new Doctor(firstName, lastName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddDepartment(string name)
        {
            if (!this.Departments.Any(d => d.Name == name))
            {
                Department department = new Department(name);
                this.Departments.Add(department);
            }
        }

        public void AddPatient(string departmentName, string doctorName, string patientName)
        {
            Department department = this.Departments.FirstOrDefault(d => d.Name == departmentName);
            Doctor doctor = this.Doctors.FirstOrDefault(d => d.FullName == doctorName);
            Patient patient = new Patient(patientName);
            department.AddPatientToRoom(patient);
            doctor.Patients.Add(patient);
        }
    }
}
