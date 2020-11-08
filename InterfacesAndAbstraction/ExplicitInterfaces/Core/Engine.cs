using System.Linq;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.IO.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        private IReadable reader;
        private IWritable writer;

        public Engine(IReadable reader, IWritable writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] citizenArgs = input
              .Split()
              .ToArray();

                string name = citizenArgs[0];
                string country = citizenArgs[1];
                int age = int.Parse(citizenArgs[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                this.writer.WriteLine(person.GetName());
                this.writer.WriteLine(resident.GetName());

            }
        }
    }
}
