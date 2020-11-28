using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;


namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private const int MinHealth = 0;
        private string name;
        private int health;
        private ICardRepository cardRepository;
        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.cardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository => this.cardRepository;

        public string Username
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameCannotBeEmpty);
                }

                this.name = value;
            }
        }

        public int Health 
        { 
            get => this.health;
            set
            {
                if(value<MinHealth)
                {
                    throw new ArgumentException(ExceptionMessages.HealthCannotBeNegative);
                }

                this.health = value;
            }
        }

        public bool IsDead => this.Health>MinHealth;

        public void TakeDamage(int damagePoints)
        {
            if(damagePoints<0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDamagePoints);
            }
            if(this.Health<damagePoints)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
    }
}
