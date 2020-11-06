
using BirthdayCelebrations.Contracts;

namespace BirthdayCelebrations.Models
{
   public abstract class NaturalInhabitant:IBirthable
    {
        public NaturalInhabitant(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
