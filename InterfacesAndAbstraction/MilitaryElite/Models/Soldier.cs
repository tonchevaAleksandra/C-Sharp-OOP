
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public int ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.ID}";
        }
    }
}
