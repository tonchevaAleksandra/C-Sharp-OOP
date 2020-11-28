using System;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.CardNameCannotBeNull);
                }

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.CardDamageCannotBeNegative);
                }
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.CardHpCannotBeNegative);
                }
                this.healthPoints = value;
            }
        }

    }
}
