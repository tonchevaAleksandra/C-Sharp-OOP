using HAD.Contracts;

namespace HAD.Core.Factory.Contracts
{
    public interface IHeroFactory
    {
        IHero CreateHero(string heroType, string name);
    }
}
