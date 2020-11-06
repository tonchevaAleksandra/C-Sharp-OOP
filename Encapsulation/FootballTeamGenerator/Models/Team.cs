using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Models.Common;

namespace FootballTeamGenerator.Models
{
   public class Team
    {
        private string name;
        private readonly List<Player> players;
        public Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            :this()
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set 
            {
                CommonValidation.ValidateName(value);
               this.name = value;
            }
        }

        public int Rating => CalculateRaiting();

        private int CalculateRaiting()
        {
            if (!this.players.Any())
                return 0;
            return (int)Math.Round(this.players.Average(p => p.SkillLevel));
        }

        public void AddPlayer(Player player)
        {
            if(!this.players.Contains(player))
            {
                this.players.Add(player);
            }
        }

        public void RemovePlayer(string name)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == name);

            if(player==null)
            {
                Console.WriteLine($"Player {name} is not in {this.Name} team.");
            }
            else
            {
                this.players.Remove(player);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
