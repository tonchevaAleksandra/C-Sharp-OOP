using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
   public interface ISpecialisedSoldier:IPrivate
    {
        Corps Corps { get; }
    }
}
