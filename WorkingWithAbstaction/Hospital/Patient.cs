
namespace Hospital
{
   public class Patient
    {
        public string Name { get; }
        public Patient(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return this.Name.ToString().TrimEnd();
        }
    }
}
