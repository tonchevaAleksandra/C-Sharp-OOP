
namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int Damage = 120;
        private const int Health = 5;
        public TrapCard(string name) 
            : base(name, Damage, Health)
        {
        }
    }
}
