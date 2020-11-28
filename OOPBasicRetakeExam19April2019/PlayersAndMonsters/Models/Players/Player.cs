using System;

using PlayersAndMonsters.Common;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private const int MinHealth = 0;
        private string username;
        private int health;
        private readonly ICardRepository cardRepository;
        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.cardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository => this.cardRepository;

        public string Username
        {
            get => this.username;
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameCannotBeEmpty);
                }

                this.username = value;
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

        public bool IsDead => this.Health<=MinHealth;

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

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Username: {this.Username} - Health: {this.Health} – Cards { this.CardRepository.Count}");

        //    foreach (var card in this.CardRepository.Cards)
        //    {
        //        sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
        //    }
        //    sb.AppendLine("###");

        //    return sb.ToString().Trim();
        //}
    }
}
