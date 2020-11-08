
namespace ExplicitInterfaces.Contracts
{
    public interface IPerson:IHuman
    {
        int Age { get; }
        public string GetName();
    }
}
