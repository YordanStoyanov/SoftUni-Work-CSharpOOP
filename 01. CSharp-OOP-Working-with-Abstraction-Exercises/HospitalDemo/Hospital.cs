using System.Collections.Generic;
using System.Linq;

namespace HospitalDemo
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


        public bool AddDoctor(string firstName, string lastName)
        {
            var currentDoctor = this.Doctors.FirstOrDefault(d => d.FirstName == firstName && d.LastName == lastName);
            if (currentDoctor != null)
            {
                var doctor = new Doctor(firstName, lastName);
                Doctors.Add(doctor);
                return true;
            }
            return false;
        }
        public bool AddDepartment(string name)
        {
            var currentDepartment = this.Departments.FirstOrDefault(d => d.Name == name);
            if (currentDepartment != null)
            {
                var department = new Department(name);
                Departments.Add(department);
                return true;
            }
            return false;
        }

        public bool AddPatient(string departmentName, string doctorName, string patientName)
        {
            var department = this.Departments.FirstOrDefault(de => de.Name == departmentName);
            var doctor = this.Doctors.FirstOrDefault(d => d.FullName == doctorName);
            Patient patient = new Patient(patientName);
            if (department.AddPatientInRoom(patient))
            {
                doctor.Patient.Add(patient);
                return true;
            }
            return false;
        }
    }
}
