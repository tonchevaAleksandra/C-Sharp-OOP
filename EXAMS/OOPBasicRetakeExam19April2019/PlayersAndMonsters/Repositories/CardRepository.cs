using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ICollection<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            CheckIfCardIsNull(card);
            if (this.Cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException(string.Format( ExceptionMessages.CardAlreadyExist, card.Name));
            }

            this.cards.Add(card);

        }


        public ICard Find(string name)
        {

            return this.cards.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            CheckIfCardIsNull(card);

            return this.cards.Remove(card);
        }
        private static void CheckIfCardIsNull(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardCannotBeNull);
            }
        }
    }
}
