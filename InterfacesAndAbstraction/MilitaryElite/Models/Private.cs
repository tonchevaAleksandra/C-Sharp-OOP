using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
      
        public Private(int id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($" Salary: {this.Salary:F2}");
            return sb.ToString().Trim();
        }
    }
}
