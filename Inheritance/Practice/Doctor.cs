
namespace Practice
{
   public class Doctor:Employee, IPerson
    {
        public string Hospital { get; set; }

        public override string SayHello()
        {
            return $"Hi, I'm a Doctor!";
        }
    }
}
