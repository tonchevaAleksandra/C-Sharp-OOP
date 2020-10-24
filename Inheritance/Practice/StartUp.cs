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
            Employee empl = new Doctor(); //but in that case we can use just the properties and methods of Employee, not of Doctor
            Person p = new Doctor(); //it takes the properties of the base class, this don't give us an acces to Employee properties 
            Person person = new Person();
            person.Name = "Ivan";
            Console.WriteLine(doctor.SayHello() );//Hi, I'm a Doctor!
            Console.WriteLine(empl.SayHello());//Hi, I'm a Doctor!
            Console.WriteLine(p.SayHello());//Hi, I'm a Doctor!
            Console.WriteLine(person.SayHello());//Hello from Ivan!




        }
    }
}
