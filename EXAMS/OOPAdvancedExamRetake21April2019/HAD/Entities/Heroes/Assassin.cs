
namespace HAD.Entities.Heroes
{
    public class Assassin : BaseHero
    {
        private const int BaseStrengthHeroStrength = 25;
        private const int BaseStrengthHeroAgility = 100;
        private const int BaseStrengthHeroIntelligence = 15;
        private const int BaseStrengthHeroHitPoints = 150;
        private const int BaseStrengthHeroDamage = 300;
        public Assassin(string name) 
            : base(name,
                BaseStrengthHeroStrength,
                BaseStrengthHeroAgility,
                BaseStrengthHeroIntelligence,
                BaseStrengthHeroHitPoints,
                BaseStrengthHeroDamage)
        {
        }
    }
}
