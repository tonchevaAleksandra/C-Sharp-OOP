using System.Collections.Generic;

namespace Hospital
{
   public class Doctor
    {
        private readonly List<Patient> patients;
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get; }
       
        public IReadOnlyCollection<Patient> Patients => this.patients;
        private Doctor()
        {
            this.patients = new List<Patient>();
        }
        public Doctor(string firstName, string lastName)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = firstName+" " +lastName;
           
        }

        public void AddPatient(Patient patient)
        {
            this.patients.Add(patient);
        }   
    }
}
