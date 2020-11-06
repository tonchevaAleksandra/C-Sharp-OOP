using System;
using System.Collections.Generic;
using System.Text;
using FootballTeamGenerator.Models.Common;

namespace FootballTeamGenerator.Models
{
   public class Player
    {
        private const int CountStats = 5;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, 
            int sprint, int dribble, 
            int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int SkillLevel => CalculateStat();
        public int Endurance 
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                CommonValidation.ValidateStatPoints(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint 
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                CommonValidation.ValidateStatPoints(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                CommonValidation.ValidateStatPoints(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                CommonValidation.ValidateStatPoints(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                CommonValidation.ValidateStatPoints(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }
        private int CalculateStat()
        {
            return (int)Math.Round((double)(this.Endurance+this.Sprint+this.Dribble+this.Passing+this.Shooting)/CountStats);
        }
    }
}
