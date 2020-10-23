using System;

namespace Practice
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var studet = new Student();
            studet.Name = "Pesho";
            studet.Adress = "Samokov, bul.Dobrudja 15, gate:2";
            studet.School = "Goe Milev";
            var employee = new Employee();
            employee.Name = "Todor";
            employee.Company = "IT Services";
            var doctor = new Doctor();
            doctor.Name = "Semov";
          
        }
    }
}
