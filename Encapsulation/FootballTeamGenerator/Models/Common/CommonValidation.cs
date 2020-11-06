using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models.Common
{
   public class CommonValidation
    {
        private const int MinStatPoints = 0;
        private const int MaxStatPoints = 100;
        public static void ValidateName(string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }

        public static void ValidateStatPoints(int value, string stat)
        {
            if(value<MinStatPoints || value>MaxStatPoints)
            {
                throw new ArgumentException($"{stat} should be between {MinStatPoints} and {MaxStatPoints}.");
            }
        }
    }
}
