
namespace ExplicitInterfaces.Contracts
{
    public interface IResident : IHuman
    {
        string Country { get; }

        string GetName();

    }
}
