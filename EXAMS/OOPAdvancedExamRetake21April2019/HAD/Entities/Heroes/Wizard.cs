
namespace HAD.Entities.Heroes
{
    public class Wizard : BaseHero
    {
        private const int BaseStrengthHeroStrength = 25;
        private const int BaseStrengthHeroAgility = 25;
        private const int BaseStrengthHeroIntelligence = 100;
        private const int BaseStrengthHeroHitPoints = 100;
        private const int BaseStrengthHeroDamage = 250;
        public Wizard(string name) 
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
