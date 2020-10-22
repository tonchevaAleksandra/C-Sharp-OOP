using System.Collections.Generic;
using System.Text;

namespace Hospital
{
   public class Room
    {
        private const int MAX_CAPACITY = 3;
        private readonly List<Patient> patients;
        public byte Number { get; }
        public Room(byte number)
        {
            this.Number = number;
            this.patients = new List<Patient>();
        }
        public IReadOnlyCollection<Patient> Patients => this.patients;
        public int Count => this.patients.Count;
        public void AddPatient(Patient patient)
        {
            if(this.Count<MAX_CAPACITY)
            {
                this.patients.Add(patient);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Patient patient in this.patients)
            {
                sb.AppendLine(patient.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
