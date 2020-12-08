namespace HAD.Entities.Heroes
{
    public class Barbarian : BaseHero
    {
        private const int BaseStrengthHeroStrength = 90;
        private const int BaseStrengthHeroAgility = 25;
        private const int BaseStrengthHeroIntelligence = 10;
        private const int BaseStrengthHeroHitPoints = 350;
        private const int BaseStrengthHeroDamage = 150;

        public Barbarian(string name)
            : base(
                name,
                BaseStrengthHeroStrength,
                BaseStrengthHeroAgility,
                BaseStrengthHeroIntelligence,
                BaseStrengthHeroHitPoints,
                BaseStrengthHeroDamage)
        { }
    }
}