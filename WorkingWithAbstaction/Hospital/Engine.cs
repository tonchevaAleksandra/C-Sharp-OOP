using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Engine
    {
        private readonly List<Department> departments;
        private readonly List<Doctor> doctors;
        private const int MAX_CAPACITY = 3;

        public Engine()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                string departmentName = tokens[0];
                string doctorFirstName = tokens[1];
                string doctorLastName = tokens[2];
                string doctorFullName = doctorFirstName + " " + doctorLastName;
                string patientName = tokens[3];


                if (!this.DoctorExist(doctorFullName))
                {
                    this.doctors.Add(new Doctor(doctorFirstName, doctorLastName));
                }
                if (!this.DepartmentExist(departmentName))
                {
                    this.departments.Add(new Department(departmentName));

                }
                Doctor doctor = this.doctors
                    .FirstOrDefault(d => d.FullName == doctorFullName);
                Department department = this.departments
                    .FirstOrDefault(d => d.Name == departmentName);

                bool isFree = department.Rooms
                    .Any(r => r.Count < MAX_CAPACITY);

                if (isFree)
                {
                    AddPatient(patientName, doctor, department);

                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    PrintPatientsFromDepartment(args);

                }
                else if (args.Length == 2 && int.TryParse(args[1], out int roomNum))
                {
                    PrintPatientFromRoom(args, roomNum);
                }
                else
                {
                    PrintDoctorsPatients(args);

                }
                command = Console.ReadLine();
            }
        }

        private static void AddPatient(string patientName, Doctor doctor, Department department)
        {
            Room firstFreeRoom = department.GetFirstFreeRoom();
            Patient patient = new Patient(patientName);
            firstFreeRoom.AddPatient(patient);
            doctor.AddPatient(patient);
        }

        private void PrintDoctorsPatients(string[] args)
        {
            Doctor doctor = this.doctors
                .FirstOrDefault(d => d.FullName == args[0] + " " + args[1]);
            Patient[] doctorsPatients = doctor
                .Patients
                .OrderBy(p => p.Name)
                .ToArray();
            foreach (Patient patient in doctorsPatients)
            {
                Console.WriteLine(patient.ToString());
            }
        }

        private void PrintPatientFromRoom(string[] args, int roomNum)
        {
            Room room = this.departments
                .FirstOrDefault(d => d.Name == args[0])
                 .Rooms
                 .FirstOrDefault(r => r.Number == roomNum);

            Patient[] patientsInRoom = room
                .Patients
                .OrderBy(p => p.Name)
                .ToArray();
            foreach (Patient patient in patientsInRoom)
            {
                Console.WriteLine(patient.ToString());
            }
        }

        private void PrintPatientsFromDepartment(string[] args)
        {
            var department = this.departments
                .FirstOrDefault(d => d.Name == args[0])
                .Rooms
                .Where(r => r.Count > 0);

            foreach (Room room in department)
            {
                Console.WriteLine(room);
            }
        }

        private bool DoctorExist(string fullName) => doctors
            .Any(d => d.FullName == fullName);

        private bool DepartmentExist(string name) => departments
            .Any(dep => dep.Name == name);
    }
}
