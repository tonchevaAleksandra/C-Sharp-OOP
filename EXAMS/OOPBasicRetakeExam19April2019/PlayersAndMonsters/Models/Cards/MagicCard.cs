
namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int MagicCardDamagePoints = 5;
        private const int MagicCardHealthPoints = 80;
        public MagicCard(string name) 
            : base(name, MagicCardDamagePoints, MagicCardHealthPoints)
        {
        }
    }
}
